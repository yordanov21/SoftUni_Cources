import { createFormEntity } from './form-helpers.js';
import { fireBaseRequestFactory } from './firebase-requests.js';


async function applyCommon() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs')
    }

    this.username = sessionStorage.getItem('username');
    this.loggedIn = !!sessionStorage.getItem('token');
    this.hasLogin = true;

}

async function homeViewHandler() {
    //print on the console for check
    // console.log(this);
    // console.log("hello from sammy");

    await applyCommon.call(this);
    this.partial('./templates/home/home.hbs')
}

async function aboutViewHandler() {
    await applyCommon.call(this);
    this.partial('./templates/about/about.hbs')
}

async function loginViewHandler() {
    await applyCommon.call(this);
    this.partials.loginForm = await this.load('./templates/login/loginForm.hbs');
    await this.partial('./templates/login/loginPage.hbs');

    let formRef = document.querySelector('#login-form')
    formRef.addEventListener('submit', (e) => {
        //preventvame defautnoto mu sustoqnie
        e.preventDefault();

        let form = createFormEntity(formRef, ['username', 'password']);
        let formValue = form.getValue();

        firebase.auth().signInWithEmailAndPassword(formValue.username, formValue.password)
            .then((response) => {
                firebase.auth().currentUser.getIdToken().then(token => {
                    sessionStorage.setItem('token', token);
                    sessionStorage.setItem('username', response.user.email)
                    this.redirect(['#/home'])
                })
            })
            .catch(function(error) {
                // Handle Errors here.
                var errorCode = error.code;
                var errorMessage = error.message;
                // ...
            });
    })


}

async function registerViewHandler() {
    await applyCommon.call(this);
    this.partials.registerForm = await this.load('./templates/register/registerForm.hbs')
    await this.partial('./templates/register/registerPage.hbs');

    let formRef = document.querySelector('#register-form');


    formRef.addEventListener('submit', (e) => {
        e.preventDefault();
        let form = createFormEntity(formRef, ['username', 'password', 'repeatPassword']);
        let formValue = form.getValue();

        if (formValue.password !== formValue.repeatPassword) {
            //TODO NOTIFICATION
            return;
        }

        //pravim usera vuv firebase
        firebase.auth().createUserWithEmailAndPassword(formValue.username, formValue.password)
            .then(response => {
                console.log(response);

                firebase.auth().currentUser.getIdToken().then(token => {
                    sessionStorage.setItem('token', token);
                    sessionStorage.setItem('username', response.user.email)
                })

                this.redirect(['#/home']);
            })
    })

}

async function catalogeHandler() {
    await applyCommon.call(this);
    this.partial('./templates/catalog/teamCatalog.hbs');

    let token = sessionStorage.getItem('token')
    fetch('https://softuniremotedb-f9911.firebaseio.com/.json?auth=' + token)
        .then(x => x.json())
        .then(res => {
            console.log(res)
        })
}

async function createTeamHandler() {
    await applyCommon.call(this);
    this.partials.createForm = await this.load('./templates/create/createForm.hbs');
    await this.partial('./templates/create/createPage.hbs');

    const forebaseTeams = fireBaseRequestFactory('https://softuniremotedb-f9911.firebaseio.com/', 'teams', sessionStorage.getItem('token'))

    let formRef = document.querySelector('#create-form')
    formRef.addEventListener('submit', (e) => {
        //preventvame defautnoto mu sustoqnie
        e.preventDefault();

        let form = createFormEntity(formRef, ['name', 'comment']);
        let formValue = form.getValue();

        forebaseTeams.createEntity(formValue).then(x => {
            console.log(x);
            this.redirect('#/catalogue')
        })
    })
}

function logoutHandler() {
    sessionStorage.clear();
    firebase.auth().signOut();
    this.redirect(['#/home']);
}

// from sammyjs.org
// initialize the application
var app = Sammy('#main', function() {
    // include a plugin
    this.use('Handlebars', 'hbs');

    // define a 'route'
    this.get('#/', homeViewHandler);
    this.get('#/home', homeViewHandler);
    this.get('#/about', aboutViewHandler);
    this.get('#/login', loginViewHandler);
    this.post('#/login', () => false);
    this.get('#/register', registerViewHandler);
    this.post('#/register', () => false); //podava se zaradi sammy, inache nqma da napravi nishto
    this.get('#/logout', logoutHandler);
    this.get('#/catalog', catalogeHandler);
    this.get('#/create', createTeamHandler);
    this.post('#/create', () => false);
});



(() => {
    // start the application
    app.run('#/');

    console.log("hello");

})()