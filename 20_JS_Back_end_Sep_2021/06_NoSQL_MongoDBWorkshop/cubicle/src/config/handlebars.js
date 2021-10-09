const handlebars = require('express-handlebars');
const path = require('path')

const initHandlebars = (app) => {
    // app.set('views', path.resolve( __dirname, '../views')); // with __dirname resove() take the relative path that we pass to resove and turns it to absolute path
    app.set('views', path.resolve('./src/views')); // resove() take the relative path that we pass to resove and turns it to absolute path
    app.engine('hbs', handlebars({
        extname: 'hbs'
    }));
    app.set('view engine', 'hbs');
}

module.exports = initHandlebars;