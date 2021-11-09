import { createFormEntity } from './form-helpers.js';
import { fireBaseRequestFactory } from './firebase-requests.js';


async function applyCommon() {
    this.partials = {
        header: await this.load('../templates/common/header.hbs'),
        footer: await this.load('../templates/common/footer.hbs')
    }

    this.username = sessionStorage.getItem('username');
    this.loggedIn = !!sessionStorage.getItem('token');
    this.hasNoTeam = true;
}

async function homeViewHandler() {
    await applyCommon.call(this);

    this.partial('../templates/home/home.hbs');
}

async function aboutViewHandler() {
    await applyCommon.call(this);

    this.partial('../templates/about/about.hbs');
}

async function loginHandler() {
    await applyCommon.call(this);
    this.partials.loginForm = await this.load('../templates/login/loginForm.hbs');

    await this.partial('../templates/login/loginPage.hbs');

    let formRef = document.querySelector('#login-form');

    formRef.addEventListener('submit', (e) => {
        e.preventDefault();
        let form = createFormEntity(formRef, ['username', 'password']);
        let formValue = form.getValue();

        firebase.auth().signInWithEmailAndPassword(formValue.username, formValue.password)
            .then((response) => {
                firebase.auth().currentUser.getIdToken().then(token => {
                    sessionStorage.setItem('token', token);
                    sessionStorage.setItem('username', response.user.email);
                    sessionStorage.setItem('userId', firebase.auth().currentUser.uid);
                    this.redirect(['#/home']);
                })                
            })    
            .catch(function(error) {
                // Handle Errors here.
                var errorCode = error.code;
                var errorMessage = error.message;
                // ...
            });
    });
}

async function registerViewHandler() {
    await applyCommon.call(this);
    this.partials.registerForm = await this.load('../templates/register/registerForm.hbs');

    await this.partial('../templates/register/registerPage.hbs');

    let formRef = document.querySelector('#register-form');

    let form = createFormEntity(formRef, ['username', 'password', 'repeatPassword']);

    formRef.addEventListener('submit', async (e) => {
        e.preventDefault();
        let formValue = form.getValue();
        if (formValue.password !== formValue.repeatPassword) {
            return;
        }

        firebase.auth().createUserWithEmailAndPassword(formValue.username, formValue.password)
            .then(response => {
                firebase.auth().currentUser.getIdToken().then(token => {
                    sessionStorage.setItem('token', token);
                    sessionStorage.setItem('username', response.user.email);
                    sessionStorage.setItem('userId', firebase.auth().currentUser.uid);

                const usersCollection = fireBaseRequestFactory('https://routingexercise8.firebaseio.com/', 'users', token);

                usersCollection.patchEntity({
                    team: 'none',
                    createdTeams: 'none'
                }, firebase.auth().currentUser.uid)

                });
                this.redirect(['#/home']);
            });
        
        })


}

async function createTeamHandler() {
    await applyCommon.call(this);
    this.partials.createForm = await this.load('../templates/create/createForm.hbs');

    await this.partial('../templates/create/createPage.hbs');
    const firebaseTeams = fireBaseRequestFactory('https://routingexercise8.firebaseio.com/', 'teams', sessionStorage.getItem('token'));

    let formRef = document.querySelector('#create-form');

    formRef.addEventListener('submit', (e) => {
        e.preventDefault();
        
        let form = createFormEntity(formRef, ['name', 'comment']);
        let formValue = form.getValue();

        formValue.teamMembers = [{id: sessionStorage.getItem('userId'), name: sessionStorage.getItem('username')}];
        formValue.createdBy = sessionStorage.getItem('userId');

        firebaseTeams.createEntity(formValue).then(x => {
            console.log(x);
            this.redirect('#/catalog');
        })
    });
}

async function catalogueHandler() {
    
    const teamsCollection = fireBaseRequestFactory('https://routingexercise8.firebaseio.com/', 'teams', sessionStorage.getItem('token'));
    this.teams = Object.entries(await teamsCollection.getAll().then(x => x || {})).map(([id, value]) => ({ _id: id, ...value }));
    
    await applyCommon.call(this);
    this.partials.team = await this.load('../templates/catalog/team.hbs');
    await this.partial('../templates/catalog/teamCatalog.hbs');
}

async function catalogueDetailsHandler() {
    
    const teamsCollection = fireBaseRequestFactory('https://routingexercise8.firebaseio.com/', 'teams', sessionStorage.getItem('token'));
    
    this.teamId = this.params.id;
    let { name, comment, teamMembers, createdBy } = await teamsCollection.getById(this.params.id);
    this.name = name;
    this.comment = comment;
    this.members = (teamMembers || []).map(member => ({ username: member.name }));
    this.isAuthor = createdBy === sessionStorage.getItem('userId');
    this.isOnTeam = (teamMembers || []).find(x => x.id === sessionStorage.getItem('userId'));
    
    await applyCommon.call(this);
    this.partials.teamMember = await this.load('../templates/catalog/teamMember.hbs');
    this.partials.teamControls = await this.load('../templates/catalog/teamControls.hbs');
    this.partial('../templates/catalog/details.hbs')
}

async function editTeamHandler() {
    await applyCommon.call(this);
    this.partials.editForm = await this.load('../templates/edit/editForm.hbs');
    await this.partial('../templates/edit/editPage.hbs');

    const teamsCollection = fireBaseRequestFactory('https://routingexercise8.firebaseio.com/', 'teams', sessionStorage.getItem('token'));

    let formRef = document.querySelector('#edit-form');
    let form = createFormEntity(formRef, ['name', 'comment']);

    
    const teamToEdit = await teamsCollection.getById(this.params.id);
    form.setValue(teamToEdit);

    formRef.addEventListener('submit', async (e) => {
        e.preventDefault();

        let form = createFormEntity(formRef, ['name', 'comment']);
        let formValue = form.getValue();

        await teamsCollection.patchEntity(formValue, this.params.id)

        this.redirect([`#/catalog/${this.params.id}`]);
    })
}

async function logoutHandler() {
    sessionStorage.clear();
    firebase.auth().signOut();
    this.redirect(['#/home']);
}

// initialize the application
const app = Sammy('#main', function () {
    // include a plugin
    this.use('Handlebars', 'hbs');

    // define a 'route'
    this.get('#/', homeViewHandler);
    this.get('#/home', homeViewHandler);
    this.get('#/about', aboutViewHandler);
    this.get('#/login', loginHandler);
    this.post('#/login', () => false);
    this.get('#/register', registerViewHandler);
    this.post('#/register', () => false);
    this.get('#/logout', logoutHandler);
    this.get('#/catalog', catalogueHandler);
    this.get('#/create', createTeamHandler);
    this.get('#/catalog/:id', catalogueDetailsHandler);
    this.get('#/edit/:id', editTeamHandler);
    this.post('#/edit/:id', () => false);
    // this.get('#/join/:id', joinTeamHandler);
    
});

// start the application
app.run('#/');