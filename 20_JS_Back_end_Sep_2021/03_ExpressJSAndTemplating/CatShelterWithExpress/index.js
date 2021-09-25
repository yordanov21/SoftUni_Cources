const express = require('express');
const path = require('path');
const fs = require('fs');

const app = express();
const port = 3000;

app.get('/', (req, res) => {

    let absolutePath = path.join(__dirname, '/views/home/index.html');
    res.sendFile(absolutePath);
});

app.get('/addBreed', (req, res) => {

    res.header({
        'Content-Type': 'text/html'
    });

    res.write('<h1>ADD BREED</h1>')
    res.end();
})

app.get('/addCat', (req, res) => {

    res.header({
        'Content-Type': 'text/html'
    });

    res.write('<h1>ADD CAT</h1>')
    res.end();
})

app.get('/cat/:catName', (req, res) => {
    res.header({
        'Content-Type': 'text/html'
    });

    res.write(`<h1>CAT ${req.params.catName}</h1>`);
    res.end();
})

app.get('/download', (req, res) => {

    res.download('./images/germanDog.jpg');

    // download with Streams way
    // res.header({
    //     'Content-Disposition': 'attachment; filename="germanDog.jpg"'
    // });
    // let imageStream = fs.createReadStream('./images/germanDog.jpg')
    // imageStream.pipe(res);

    // it is not need res.end(). download() and pipe() put end in them
})

app.get('/data', (req, res) => {

    res.json({ name: 'Chochko', age: 5 });
})

app.get('/add*', (req, res) => {
    res.send('Matches everything')
})

app.get(/.*fly$/, (req, res) => {
    res.send('butterfly, dragonfly')
})


app.listen(port, () => console.log(`Server is running on port ${port}...`));