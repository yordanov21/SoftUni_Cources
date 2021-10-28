const router = require('express').Router();

const bookingService = require('../services/bookingService');

router.get('/', async (req, res) => {

    // all public course
    //let courses = await courseService.getAllPublic();
    // all courses
    // let courses = await courseService.getAll();
    // res.render('home', { title: 'Home Page', courses });
    let bookings = await bookingService.getAll();
    res.render('home', { title: 'Home Page', bookings });

});

module.exports = router;