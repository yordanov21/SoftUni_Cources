const router = require('express').Router();

const homeController = require('./controllers/homeController');
const autController = require('./controllers/authController');
//const courseController = require('./controllers/courseController');

router.use(homeController);
router.use('/auth', autController);
//router.use('/course', courseController);
// router.use('*', (req, res) => {
//     res.render('404');
// });


module.exports = router;