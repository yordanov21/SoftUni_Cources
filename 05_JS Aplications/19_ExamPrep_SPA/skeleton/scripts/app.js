import controllers from '../controllers/index.js';

const app = Sammy('#root', function() {

    this.use('Handlebars', 'hbs');
    //!!!Kogato natiskame buton izpulnqvame get!!!!
    //Home
    this.get('#/home', controllers.home.get.home);

    //User
    ////register
    this.get('#/user/register', controllers.user.get.register);
    this.post('#/user/register', controllers.user.post.register);

    //login
    this.get('#/user/login', controllers.user.get.login);
    this.post('#/user/login', controllers.user.post.login);

    ////logout
    this.get('#/user/logout', controllers.user.get.logout);

    //Trek
    this.get('#/trek/create', controllers.trek.get.create);
    this.post('#/trek/create', controllers.trek.post.create);
    this.get('#/trek/dashboard', controllers.trek.get.dashboard);

    // this.get('#/trek/details/:trekId', controllers.trek.get.details);


    // this.get('#/trek/close/:trekId', controllers.trek.del.close);
    // this.post('#/trek/donate/:trekId', controllers.trek.put.donate);


});

(() => {
    app.run('#/home');
})();