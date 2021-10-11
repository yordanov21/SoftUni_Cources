const uniqid = require("uniqid");
const bcript = require("bcrypt");
const users = [];

function register(username, password) {
  if (users.some((x) => x.username == username)) {
    throw { message: "user already registered" };
  }

  bcript.hash(password, 9)
  .then(hash =>{
    let user = { id: uniqid(), username, password: hash };

    username.push(user);
  
    return user;
  });

  
}

const authService = {
  register,
};

module.exports = authService;
