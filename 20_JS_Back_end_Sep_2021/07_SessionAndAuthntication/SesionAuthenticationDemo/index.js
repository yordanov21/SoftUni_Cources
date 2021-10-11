const express = require("express");
const fs = require("fs/promises");
const path = require("path");
const cookieParser = require("cookie-parser");
const session = require("express-session");
const bcript = require("bcrypt");
const passwordHolder = require("./passwordsHolder.json");
const jwt = require("jsonwebtoken");
const uniqid = require("uniqid");
const handlebars = require("express-handlebars");
const authService = require("./services/authService");

const SECRET = "mysecret";

const app = express();

// parser for form data
app.use(express.urlencoded({ extended: true }));

// cookie-parser middleware
app.use(cookieParser());
// session middleware
app.use(
  session({
    resave: false,
    saveUninitialized: true,
    secret: [
      "skdjfdkshfsklf;alfhaslfksdf",
      "sfghfghfhyuwerwer",
      "asdasdeghfgjhgjhfgddfg",
    ], //it can be only one or array of secrets
  })
);

// setup handlebars
app.engine(
  "hbs",
  handlebars({
    extname: "hbs",
  })
);
app.set("view engine", "hbs");

app.use(express.static("./public"));

// set a cookie without cookie-parser
app.get("/custom-cookie", (req, res) => {
  if (!req.headers.cookie) {
    res.header({
      "content-type": "text/html",
      "Set-Cookie": "test-cookie=test-value; httpOnly",
    });
  }

  console.log(req.cookies);

  fs.readFile("./views/home.html", { encoding: "utf-8" }).then((htmlResult) => {
    res.send(htmlResult);
  });
});

// set a cookie with cookie-parser
app.get("/cookie", (req, res) => {
  res.cookie("cookie-name", "some-value", {
    httpOnly: true,
    secure: true,
  });

  console.log(req.cookies);

  fs.readFile("./views/home.html", { encoding: "utf-8" }).then((htmlResult) => {
    res.send(htmlResult);
  });
});

// set session with a name
app.get("/set-session/:name", (req, res) => {
  req.session.user = req.params.name;

  res.send(`Set Session with ${req.params.name}!`);
});

// get session name (the session get the name by the cookie that keep inself the sessionId of the name!!!)
app.get("/get-session", (req, res) => {
  console.log(req.session);

  res.send(`Get Session - ${req.session.user}!`);
});

// bcrypt - generate hashed password
app.get("/bcrypt/:password", (req, res) => {
  let password = req.params.password;
  let saltRounds = 8;

  bcript
    .genSalt(saltRounds)
    .then((salt) => {
      return bcript.hash(password, salt);
    })
    .then((hash) => {
      console.log(hash);
      res.send(hash);

      //save hach in json
      passwordHolder.push(hash);
      var filepasswordsDataPath = path.resolve(
        __dirname,
        "./passwordsHolder.json"
      );
      fs.writeFile(
        filepasswordsDataPath,
        JSON.stringify(passwordHolder, null, 4),
        (err) => {
          if (err) {
            return console.log(err);
          }
        }
      );
    });
});

// bcrypt - verify hashed password
app.get("/bcrypt/verify/:password", (req, res) => {
  //let hashedPass = "$2b$08$I6wjZlrR0Pi01ywvkcIypuW2deecsE8eiiRhL52keGjsHjuri5k9a";

  var isVerified = false;
  passwordHolder.forEach((element) => {
    bcript.compare(req.params.password, element).then((result) => {
      console.log(result);
      if (result) {
        isVerified = true;
      }
    });
  });

  res.send("Checked");
  //TODO: dont return the reference from the promisse in then (it's awalays return false )
  console.log("isVerified " + isVerified);
});

// create jwt token
app.get("/token/create/:password", (req, res) => {
  let payload = {
    id: uniqid(),
    name: "gosho",
    password: req.params.password,
  };

  let options = { expiresIn: "1d" };

  let token = jwt.sign(payload, SECRET, options);

  res.cookie("jwt", token);
  res.send(token);
});

// verify jwt token
app.get("/token/verify", (req, res) => {
  let token = req.cookies["jwt"];

  jwt.verify(token, SECRET, (err, payload) => {
    if (err) {
      return res.status(400).send(err);
    }

    res.send(payload);
  });
});

// register GET
app.get("/register", (req, res) => {
  res.render("register");
});

// register POST
app.post("/register", async (req, res) => {
  let { username, password } = req.body;

  try {
    await authService.register(username, password);

    res.redirect("/");
  } catch (error) {
    return res.status(400).send(error);
  }

  res.redirect("/");
});

// login GET
app.get("/login", (req, res) => {
  res.render("login");
});

// login POST
app.post("/login", (req, res) => {
  console.log(req.body);

  let { username, password } = req.body;

  let token = jwt.sign(
    { id: uniqid(), username, password },
    SECRET,
    { expiresIn: "d" },
    (err, token) => {
      if (err) {
        return res.status(400).send(err);
      }

      res.json(payload);
    }
  );

  res.redirect("/");
});

app.listen(
  3000,
  console.log.bind(console, "Server is listening on port 3000...")
);
