const Cube = require('../models/Cube');

const getAll = () => Cube.getAllCubes;

const create = (name, description, imageUrl, difficulty) => {

    let cube = new Cube(name, description, imageUrl, difficulty);
    console.log(cube);
    Cube.add(cube);
};

const cubeService = {
    getAll,
    create,
};

module.exports = cubeService;