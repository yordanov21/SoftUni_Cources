function solve() {

    let information = document.getElementsByClassName("info")[0];
    let buttonDepart = document.getElementById("depart");
    let buttonArrive = document.getElementById("arrive");

    let currentId = 'depot';

    function depart() {

        fetch(`https://judgetests.firebaseio.com/schedule/${currentId}.json`)
            .then(x => x.json())
            .then((data) => {
                information.innerHTML = `Next stop ${data.name}`;
                buttonDepart.disabled = true;
                buttonArrive.disabled = false;
            })
            .catch(() => {
                buttonDepart.disabled = false;
                buttonArrive.disabled = false;
                information.innerHTML = "Error"
            });
    }

    function arrive() {
        fetch(`https://judgetests.firebaseio.com/schedule/${currentId}.json`)
            .then(x => x.json())
            .then((data) => {
                information.innerHTML = `Arriving at ${data.name}`;
                buttonDepart.disabled = false;
                buttonArrive.disabled = true;
                currentId = data.next;
            })
            .catch(() => {
                buttonDepart.disabled = false;
                buttonArrive.disabled = false;
                information.innerHTML = "Error"
            });
    }

    return {
        depart,
        arrive
    };
}

let result = solve();