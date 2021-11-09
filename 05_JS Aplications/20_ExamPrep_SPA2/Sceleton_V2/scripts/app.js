import controllers from '../controllers/index.js';

const app = Sammy('#root', function() {

    this.use('Handlebars', 'hbs');
    //!!!Kogato natiskame buton izpulnqvame get!!!!
    //Home
    this.get('#/home', controllers.home.get.home);

    //User
    this.get('#/user/login', controllers.user.get.login);
    this.get('#/user/register', controllers.user.get.register);

    this.post('#/user/login', controllers.user.post.login);
    this.post('#/user/register', controllers.user.post.register);
    this.get('#/user/logout', controllers.user.get.logout);

    //Idea
    this.get('#/idea/dashboard', controllers.idea.get.dashboard);

    ////create
    this.get('#/idea/create', controllers.idea.get.create);
    this.post('#/idea/create', controllers.idea.post.create);

    ////details
    this.get('#/idea/details/:ideaId', controllers.idea.get.details);

    this.get('#/idea/close/:ideaId', controllers.idea.del.close);
    this.get('#/idea/like/:ideaId', controllers.idea.put.like);

    this.post('#/idea/comment/:ideaId', controllers.idea.put.comment);
});

(() => {
    app.run('#/home');
})();