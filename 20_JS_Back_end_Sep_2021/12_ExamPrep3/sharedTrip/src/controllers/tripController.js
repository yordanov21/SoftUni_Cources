const router = require('express').Router();

const { isAuth } = require('../middlewares/authMiddleware');
const tripService = require('../services/tripService');

router.get('/', async (req, res) => {

    // all public course
    //let courses = await courseService.getAllPublic();
    // all courses
    // let courses = await courseService.getAll();
    // res.render('home', { title: 'Home Page', courses });

    let trips = await tripService.getAll();
    res.render('trip', { title: 'Shared Trips', trips });

});

router.get('/create', isAuth, (req, res) => {
    res.render('trip/create');
});

router.post('/create', isAuth, async (req, res) => {

    try {
        let { startPoint, endPoint, date, time, carImage, carBrand, seats, price, description } = req.body;

        console.log(req.body);
        console.log(req.user._id);
        await tripService.create({ startPoint, endPoint, date, time, carImage, carBrand, seats, price, description, creator: req.user._id });
        res.redirect('/trip');
    } catch (error) {
        console.log(error);

        // res.render('trip/create', { error: getErrorMessage(error) })
    }
});


function getErrorMessage(error) {
    let errorNames = Object.keys(error.errors);

    if (errorNames.length > 0) {
        return error.errors[errorNames[0]];
    } else {
        error.message;
    }
}


module.exports = router;
