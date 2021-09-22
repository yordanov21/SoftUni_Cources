const fs = require('fs');

// readableStream keep referention to index.html file
const readableStream = fs.createReadStream('./index.html', {
    encoding: 'utf8',
    highWaterMark: 1024 // represent the buffer size, the default bufer size is 65 536
});

const writableStream = fs.createWriteStream('outout.cfg')


readableStream.on('data', function(chunk) {

    console.log('************************************************');
    console.log('************************************************');
    console.log('************************************************');
    console.log('NEW CHUNK');
    console.log('************************************************');
    console.log('************************************************');
    console.log('************************************************');

    console.log(chunk);

    writableStream.write(chunk);
});

readableStream.on('end', () => {
    console.log('Stream End!');

    writableStream.end();
})

writableStream.on('drain', (chunk) => {
    console.log(chunk);
});

writableStream.on('finish', () => {
    console.log('Stream is finished');
});