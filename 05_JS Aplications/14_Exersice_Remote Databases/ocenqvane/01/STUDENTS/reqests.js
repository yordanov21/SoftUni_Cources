export const getRequest =async (url , appName,endPoint) =>{
    try {
        return await (await fetch(`${url}${appName}${endPoint}`)).json();
    } catch (error) {
        console.log(`Error:${error.code}`)
    };
};

export const postRequest = async (url , appName,endPoint , body) =>{
    return await fetch(`${url}${appName}${endPoint}`,{
        method:'POST',
        body:JSON.stringify(body)
    });
};