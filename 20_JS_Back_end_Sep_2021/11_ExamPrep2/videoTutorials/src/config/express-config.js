const path = require('path');
const express = require('express');
const cookieParser = require('cookie-parser');

const { auth } = require('../middlewares/authMiddleware');

function expressConfig(app) {
    app.locals.title = 'Real Estate'; // set title as a global variable 
    app.use('/static', express.static(path.resolve(__dirname, '../public'))); //setup static files: it's says all request to static folder go to public folder
    app.use(express.urlencoded({ extended: true })); //setup request data: parse the data from request 
    app.use(cookieParser()); //setup cookie-parser
    app.use(auth); // this middleware must be after cookie-parser, because it's used it;
};

module.exports = expressConfig;