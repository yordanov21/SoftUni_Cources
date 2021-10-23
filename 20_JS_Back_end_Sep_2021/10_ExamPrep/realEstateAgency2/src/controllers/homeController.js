const router = require('express').Router();

const housingService = require('../services/housingService');

router.get('/', async (req, res) => {

    let housings = await housingService.getTopHouses();

    res.render('home', {title: 'Home Page', housings});
})

router.get('/search', async (req, res) => {

    // req.query - return object
    // req.query.text - return text
    let searchtext = req.query.text;
    let housings = await housingService.search(searchtext);
    res.render('search', {title: 'Search Housing', housings});
});
module.exports = router;