const express = require('express');
const router = express.Router();
const requestLogger = require('../middlewares/requestLoggerMiddleware.js');

router.get('/elenko', (rew, res) => {
    res.write('<h1>Elenko page</h1>');
    res.end();

})

router.get('/:catName', (req, res) => {
    if (req.params.catName === 'gosho') {
        res.redirect('/cat/chochko') // redirect doesn't need end() 
        return;
    }

    res.header({
        'Content-Type': 'text/html'
    });

    res.write(`<h1>CAT ${req.params.catName}</h1>`);
    res.end();

})

// Action level middleware 
// router.get('/:catName', requestLogger, (req, res) => {
//     if (req.params.catName === 'gosho') {
//         res.redirect('/cat/chochko') // redirect doesn't need end() 
//         return;
//     }

//     res.header({
//         'Content-Type': 'text/html'
//     });

//     res.write(`<h1>CAT ${req.params.catName}</h1>`);
//     res.end();

// })


module.exports = router;