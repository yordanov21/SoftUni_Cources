class Request {

    constructor(method, uri, version, message) {
        this.method = method;
        this.uri = uri;
        this.version = version;
        this.message = message;
        this.response = undefined;
        this.fulfilled = false;
    }
}

//Класа представен като функция
function RequestAsObject(method, uri, version, message){

    return{
        method,
        uri,
        version,
        message,
        response: undefined,
        fulfille: false
    }
}

let data = new Request('GET', 'http://google.com', 'HTTP/1.1', '')
console.log(data);
console.log(requestAsObject());

