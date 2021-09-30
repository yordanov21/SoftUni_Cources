const Cube = require('../models/Cube');

const getAll = () => Cube.getAllCubes;

const getOne = (id) => Cube.getAllCubes.find(x =>x.id == id);

const create = (name, description, imageUrl, difficulty) => {

    let cube = new Cube(name, description, imageUrl, difficulty);
    console.log(cube);
    Cube.add(cube);
};

const cubeService = {
    getAll,
    getOne,
    create,
};

module.exports = cubeService;