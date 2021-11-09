const catches=function(){
    const baseURL='https://fisher-game.firebaseio.com/catches';

    const get=(data)=>{
        return fetch(baseURL+'.json').then((r)=>r.json());
    }

    const post=(data)=>{
        return fetch(baseURL+'.json',{
            method: 'POST',
            body: JSON.stringify(data),
            headers:{
                'Content-Type': 'application/json'
            }
        }).then((r)=>r.json());
    }

    const del=(id)=>{
        return fetch(baseURL+`${id}.json`,{
            method: 'DELETE'
        }).catch(console.error)
    }

    const put=(data)=>{
        return fetch(baseURL+`${id}.json`,{
            method: 'PUT',
            body: JSON.stringify(data),
            headets:{
                'Content-Type':'application/json'
            }
        })
    }

    return{
        get,
        post,
        del,
        put
    }
}()