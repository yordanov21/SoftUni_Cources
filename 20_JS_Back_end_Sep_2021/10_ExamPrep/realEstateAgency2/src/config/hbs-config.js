const path = require('path');
const handlebars = require('express-handlebars');

function hbsConfig(app) {
    app.engine('hbs', handlebars({
        extname: 'hbs',   // the extension of the views files (we use .hbs)
    }));

    app.set('views', path.resolve(__dirname, '../views'));
    app.set('view engine', 'hbs');
}

// with this way import by destructuring {}, it is good when we have several functions for exporting
//exports.hbsConfig = hbsConfig;

// the default export
module.exports = hbsConfig;
