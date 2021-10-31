const router = require('express').Router();

const homeController = require('./controllers/homeController');
const autController = require('./controllers/authController');
const postController = require('./controllers/postController');

router.use(homeController);
router.use('/auth', autController);
router.use('/post', postController);
router.use('*', (req, res) => {
    res.render('404');
});


module.exports = router;