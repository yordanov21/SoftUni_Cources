function solve() {

    const infoSpan = document.getElementsByClassName('info')[0]
    const arriveButton = document.getElementById('arrive')
    const departButton = document.getElementById('depart')

    let currentId ='depot'
    let currentName
    
    function depart() {
        fetch(`https://judgetests.firebaseio.com/schedule/${currentId}.json`)
        .then(res => res.json())
        .then(departing)
        
    }

    function arrive() {
        infoSpan.textContent = `Arriving at ${currentName}`
        arriveButton.disabled = true
        departButton.disabled = false
    }

    function departing(data){
        const {name, next} = data

        currentId = next
        currentName = name

        arriveButton.disabled = false
        departButton.disabled = true

        infoSpan.textContent = `Next stop ${currentName}`
    }

    return {
        depart,
        arrive
    };
}

let result = solve();