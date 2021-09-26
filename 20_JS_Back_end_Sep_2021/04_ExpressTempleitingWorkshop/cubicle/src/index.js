const express = require('express');
const path = require('path');
const routes = require('./routes');

const initHandlebars = require('./config/handlebars');

const app = express();

// parser for data from form data
app.use(express.urlencoded({ extended: true }));

initHandlebars(app);
// require('./config/handlebars')(app); // other way to invoke initHandlebars just with require

app.use(express.static(path.resolve(__dirname, './public')));

app.use(routes)

// with binding 
app.listen(5000, console.log.bind(console, 'Application is running on http://localhost:5000'));
// with arrow function
// app.listen(5000, () => {
//     console.log('Application is running on http://localhost:5000');
// })