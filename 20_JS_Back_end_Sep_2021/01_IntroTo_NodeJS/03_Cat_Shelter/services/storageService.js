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


const storageService = {
    saveCat,
    saveBreed
}

module.exports = storageService;