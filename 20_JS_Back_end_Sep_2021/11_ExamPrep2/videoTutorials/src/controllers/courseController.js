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
        let { title, description, imageUrl, isPublicParam } = req.body;
        let isPublic = false;
        if (isPublicParam == 'on') {
            isPublic = true;
        }
        let createdAt = new Date();
        await courseService.create({ title, description, imageUrl, isPublic, createdAt, creator: req.user._id });
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
    //let isRentedByUser = housing.tenants.some(x => x._id == req.user?._id);

    //res.render('course/details', { ...housingData, isCreator, tenants, isAvailable, isRentedByUser });
    res.render('course/details', { ...courseData, isCreator });
});

// router.get('/:housingId/rent', isOwner, async (req, res) => {

//     await housingService.addTenant(req.params.housingId, req.user._id);

//     res.redirect(`/housing/${req.params.housingId}/details`);
// });

// router.get('/:housingId/delete', isNotOwner, async (req, res) => {
//     await housingService.delete(req.params.housingId);

//     res.redirect('/housing');
// });

// router.get('/:housingId/edit', isNotOwner, async (req, res) => {
//     let housing = await housingService.getOne(req.params.housingId);
//     let housingData = await housing.toObject();

//     res.render('housing/edit', { ...housingData });
// });

// router.post('/:housingId/edit', isNotOwner, async (req, res) => {
//     await housingService.updateOne(req.params.housingId, req.body)

//     res.redirect(`/housing/${req.params.housingId}/details`);
// });

// // for security guards
// async function isOwner(req, res, next) {
//     let housing = await housingService.getOne(req.params.housingId);

//     if (housing.owner == req.user._id) {
//         res.redirect(`/housing/${req.params.housingId}/details`);
//     } else {
//         next();
//     }
// };

// // for security guards
// async function isNotOwner(req, res, next) {
//     let housing = await housingService.getOne(req.params.housingId);

//     if (housing.owner != req.user._id) {
//         next();
//     } else {
//         res.redirect(`/housing/${req.params.housingId}/details`);

//     }
// };

module.exports = router;