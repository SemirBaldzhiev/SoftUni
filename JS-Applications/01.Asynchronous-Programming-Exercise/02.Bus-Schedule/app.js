function solve() {
    let baseUrl = 'http://localhost:3030/jsonstore/bus/schedule';
    let info = document.querySelector('.info');
    let departButton = document.getElementById('depart');
    let arriveButton = document.getElementById('arrive');
    
    let currId = 'depot';
    let currStopName = '';

    function depart() {
        fetch(`${baseUrl}/${currId}`)
            .then(res => res.json())
            .then(stop => {
                currStopName = stop.name;
                info.textContent = `Next stop ${currStopName}`;
                currId = stop.next;
            });

        departButton.setAttribute('disabled', 'true');
        arriveButton.disabled = false;
    }

    function arrive() {
        info.textContent = `Arriving at ${currStopName}`;
        departButton.disabled = false;
        arriveButton.disabled = true;;
    }

    return {
        depart,
        arrive
    };
}

let result = solve();