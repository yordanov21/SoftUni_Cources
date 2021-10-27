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
    const { email, password, rePassword, gender } = req.body;
    console.log(email);
    console.log(password);
    console.log(rePassword);
    console.log(gender);
    if (password !== rePassword) {

        res.locals.error = 'Password missmatch';
        return res.render('auth/register');
    }

    try {

        await authService.register({ email, password, rePassword, gender })

        let token = await authService.login({ email, password });
        res.cookie(AUTH_COOKIE_NAME, token);

        res.redirect('/')

    } catch (error) {
        console.log(error);
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
    console.log(userData);

    let tripsHistory = user.getTripHistory();
    console.log(tripsHistory);
    // let isOwner = housingData.owner == req.user?._id;
    // let tenants = housing.getTenants();


    // let isAvailable = housing.availablePieces > 0;
    // let isRentedByUser = housing.tenants.some(x => x._id == req.user?._id);

    // res.render('auth/profile');


    //res.render('auth/profile', { ...userData, enrolledCourses });
    //todo not fineshed , there is a bug with populate teh trip history in the profile page
    res.render('auth/profile', { ...userData, tripsHistory });
})

module.exports = router;