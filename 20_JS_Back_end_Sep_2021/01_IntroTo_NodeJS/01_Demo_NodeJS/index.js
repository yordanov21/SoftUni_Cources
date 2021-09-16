// third party module
const uniqid = require('uniqid');

//Core module
const url = require('url');

//Local module
const utils = require('./utils.js');

// to use ES6 module, change "type" to be a module in package.json file
//import utils from './utils.js'


console.log('Hello world!!!')

console.log(uniqid());

console.log(utils.sum(2, 10));
console.log(utils.div(20, 5));


const sftuniUrl = 'https://stackoverflow.com/questions/8668174/indexof-method-in-an-object-array';

let parseUrl = url.parse(sftuniUrl);

console.log(parseUrl);