import models from '../models/index.js';
import extend from '../utils/context.js';

export default {
    //създаваме си два обекта get и пост
    get: {
        //context се подава defaut от Sammy
        login(context) {

            extend(context).then(function() {
                this.partial("../views/user/login.hbs")
            });
        },
        register(context) {

            extend(context).then(function() {
                this.partial("../views/user/register.hbs")
            });
        },
        logout(context) {
            models.user.logout().then((response) => {
                    context.redirect('#/user/login');

                })
                .catch((e) => console.error(e));

        }
    },
    post: {

        login(context) {

            const { email, password } = context.params;
            models.user.login(email, password)
                .then((response) => {
                    debugger;
                    context.user = response;
                    context.email = response.email;
                    context.isLoggedIn = true;
                    context.redirect('#/home');



                })
                .catch((e) => console.error(e));
        },
        register(context) {

            const { email, password, reppass } = context.params;
            if (password === reppass) {

                models.user.register(email, password)
                    .then((response) => {
                        context.redirect('#/home');

                    })
                    .catch((e) => console.error(e));

            }

        }
    }
};