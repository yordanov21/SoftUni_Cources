const requestLogger = (req, res, next) => {
    console.log(req.path);

    next(); // without next middleware doesn't work
};

module.exports = requestLogger;