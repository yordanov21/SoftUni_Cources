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
  ];

  constructor(name, description, imageUrl, difficulty) {
    this.id = uniqid();
    this.name = name;
    this.description = description;
    this.imageUrl = imageUrl;
    this.difficulty = difficulty;
  }

  static get cubes() {
    return Cube.#pivatecubes.slice();
  }

  static add(cube) {
    Cube.#pivatecubes.push(cube);
  }
}

module.exports = Cube;
