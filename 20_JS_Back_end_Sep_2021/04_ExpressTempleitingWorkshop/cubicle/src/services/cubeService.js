const Cube = require('../models/Cube');

const getAll = () => Cube.getAllCubes;

const getOne = (id) => Cube.getAllCubes.find(x =>x.id == id);

const create = (name, description, imageUrl, difficulty) => {

    let cube = new Cube(name, description, imageUrl, difficulty);
    console.log(cube);
    Cube.add(cube);
};

const search = (text, from, to) => Cube.getAllCubes.filter(x => x.name.toLowerCase().includes(text.toLowerCase()));

const cubeService = {
    getAll,
    getOne,
    create,
    search,
};

module.exports = cubeService;