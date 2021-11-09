let depart = document.getElementById("depart");
let arrive = document.getElementById("arrive");
let stopName = document.getElementById("info");
depart.addEventListener("click", printOnScreen);
arrive.addEventListener("click", printOnScreen);
let stopsArr = [];

function getData() {

    fetch("https://bus-schedule-3c791.firebaseio.com/schedule/.json")
        .then(x => x.json())
        .then(x => {
            let stopsArr = extractData(x);
        });
}

function extractData(x) {
    let next = Object.entries(x).map(x => Object.values(x)[0])[0];
    for (let busSheduleKey in x) {
        let currStop = Object.entries(x).filter(x => Object.values(x)[0] === next)[0][1].name;
        next = Object.entries(x).filter(x => Object.values(x)[0] === next)[0][1].next;
        stopsArr.push(currStop);
    }
    return stopsArr;
}

function printOnScreen(e) {
    e.preventDefault();

    let temp = stopsArr.shift();

    if (depart.disabled === false) {
        stopName.innerHTML = `Next stop ${temp}`;
        depart.disabled = true;
        arrive.disabled = false;
        stopsArr.push(temp);
    }else{
        stopName.innerHTML = `Arriving at ${temp}`;
        depart.disabled = false;
        arrive.disabled = true;
        stopsArr.push(temp);
    }
}

let result = getData();