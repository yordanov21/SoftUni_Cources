const router = require('express').Router();

const homeController = require('./controllers/homeController');
const autController = require('./controllers/authController');
const bookingController = require('./controllers/bookingController');

router.use(homeController);
router.use('/auth', autController);
router.use('/booking', bookingController);
router.use('*', (req, res) => {
    res.render('404');
});


module.exports = router;