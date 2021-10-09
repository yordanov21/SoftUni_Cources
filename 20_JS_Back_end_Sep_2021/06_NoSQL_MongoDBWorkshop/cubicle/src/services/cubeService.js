const Cube = require("../models/Cube");
const Accessory = require('../models/Accessory');

const getAll = () => Cube.find({}).lean(); //lean() return array of objects, without lean will return array of models 

const getOne = (id) => Cube.findById(id).populate('accessories').lean()

const create = (name, description, imageUrl, difficulty) => {
  let cube = new Cube({
    name, 
    description, 
    imageUrl, 
    difficulty});

  console.log(cube);
  return cube.save();
};

const search = (text, from, to) => {
    let result = getAll();

    if (text) {
      result = result.filter((x) =>
        x.name.toLowerCase().includes(text.toLowerCase())
      );
    }

    if (from) {
      result = result.filter((x) => x.difficulty >= from);
    }

    if (to) {
      result = result.filter((x) => x.difficulty <= to);
    }

    return result;
};

const attachAccessory = async (cubeId, accessoryId) => {
  let cube = await Cube.findById(cubeId);
  let accessory = await Accessory.findById(accessoryId);

  cube.accessories.push(accessory);

  return cube.save();
};

const cubeService = {
  getAll,
  getOne,
  create,
  search,
  attachAccessory,
};

module.exports = cubeService;
