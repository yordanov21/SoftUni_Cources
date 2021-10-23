
const express = require('express');

const { PORT } = require('./constants')
const routes = require('./routes');
const { initDatabase } = require('./config/database-config')

const app = express();

// routes
// controllers
// globall error handler
// services
// add database
// add model
// authentication
// authorization

// import express configuration for static files
require('./config/express-config')(app);

// import handlebars configuration
//const hbsConfig = require('./config/hbsConfig');
// import by destructuring
//const { hbsConfig } = require('./config/hbsConfig');
// directly invoke hbsConfig with app
require('./config/hbs-config')(app);

app.use(routes);


initDatabase()
.then(() => {
    app.listen(PORT, () => console.log(`The app is running on http://localhost:${PORT}/ ...`));
})
.catch(err => {
    console.log('Cannot connect to database: ', err);
})
