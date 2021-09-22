const http = require('http');


const app = http.createServer((req, res) => {
    switch (req.url) {
        case '/':

            break;

        default:
            res.statusCode = 404;
            break;
    }
    res.end();
});


app.listen(4000);

console.log('App is listening on port 4000...');