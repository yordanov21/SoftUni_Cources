const Cube = require('../models/Cube');

const cubeDb = [{
    name: 'Mirror cube',
    description: 'Mirror cube Mirror cube',
    imageUrl: 'https://m.media-amazon.com/images/I/41KNQRXAYvL._AC_SY580_.jpg',
    difficulty: '4'
}];

// get cloning of the array with slice
const getAll = () => cubeDb.slice();

const create = (name, description, imageUrl, difficulty) => {

    let cube = new Cube(name, description, imageUrl, difficulty);
    cubeDb.push(cube);
};

const cubeService = {
    getAll,
    create,
};

module.exports = cubeService;