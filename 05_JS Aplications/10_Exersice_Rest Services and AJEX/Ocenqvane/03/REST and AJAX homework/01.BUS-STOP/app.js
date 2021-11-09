function getInfo() {

    let busId = document.getElementById('stopId').value.trim();

    let stopName = document.getElementById('stopName');
    let allBuses = document.getElementById('buses');

    
    //The webhost will respond with valid data to IDs 1287, 1308, 1327 and 2334.
    
    fetch(`https://judgetests.firebaseio.com/businfo/${Number(busId)}.json`)
    .then(x => x.json())
    .then(x => {
        if(x.name && x.buses){
            
            //checks if wanted bus info is already displayed
            if(x.name == stopName.innerText) return;
            
            //cleans previous info
            allBuses.innerHTML = '';
            
            //displays info
            stopName.innerText = x.name;
            let buses = Object.entries(x.buses).forEach(bus => {
                let newLi = document.createElement('li');
                newLi.innerText = `Bus ${bus[0]} arrives in ${bus[1]} minutes`;
                allBuses.appendChild(newLi);
            })
        }else{
            //displays error and cleans previous info
            stopName.innerText = 'Error';
            allBuses.innerHTML = '';
        }
    })
}