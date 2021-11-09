import models from '../models/index.js';
import extend from '../utils/context.js';
import notifications from './notification.js'
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

                    context.redirect('#/home');

                    notifications.succsessNotification('Logout succsessful');
                })
                .catch(() => notifications.errorNotification('Invalid credentials')
                    //  console.error(e);
                );

        }
    },
    post: {

        login(context) {
            notifications.loading();

            const { username, password } = context.params;
            models.user.login(username, password)
                .then((response) => {
                    context.user = response;
                    context.username = response.email;
                    context.isLoggedIn = true;
                    context.redirect('#/home');

                    notifications.succsessNotification('Login successful!');

                })
                .catch(() => notifications.errorNotification('Invalid username or password!')
                    //  console.error(e);
                );
        },
        register(context) {
            notifications.loading();

            const { username, password, repeatPassword } = context.params;
            if (password === repeatPassword) {

                models.user.register(username, password)
                    .then((response) => {
                        context.redirect('#/user/login');

                        notifications.succsessNotification('User registration successful!');
                    })
                    .catch(() => notifications.errorNotification('Invalid username or password!'))

            } else {
                notifications.errorNotification('Invalid  repeat password!')
            }

        }
    }
};