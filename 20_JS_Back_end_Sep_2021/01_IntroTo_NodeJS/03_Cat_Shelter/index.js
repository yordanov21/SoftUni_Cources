const fs = require('fs');
const http = require('http');
const formidable = require('formidable');
const path = require('path');
const mv = require('mv');
const url = require('url');
const uniqid = require('uniqid');

const storageService = require('./services/storageService.js')
const db = require('./db.json');

const app = http.createServer((req, res) => {

    const pathname = url.parse(req.url).pathname;

    switch (req.url) {
        case '/':
            let content = fs.readFileSync('./views/home/index.html');
            res.writeHead(200, {
                'Content-Type': 'text/html'
            });

            let catsplaceHolder = db.cats.map((cat) => `<li>
             <img src="${'../images/' + cat.image}" alt="${cat.name}">
             <h3>${cat.name}</h3>
             <p><span>Breed: </span>${cat.breed}</p>
             <p><span>Description: </span>${cat.description}</p>
             <ul class="buttons">
                 <li class="btn edit"><a href="/cats-edit/${cat.id}">Change Info</a></li>
                 <li class="btn delete"><a href="/cats-find-new-home/${cat.id}">New Home</a></li>
             </ul>
             </li>`);
            content = content.toString().replace('{{cats}}', catsplaceHolder);

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

                    let catbreedPlaceHolder = db.breeds.map((breed) => `<option value="${breed.breed}">${breed.breed}</option>`);
                    result = result.toString().replace('{{catBreeds}}', catbreedPlaceHolder);


                    res.write(result);
                    res.end();
                });
            } else if (req.method == 'POST') {
                console.log('POST');
                let form = new formidable.IncomingForm();

                form.parse(req, (err, fields, files) => {

                    var oldpath = files.upload.path;
                    var newpath = './images/' + files.upload.name;

                    mv(oldpath, newpath, function(err) {
                        if (err) {
                            console.log('err');
                            console.log(err);
                        }
                    })

                    fields.id = uniqid();
                    fields.image = files.upload.name;

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
            if (pathname.startsWith('/images') && req.method === 'GET') {

                if (pathname.endsWith('jpg') || pathname.endsWith('png')) {
                    let img = fs.readFileSync(`./${pathname}`);
                    res.writeHead(200, {
                        'Content-Type': 'image'
                    });
                    res.write(img);
                    res.end();
                }
            } else if (pathname.includes('/cats-edit') && req.method === 'GET') {
                res.writeHead(200, {
                    'Content-Type': 'text/html'
                });
                console.log(pathname);
                let temp = pathname.split('/')
                console.log(temp);
                fs.readFile('./views/editCat.html', (err, result) => {
                    if (err) {
                        res.statusCode = 404;
                        return res.end();
                    }

                    let temp = pathname.split('/')
                    let catId = temp[temp.length - 1];
                    console.log(catId);
                    let currentCat = db.cats.find(obj => {
                        return obj.id === catId;
                    });
                    console.log(currentCat);


                    console.log('result');
                    console.log(result);
                    console.log('-----------------------');

                    let content = fs.readFileSync('./views/editCat.html', 'utf8');
                    res.writeHead(200, {
                        'Content-Type': 'text/html'
                    });
                    console.log('0');
                    console.log(content);
                    // let catsplaceHolder = db.cats.map((cat) => `<li>
                    //  <img src="${'../images/' + cat.image}" alt="${cat.name}">
                    //  <h3>${cat.name}</h3>
                    //  <p><span>Breed: </span>${cat.breed}</p>
                    //  <p><span>Description: </span>${cat.description}</p>
                    //  <ul class="buttons">
                    //      <li class="btn edit"><a href="/cats-edit/${cat.id}">Change Info</a></li>
                    //      <li class="btn delete"><a href="/cats-find-new-home/${cat.id}">New Home</a></li>
                    //  </ul>
                    //  </li>`);
                    // content = content.toString().replace('{{cats}}', catsplaceHolder);

                    // res.write(content);
                    // res.end();

                    content = db.cats.toString().replace('{{id}}', catId);
                    console.log('1');
                    console.log(content);
                    content = content.replace('{{name}}', currentCat.name);
                    console.log('2');
                    console.log(content);
                    content = content.replace('{{description}}', currentCat.description);

                    const breedsAsOptions = db.breeds.map((b) => `<option value="${b}">${b}</option>`)
                    content = content.replace('catBreeds', breedsAsOptions.join('/'));

                    content = content.replace('{{breed}}', currentCat.breed);

                    // result = result.toString().replace('{{catBreeds}}', catbreedPlaceHolder);

                    console.log('final');
                    console.log(content);


                    res.write(result);
                    res.end();
                });
            } else {
                res.statusCode = 404;
                res.end();
            }

            break;
    }

});

app.listen(4000);

console.log('App is listening on port 4000...');