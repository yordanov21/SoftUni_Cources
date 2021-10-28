const router = require('express').Router();

const { isAuth, isGuest } = require('../middlewares/authMiddleware')
const authService = require('../services/authService');
const { AUTH_COOKIE_NAME } = require('../constants');


router.get('/login', isGuest, (req, res) => {
    res.render('auth/login');
})

router.post('/login', isGuest, async (req, res) => {
    const { username, password } = req.body;
    try {
        let token = await authService.login({ username, password });

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
    const { username, password, rePassword } = req.body;

    if (password !== rePassword) {

        res.locals.error = 'Password missmatch';
        return res.render('auth/register');
    }

    try {

        await authService.register({ username, password, rePassword })

        let token = await authService.login({ username, password });
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
    console.log('Profile');
    console.log(user);

    let enrolledCourses = user.getEnrolledCourses();
    // let isOwner = housingData.owner == req.user?._id;
    // let tenants = housing.getTenants();


    // let isAvailable = housing.availablePieces > 0;
    // let isRentedByUser = housing.tenants.some(x => x._id == req.user?._id);

    // res.render('auth/profile');


    res.render('auth/profile', { ...userData, enrolledCourses });
})

module.exports = router;