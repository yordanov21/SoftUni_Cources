const express = require('express');
const path = require('path');
const routes = require('./routes');

const config = require('./config/config.json')[process.env.NODE_ENV];
const initDatabase = require('./config/database');

const initHandlebars = require('./config/handlebars');

const app = express();

// parser for data from form data
app.use(express.urlencoded({ extended: true }));

initHandlebars(app);
// require('./config/handlebars')(app); // other way to invoke initHandlebars just with require

app.use(express.static(path.resolve(__dirname, './public')));

app.use(routes)

initDatabase(config.DB_CONNECTION_STRING)
    .then( () =>{
        app.listen(config.PORT, console.log.bind(console, `Application is running on http://localhost:${config.PORT}`));
    })
    .catch(err => {
        console.log('Application init failed: ', err)
    });
