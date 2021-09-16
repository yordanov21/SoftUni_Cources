const http = require('http');

let app = http.createServer((req, res) => {

    console.log(req.method);

    res.write('hello Node.js :)');
    res.end();
});

app.listen(8000);

console.log("Node.js Server is running on port 8000...");