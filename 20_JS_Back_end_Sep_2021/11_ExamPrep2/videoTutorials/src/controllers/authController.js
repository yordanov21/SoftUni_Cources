const router = require('express').Router();

const { isAuth, isGuest } = require('../middlewares/authMiddleware')
const authService = require('../services/authService');
const { AUTH_COOKIE_NAME } = require('../constants');


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
        console.log(error);

        // TODO: Yordan Yordanov (date: 2021-10-20) - return error
        res.end();
    }

})

router.get('/register', isGuest, (req, res) => {
    res.render('auth/register');
})

router.post('/register', isGuest, async (req, res) => {
    const { username, password, repeatPassword } = req.body;

    if (password !== repeatPassword) {
        res.locals.error = 'Password missmatch';
        return res.render('/auth/register');
    }

    try {

        await authService.register({ username, password, repeatPassword })

        let token = await authService.login({ username, password });
        res.cookie(AUTH_COOKIE_NAME, token);

        res.redirect('/')

    } catch (error) {
        console.log(error);
        // TODO: Yordan Yordanov (date: 2021-10-20) - return error

    }
});

router.get('/logout', isAuth, (req, res) => {
    res.clearCookie(AUTH_COOKIE_NAME);
    res.redirect('/');

});

module.exports = router;