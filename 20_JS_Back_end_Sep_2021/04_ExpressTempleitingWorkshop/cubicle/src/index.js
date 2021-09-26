const express = require('express');

const app = express();

app.all('/', (req, res) => {
    res.write('It\s working')
    res.end();
});

// with binding 
app.listen(5000, console.log.bind(console, 'Application is running on http://localhost:5000'));
// with arrow function
// app.listen(5000, () => {
//     console.log('Application is running on http://localhost:5000');
// })