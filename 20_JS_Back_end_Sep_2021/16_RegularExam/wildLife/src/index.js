const express = require('express');

const { PORT } = require('./constants');
const routes = require('./routes');
const { initDatabase } = require('./config/database-config');

const app = express();

// import express configuration for static files
require('./config/express-config')(app);
// directly invoke hbsConfig with app
require('./config/hbs-config')(app);

app.use(routes);

initDatabase()
    .then(() => {
        app.listen(PORT, () => console.log(`The app is running on http://localhost:${PORT}...`));
    })
    .catch(err => {
        console.log('Cannot connect to database: ', err);
    })

