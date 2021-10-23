const router = require('express').Router();

const courseService = require('../services/courseService');

router.get('/', async (req, res) => {

    // all public course
    //let courses = await courseService.getAllPublic();
    // all courses
    let courses = await courseService.getAll();
    res.render('home', { title: 'Home Page', courses });

});

module.exports = router;