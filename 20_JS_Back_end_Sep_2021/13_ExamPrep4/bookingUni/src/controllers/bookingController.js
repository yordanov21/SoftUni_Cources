const router = require('express').Router();

const { isAuth } = require('../middlewares/authMiddleware');
const bookingService = require('../services/bookingService');

// router.get('/', async (req, res) => {

//     let courses = await courseService.getAll();

//     res.render('/', { courses });
// });

router.get('/create', isAuth, (req, res) => {
    res.render('booking/create');
});

router.post('/create', isAuth, async (req, res) => {

    try {
        let { name, city, imageUrl, freeRooms } = req.body;
        console.log(req.body);

        await bookingService.create({ name, city, imageUrl, freeRooms, owner: req.user._id });
        let createdHotel = await bookingService.getLastAddedHotel();

        let createdHotelData = await createdHotel.toObject();
        //let createdTrip = await tripService.getAll();
        console.log('*****************************');
        console.log(createdHotelData);
        console.log(req.user._id);
        console.log(createdHotelData._id);
        console.log('*****************************');

        await bookingService.addHotelToOfferedHotels(req.user._id, createdHotelData._id)


        res.redirect('/');
    } catch (error) {
        res.render('booking/create', { error: getErrorMessage(error) })
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

router.get('/:bookingId/details', isAuth, async (req, res) => {
    let booking = await bookingService.getOne(req.params.bookingId);
    let bookingData = await booking.toObject();

    let isCreator = bookingData.owner == req.user?._id;
    //let tenants = housing.getTenants();


    // let isAvailable = housing.availablePieces > 0;
    let isUserBooked = booking.usersBookedRoom.some(x => x._id == req.user?._id);

    //res.render('course/details', { ...housingData, isCreator, tenants, isAvailable, isRentedByUser });
    //res.render('booking/details', { ...bookingData, isCreator, isUserEnrolled });
    res.render('booking/details', { ...bookingData, isCreator, isUserBooked });
});

router.get('/:bookingId/book', isNotCreator, async (req, res) => {

    await bookingService.addUserToBookedRoom(req.params.bookingId, req.user._id);
    await bookingService.bookedHotels(req.params.bookingId, req.user._id);
    res.redirect(`/booking/${req.params.bookingId}/details`);
});

router.get('/:bookingId/delete', isCreator, async (req, res) => {

    await bookingService.delete(req.params.bookingId);

    res.redirect('/');
});

router.get('/:bookingId/edit', isCreator, async (req, res) => {
    let booking = await bookingService.getOne(req.params.bookingId);
    let bookingData = await booking.toObject();

    res.render('booking/edit', { ...bookingData });
});

router.post('/:bookingId/edit', isCreator, async (req, res) => {
    console.log('asdasdsads');
    await bookingService.updateOne(req.params.bookingId, req.body)
    console.log('asdasdssdfsdfads');
    res.redirect(`/booking/${req.params.bookingId}/details`);
});

// for security guards
async function isNotCreator(req, res, next) {
    let course = await bookingService.getOne(req.params.bookingId);
    console.log(course);

    if (course.creator == req.user._id) {
        res.redirect(`/booking/${req.params.bookingId}/details`);
    } else {
        next();
    }
};

// // for security guards
async function isCreator(req, res, next) {
    let booking = await bookingService.getOne(req.params.bookingId);

    console.log(booking);
    if (booking.owner == req.user._id) {
        next();
    } else {
        console.log('nextsdfdss');
        res.redirect(`/booking/${req.params.bookingId}/details`);

    }
};

module.exports = router;