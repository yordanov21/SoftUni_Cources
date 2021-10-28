const router = require('express').Router();

const courseService = require('../services/courseService');

router.get('/', async (req, res) => {

    // all public course
    //let courses = await courseService.getAllPublic();

    // all courses
    let courses = await courseService.getAllPopulate();
    let enrolledUsers = courses.usersEnrolled?.lenght;

    if (!enrolledUsers) {
        enrolledUsers = 0;
    }
    console.log(enrolledUsers);

    if (req.user) {
        console.log('user');

        res.render('home/user-home', { title: 'Home Page', courses, enrolledUsers });
    } else {
        console.log('no user');
        res.render('home/guest-home', { title: 'Home Page', courses, enrolledUsers });
    }
});

module.exports = router;