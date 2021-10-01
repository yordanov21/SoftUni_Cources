const uniqid = require("uniqid");

class Cube {
  static #pivatecubes = [
    {
      id: "asdfjnkldfvkjlzs",
      name: "Mirror Cube",
      description: "Strange Cube",
      imageUrl:
        "https://upload.wikimedia.org/wikipedia/commons/thumb/2/22/Mirror_Cube_solved.png/1200px-Mirror_Cube_solved.png",
      difficulty: "4",
    },
    {
      id: "yjnjr82sku17at66",
      name: "mega cube",
      description: "mega giga hiber big cube",
      imageUrl:
        "https://cf.bstatic.com/data/xphoto/1182x887/554/55456733.jpg?size=S",
      difficulty: "5",
    },
    {
      id: 'yjnjrek4ku79cmla',
      name: 'Just cube',
      description: 'Cube simple cube for beginners',
      imageUrl: 'https://www.rubiks.com/static/version1607342405/frontend/Bestresponse/rubiks/en_GB/images/error_rubiks_popup.png',
      difficulty: '2'
    },
    {
      id: 'yjnjrek4ku79cmls',
      name: 'Simple Cube',
      description: 'Simple cube :)',
      imageUrl: 'https://6lli539m39y3hpkelqsm3c2fg-wpengine.netdna-ssl.com/wp-content/uploads/2018/07/Rubiks_Cube_shutterstock_271810067.jpg',
      difficulty: '1'
    },
    {
      id: 'yjnjr6zgku8q4pcy',
      name: 'Wood Rubic Cube',
      description: 'Simple Wood Rubic Cube',
      imageUrl: 'https://img.freepik.com/free-photo/wooden-rubik-cube-isolated-white-background_62856-5203.jpg?size=626&ext=jpg',
      difficulty: '1'
    }
  ];

  constructor(name, description, imageUrl, difficulty) {
    this.id = uniqid();
    this.name = name;
    this.description = description;
    this.imageUrl = imageUrl;
    this.difficulty = difficulty;
  }

  static get getAllCubes() {
    return Cube.#pivatecubes.slice();
  }

  static add(cube) {
    Cube.#pivatecubes.push(cube);
  }
}

module.exports = Cube;
