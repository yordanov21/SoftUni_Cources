const router = require('express').Router();

const courseService = require('../services/courseService');

router.get('/', async (req, res) => {

    let courses = await courseService.getAll();
    console.log(req.user);
    console.log(courses);

    res.render('home', { title: 'Home Page', courses });

});

module.exports = router;