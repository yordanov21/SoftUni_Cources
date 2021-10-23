const router = require('express').Router();

router.get('/', async (req, res) => {

    //res.send('hello!')
    res.render('home', { title: 'Home Page' });

});

module.exports = router;