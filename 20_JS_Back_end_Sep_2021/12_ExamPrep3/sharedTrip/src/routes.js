const router = require('express').Router();

const homeController = require('./controllers/homeController');
const autController = require('./controllers/authController');
const tripsController = require('./controllers/tripController');

router.use(homeController);
router.use('/auth', autController);
router.use('/trip', tripsController);
router.use('*', (req, res) => {
    res.render('404');
});


module.exports = router;