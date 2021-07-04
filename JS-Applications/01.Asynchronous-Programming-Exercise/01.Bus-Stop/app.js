function getInfo() {
    let baseUrl  = 'http://localhost:3030/jsonstore/bus/businfo';
    let stopId = document.getElementById('stopId').value;
   
    let ulElement = document.getElementById('buses');
    let divElement = document.getElementById('stopName');

    clearBusesList(ulElement);

    fetch(`${baseUrl}/${stopId}`)
        .then(res => res.json())
        .then(data => {
            
            divElement.textContent = data.name;

            let buses = Object.entries(data.buses);
            console.log(buses);

            buses.forEach(bus => {
                let liElement = document.createElement('li');
                liElement.textContent = `Bus ${bus[0]} arrives in ${bus[1]} minutes`;
                ulElement.appendChild(liElement);
            })

        })
        .catch(error => {
            divElement.textContent = 'Error';
        });
}

function clearBusesList(parent){
    while(parent.firstChild){
        parent.removeChild(parent.firstChild);
    }
}