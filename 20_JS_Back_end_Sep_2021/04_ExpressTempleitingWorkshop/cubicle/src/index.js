const express = require('express');
const handlebars = require('express-handlebars');
const path = require('path')

const app = express();

app.set('views', path.resolve('./src/views')); // resove() take the relative path that we pass to resove and turns it to absolute path
app.engine('hbs', handlebars({
    extname: 'hbs'
}));
app.set('view engine', 'hbs');

app.all('/', (req, res) => {
    res.render('index');
});

// with binding 
app.listen(5000, console.log.bind(console, 'Application is running on http://localhost:5000'));
// with arrow function
// app.listen(5000, () => {
//     console.log('Application is running on http://localhost:5000');
// })