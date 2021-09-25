const db = require('../db.json');
const fs = require('fs/promises');

const saveCat = (cat) => {
    db.cats.push(cat);

    let result = JSON.stringify(db, null, 2);

    return fs.writeFile('./db.json', result, {
        encoding: 'utf8',
        flag: 'w',
        mode: 0o666
    });
}

const saveBreed = (breed) => {
    db.breeds.push(breed);

    let result = JSON.stringify(db, null, 2);

    return fs.writeFile('./db.json', result, {
        encoding: 'utf8',
        flag: 'w',
        mode: 0o666
    });
}


const editCat = (cat) => {
    console.log('cat');
    console.log(cat);

    db.cats[1] = cat;
    console.log('cat from DB');
    console.log(db.cats[cat.id]);

    let result = JSON.stringify(db, null, 2);

    console.log('result');
    console.log(result);

    return fs.writeFile('./db.json', result, {
        encoding: 'utf8',
        flag: 'w',
        mode: 0o666
    });
}


const storageService = {
    saveCat,
    saveBreed,
    editCat
}

module.exports = storageService;