const { AUTH_COOKIE_NAME, JWT_SECRET } = require('../constants');
const jwt = require('../utils/jwt');

exports.auth = function (req, res, next) {
    let token = req.cookies[AUTH_COOKIE_NAME];

    if (token) {
        jwt.verify(token, JWT_SECRET)
            .then(decodedToken => {
                req.user = decodedToken; // attach the user to request
                res.locals.user = decodedToken; // attach the user to response. It's give scope to put local variable in the specific request. It's not a global variable for all app
                next();
            })
            .catch(err => {
                res.clearCookie(AUTH_COOKIE_NAME);
                // res.status(401).render('404');
                res.redirect('/auth/login');
            })
    } else {
        next();
    }

};

// for security guards
exports.isAuth = function (req, res, next) {
    if (req.user) {
        next();
    } else {
        res.redirect('/auth/login');
    }
};

// for security guards
exports.isGuest = function (req, res, next) {
    if (!req.user) {
        next();
    } else {
        res.redirect('/');
    }
};

