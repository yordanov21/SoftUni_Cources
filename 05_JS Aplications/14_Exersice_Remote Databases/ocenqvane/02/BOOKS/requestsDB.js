

function handleError(e) {
    if (!e.ok) {
        throw new Error(e.statusText);
    }

    return e;
}

function makeHeaders(httpMethod, bookObj) {
    let header = {
        method: httpMethod,
        headers: {
            "Content-Type": "application/json"
        }
    };

    if (httpMethod === "POST" || httpMethod === "PUT") {
        header["body"] = JSON.stringify(bookObj);
    }

    return header;
}

function createPromise(link, header) {

    return fetch(link, header).then(handleError).then(r => r.json());
}




export function getData(url, collectionName) {
    let link = `${url}${collectionName}.json`;
    let header = makeHeaders("GET");

    return createPromise(link, header);
};

export function getSingleData(url, collectionName, id) {
    let link = `${url}${collectionName}/${id}.json`;
    let header = makeHeaders("GET");

    return createPromise(link, header);
};

export function createBook(url, collectionName, bookObj) {
    let link = `${url}${collectionName}.json`;
    let header = makeHeaders("POST", bookObj);

    return createPromise(link, header);
};

export function updateBook(url, collectionName, id, bookObj) {
    let link = `${url}${collectionName}/${id}.json`;
    let header = makeHeaders("PUT", bookObj);

    return createPromise(link, header);
};

export function deleteBook(url, collectionName, id) {
    let link = `${url}${collectionName}/${id}.json`;
    let header = makeHeaders("DELETE");

    return createPromise(link, header);
}





