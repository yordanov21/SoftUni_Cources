const router = require('express').Router();

router.get('/', async (req, res) => {

    console.log(req.user);
    res.render('home', { title: 'Home Page' });

});

module.exports = router;