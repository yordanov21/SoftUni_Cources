function solve() {


    let currentStopId = '';
    let nextStopId = 'depot';
    let info = document.getElementById('info');
    let departBtn = document.getElementById('depart');
    let arriveBtn = document.getElementById('arrive');


    function depart() {

        currentStopId = nextStopId;

        fetch(`https://judgetests.firebaseio.com/schedule/${nextStopId}.json`)
            .then(x => x.json())
            .then(x => {
                if (x !== null) {
                    nextStopId = x.next;
                    info.innerText = `Next stop ${x.name}`;
                    console.log(x, currentStopId, nextStopId);
                }else{
                    throw 'Error';
                }
            }).catch(x => {
                info.innerText = x;
                departBtn.disabled = true;
                arriveBtn.disabled = true;
            })


        departBtn.disabled = 'true';
        arriveBtn.removeAttribute('disabled');
    }

    function arrive() {
        fetch(`https://judgetests.firebaseio.com/schedule/${currentStopId}.json`)
            .then(x => x.json())
            .then(x => {
                if (x !== null) {
                    nextStopId = x.next;
                    info.innerText = `Arriving at ${x.name}`;
                    console.log(x, currentStopId, nextStopId);
                }else{
                    throw 'Error';
                }
            }).catch(x => {
                info.innerText = x;
                departBtn.disabled = true;
                arriveBtn.disabled = true;
            })

        arriveBtn.disabled = 'true';
        departBtn.removeAttribute('disabled');
    }

    return {
        depart,
        arrive
    };
}

let result = solve();