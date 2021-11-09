export const dataBase = (apiKey, collectionName) => {

    const getAllData = () => {
        return fetch(`${apiKey}${collectionName}.json`).then(x => x.json());
    };

    const putData = (obj) => {
        return fetch(`${apiKey}${collectionName}.json`, {
            method: "POST",
            body: JSON.stringify(obj)
        });    
    };

    return {
        getAllData, putData
    };
};