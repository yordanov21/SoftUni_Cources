const router = require('express').Router();

const courseService = require('../services/courseService');

router.get('/', async (req, res) => {

    // all public course
    //let courses = await courseService.getAllPublic();
    // all courses
    //let courses = await courseService.getAll();
    //res.render('home', { title: 'Home Page', courses });
    //res.render('home/guest-home', { title: 'Home Page' });
    res.render('home/user-home', { title: 'Home Page' });
});

module.exports = router;