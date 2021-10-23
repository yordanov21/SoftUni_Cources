const router = require('express').Router();
const { AUTH_COOKIE_NAME } = require('../constants');

const authService = require('../services/authServise');

router.get('/login', (req, res) => {
    res.render('auth/login');
})

router.post('/login', async (req, res) => {
    const { username, password } = req.body;
    try {
        let token = await authService.login({ username, password });

        res.cookie(AUTH_COOKIE_NAME, token);

        res.redirect('/');
    } catch (error) {
        // TODO: Yordan Yordanov (date: 2021-10-20) - return error
        res.end();
    }

})

router.get('/register', (req, res) => {
    res.render('auth/register');
})

router.post('/register', async (req, res) => {
    const { name, username, password, rePassword } = req.body;

    if (password !== rePassword) {
        res.locals.error = 'Password missmatch';
        return res.render('/auth/register');
    }

    try {
        await authService.register({ name, username, password, rePassword });

        // TODO: Yordan Yordanov (date: 2021-10-20) - add login
        
        res.redirect('/')
    } catch (error) {
        // TODO: Yordan Yordanov (date: 2021-10-20) - return error

    }


    res.redirect('/');
});

module.exports = router;