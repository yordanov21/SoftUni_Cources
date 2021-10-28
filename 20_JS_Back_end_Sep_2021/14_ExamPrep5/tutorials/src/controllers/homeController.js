const router = require('express').Router();

const courseService = require('../services/courseService');

router.get('/', async (req, res) => {

    // all public course
    //let courses = await courseService.getAllPublic();

    // all courses
    let allCourses = await courseService.getAllPopulate();
    let first3CoursesByEnrolled = await courseService.getFirst3ByEnrolled();

    if (req.user) {
        console.log('user');

        res.render('home/user-home', { title: 'Home Page', allCourses, allCourses });
    } else {
        console.log('no user');
        res.render('home/guest-home', { title: 'Home Page', allCourses, first3CoursesByEnrolled });
    }
});

router.get('/search', async (req, res) => {

    // req.query - return object
    // req.query.text - return text
    let searchtext = req.query.text;
    console.log("/////////////////////");
    console.log(searchtext);
    if (!searchtext) {
        searchtext = '';
    }
    let courses = await courseService.search(searchtext);
    // console.log(courses);
    res.render('search', { title: 'Search Courses', courses });
});

module.exports = router;