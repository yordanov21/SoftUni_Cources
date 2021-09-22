const fs = require('fs');
const fspromis = require('fs/promises');

//1. Synchronous variant. It's not a good idea. It's block the program, until the operation is completed.
//let text = fs.readFileSync('./index.html', 'utf8');
//console.log(text);

//2. Asynchronous variant. It's not block the program
fs.readFile('./index.html', 'utf8', (err, text) => {
    if (err) {
        console.log(err)
    }

    console.log(text);
})

//3. Promises
fspromis.readFile('./index.html', 'utf8')
    .then(text => {
        console.log(text);
    });


//4. Async function
async function readFile(path) {
    let text = await fs.readFile(path, 'utf8');

    console.log(text);
};
readFile('./index.html');


console.log('***** END *****');


// Promisses may be better from all