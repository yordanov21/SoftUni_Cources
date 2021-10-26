const router = require('express').Router();

const homeController = require('./controllers/homeController');
const autController = require('./controllers/authController');
const sharedTripsController = require('./controllers/sharedTripsController');

router.use(homeController);
router.use('/auth', autController);
router.use('/sharedTrips', sharedTripsController);
router.use('*', (req, res) => {
    res.render('404');
});


module.exports = router;