function getInfo() {
    const stopIdInput = document.getElementById('stopId')
    const stopNameDiv = document.getElementById('stopName') 
    const busContainer = document.getElementById('buses')

    const busesUrl = `https://judgetests.firebaseio.com/businfo/${stopIdInput.value}.json`

    stopNameDiv.textContent = ''
    busContainer.innerHTML = ''

    fetch(busesUrl)
    .then(response => response.json())
    .then(data => {
        const {name, buses} = data
        stopNameDiv.textContent = name
        Object.entries(buses)
        .forEach(([busId, busTime]) => {
           const li = document.createElement('li')
           li.textContent = `Bus ${busId} arrives in ${busTime} minutes`
           
           busContainer.appendChild(li)
        });
    })
    .catch((error) => {
        stopNameDiv.textContent = 'Error'
    })
}