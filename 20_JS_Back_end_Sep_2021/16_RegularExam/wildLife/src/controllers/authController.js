const router = require('express').Router();

const { isAuth, isGuest } = require('../middlewares/authMiddleware')
const authService = require('../services/authService');
const { AUTH_COOKIE_NAME } = require('../constants');


router.get('/login', isGuest, (req, res) => {
    res.render('auth/login');
})

router.post('/login', isGuest, async (req, res) => {
    const { email, password } = req.body;
    try {
        let token = await authService.login({ email, password });

        res.cookie(AUTH_COOKIE_NAME, token);

        res.redirect('/');
    } catch (error) {
        res.locals.error = error;
        return res.render('auth/login');
    }

})

router.get('/register', isGuest, (req, res) => {
    res.render('auth/register');
})

router.post('/register', isGuest, async (req, res) => {
    const { firstName, lastName, email, password, rePassword } = req.body;


    if (password !== rePassword) {

        res.locals.error = 'Password missmatch';
        return res.render('auth/register');
    }

    try {

        await authService.register({ firstName, lastName, email, password, rePassword })

        let token = await authService.login({ email, password });
        res.cookie(AUTH_COOKIE_NAME, token);

        res.redirect('/')

    } catch (error) {
        res.locals.error = error;


        return res.render('auth/register');
    }
});

router.get('/logout', isAuth, (req, res) => {
    res.clearCookie(AUTH_COOKIE_NAME);
    res.redirect('/');

});


router.get('/:userId/profile', async (req, res) => {
    let user = await authService.getOne(req.params.userId);
    let userData = await user.toObject();

    res.render('auth/profile', { userData });
})

module.exports = router;