const fs = require('fs');
const http = require('http');
const formidable = require('formidable');

const storageService = require('./services/storageService.js')

const app = http.createServer((req, res) => {
    switch (req.url) {
        case '/':
            let content = fs.readFileSync('./views/home/index.html');
            res.writeHead(200, {
                'Content-Type': 'text/html'
            });
            res.write(content);
            res.end();
            break;
        case '/styles/site.css':
            let css = fs.readFileSync('./styles/site.css');
            res.writeHead(200, {
                'Content-Type': 'text/css'
            });
            res.write(css);
            res.end();
            break;
        case '/js/script.js':
            let jsScript = fs.readFileSync('./js/script.js');
            res.writeHead(200, {
                'Content-Type': 'text/javascript'
            });
            res.write(jsScript);
            res.end();
            break;
        case '/cats/add-cat':
            if (req.method == 'GET') {
                res.writeHead(200, {
                    'Content-Type': 'text/html'
                });
                fs.readFile('./views/addCat.html', (err, result) => {
                    if (err) {
                        res.statusCode = 404;
                        return res.end();
                    }

                    res.write(result);
                    res.end();
                });
            } else if (req.method == 'POST') {
                console.log('POST');
                let form = new formidable.IncomingForm();

                form.parse(req, (err, fields, files) => {

                    storageService.saveCat(fields)
                        .then(() => {
                            res.end();
                        })
                        .catch(err => {
                            console.log('err');
                            console.log(err);
                        });

                    res.writeHead(302, {
                        'Location': '/'
                    })

                    res.end();
                });
            }
            break;
        case '/cats/add-breed':
            if (req.method == 'GET') {
                res.writeHead(200, {
                    'Content-Type': 'text/html'
                });
                fs.readFile('./views/addBreed.html', (err, result) => {
                    if (err) {
                        res.statusCode = 404;
                        return res.end();
                    }
                    res.write(result);
                    res.end();
                });
            } else if (req.method == 'POST') {
                let form = new formidable.IncomingForm();

                form.parse(req, (err, fields, files) => {

                    storageService.saveBreed(fields)
                        .then(() => {
                            res.end();
                        })
                        .catch(err => {
                            console.log('err');
                            console.log(err);
                        });

                    res.writeHead(302, {
                        'Location': '/'
                    })

                    res.end();
                });
            }
            break;
        default:
            res.statusCode = 404;
            res.end();
            break;
    }

});


app.listen(4000);

console.log('App is listening on port 4000...');