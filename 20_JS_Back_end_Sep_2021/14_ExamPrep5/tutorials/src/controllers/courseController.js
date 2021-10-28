const router = require('express').Router();

const { isAuth } = require('../middlewares/authMiddleware');
const courseService = require('../services/courseService');

router.get('/', async (req, res) => {

    let courses = await courseService.getAll();

    res.render('/', { courses });
});

router.get('/create', isAuth, (req, res) => {
    res.render('course/create');
});

router.post('/create', isAuth, async (req, res) => {

    try {
        let { title, description, imageUrl, duration } = req.body;

        let createdAt = new Date();
        await courseService.create({ title, description, imageUrl, duration, createdAt, creator: req.user._id });
        console.log(req.body);
        res.redirect('/');
    } catch (error) {
        res.render('course/create', { error: getErrorMessage(error) })
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

router.get('/:courseId/details', async (req, res) => {
    let course = await courseService.getOne(req.params.courseId);
    let courseData = await course.toObject();

    let isCreator = courseData.creator == req.user?._id;
    //let tenants = housing.getTenants();


    // let isAvailable = housing.availablePieces > 0;
    let isUserEnrolled = course.usersEnrolled.some(x => x._id == req.user?._id);

    //res.render('course/details', { ...housingData, isCreator, tenants, isAvailable, isRentedByUser });
    res.render('course/details', { ...courseData, isCreator, isUserEnrolled });
});

router.get('/:courseId/enroll', isNotCreator, async (req, res) => {

    await courseService.addUserEnrolled(req.params.courseId, req.user._id);
    await courseService.enrolledCourse(req.params.courseId, req.user._id);
    res.redirect(`/course/${req.params.courseId}/details`);
});

router.get('/:courseId/delete', isCreator, async (req, res) => {

    await courseService.delete(req.params.courseId);

    res.redirect('/');
});

router.get('/:courseId/edit', isCreator, async (req, res) => {
    let course = await courseService.getOne(req.params.courseId);
    let courseData = await course.toObject();

    res.render('course/edit', { ...courseData });
});

router.post('/:courseId/edit', isCreator, async (req, res) => {
    console.log('asdasdsads');
    await courseService.updateOne(req.params.courseId, req.body)
    console.log('asdasdssdfsdfads');
    res.redirect(`/course/${req.params.courseId}/details`);
});

// for security guards
async function isNotCreator(req, res, next) {
    let course = await courseService.getOne(req.params.courseId);
    console.log(course);

    if (course.creator == req.user._id) {
        res.redirect(`/course/${req.params.courseId}/details`);
    } else {
        next();
    }
};

// // for security guards
async function isCreator(req, res, next) {
    let course = await courseService.getOne(req.params.courseId);

    console.log(course);
    if (course.creator == req.user._id) {
        next();
    } else {
        console.log('nextsdfdss');
        res.redirect(`/course/${req.params.courseId}/details`);

    }
};

module.exports = router;