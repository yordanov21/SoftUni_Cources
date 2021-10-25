const path = require('path');
const express = require('express');
const cookieParser = require('cookie-parser');

const { auth } = require('../middlewares/authMiddleware');

function expressConfig(app) {
    // set title as a global variable 
    app.locals.title = 'Real Estate';
    //setup static files: it's says all request to static folder go to public folder
    app.use('/static', express.static(path.resolve(__dirname, '../public')));
    //setup request data: parse the data from request 
    app.use(express.urlencoded({ extended: true }));
    //setup cookie-parser
    app.use(cookieParser());
    // this middleware must be after cookie-parser, because it's used it;
    app.use(auth);
};

module.exports = expressConfig;