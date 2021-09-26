const express = require('express');
const path = require('path');

const initHandlebars = require('./config/handlebars');

const app = express();

initHandlebars(app);
// require('./config/handlebars')(app); // other way to invoke initHandlebars just with require

app.use(express.static(path.resolve(__dirname, './public')));

app.all('/', (req, res) => {
    res.render('index');
});

// with binding 
app.listen(5000, console.log.bind(console, 'Application is running on http://localhost:5000'));
// with arrow function
// app.listen(5000, () => {
//     console.log('Application is running on http://localhost:5000');
// })