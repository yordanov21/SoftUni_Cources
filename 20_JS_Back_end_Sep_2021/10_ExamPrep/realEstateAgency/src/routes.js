const router = require('express').Router();

const homeController = require('./controllers/homeController');
const autController = require('./controllers/authController');

router.use(homeController);
router.use('/auth',autController);

module.exports = router;