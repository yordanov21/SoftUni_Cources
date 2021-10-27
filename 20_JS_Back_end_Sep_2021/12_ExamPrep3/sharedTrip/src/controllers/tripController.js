const router = require('express').Router();

const { isAuth } = require('../middlewares/authMiddleware');
const tripService = require('../services/tripService');
const authService = require('../services/authService');

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
        let createdTrip = await tripService.getLastAddedTrip();
        let createdTripData = await createdTrip.toObject();
        //let createdTrip = await tripService.getAll();
        console.log('*****************************');
        console.log(createdTripData);
        console.log(req.user._id);
        console.log(createdTripData._id);
        console.log('*****************************');

        await tripService.addTripToTripHistory(req.user._id, createdTripData._id)
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

router.get('/:tripId/details', async (req, res) => {
    let trip = await tripService.getOne(req.params.tripId);
    let tripData = await trip.toObject();
    let creator = await authService.getOne(tripData.creator);
    let emailCreator = creator.email
    console.log(emailCreator);

    let isCreator = tripData.creator == req.user?._id;
    //let tenants = housing.getTenants();


    // let isAvailable = housing.availablePieces > 0;
    // let isUserEnrolled = course.usersEnrolled.some(x => x._id == req.user?._id);

    //res.render('course/details', { ...housingData, isCreator, tenants, isAvailable, isRentedByUser });
    //res.render('course/details', { ...courseData, isCreator, isUserEnrolled });
    res.render('trip/details', { ...tripData, isCreator, emailCreator });
});


module.exports = router;
