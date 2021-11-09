let stopId = document.getElementById("stopId");
let stopName = document.getElementById("stopName");
let buses = document.getElementById("buses");
let fragment = document.createDocumentFragment();


function getInfo() {

    fetch("https://bus-stop-db.firebaseio.com/businfo/.json")
        .then(x => x.json())
        .then(x => {
            let valueToAppend = x[stopId.value];

            console.log(valueToAppend);

            if (!valueToAppend) {
                stopName.innerHTML = "Error";
                buses.innerHTML = "";

            }
            stopName.innerHTML = valueToAppend.name;

            Object.entries(valueToAppend.buses)
                .forEach(([busId, time]) => {
                    let li = document.createElement("li");
                    li.innerHTML = `Bus ${busId} arrives in ${time} minutes`;
                    fragment.appendChild(li);
                });
            buses.innerHTML = "";
            buses.appendChild(fragment);

        })
}