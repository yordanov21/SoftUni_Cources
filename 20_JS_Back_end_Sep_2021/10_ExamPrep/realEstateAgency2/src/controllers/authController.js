const router = require('express').Router();

const { isAuth, isGuest } = require('../middlewares/authMiddleware')
const authService = require('../services/authServise');
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
        // TODO: Yordan Yordanov (date: 2021-10-20) - return error
        res.end();
    }

})

router.get('/register', isGuest, (req, res) => {
    res.render('auth/register');
})

router.post('/register', isGuest, async (req, res) => {
    const { name, username, password, rePassword } = req.body;

    if (password !== rePassword) {
        res.locals.error = 'Password missmatch';
        return res.render('/auth/register');
    }

    try {

        await authService.register({ name, username, password, rePassword })

        let token = await authService.login({ username, password });
        res.cookie(AUTH_COOKIE_NAME, token);

        res.redirect('/')



    } catch (error) {
        // TODO: Yordan Yordanov (date: 2021-10-20) - return error

    }
});

router.get('/logout', isAuth, (req, res) => {
    res.clearCookie(AUTH_COOKIE_NAME);
    res.redirect('/');

});


module.exports = router;