function solve(tickets, orderCriteria){
    class Ticket{
        constructor(destination, price, status){
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }

    let criterias = {
        destination: (a, b) => a.destination.localeCompare(b.destination),
        price: (a, b) => a - b,
        status: (a, b) => a.status.localeCompare(b.status),
    }
    let result = [];

    for (const ticket of tickets) {
        let [destination, price, status] = ticket.split('|');

        price = Number(price);
        let ticketToAdd = new Ticket(destination, price, status);
        result.push(ticketToAdd);
    }

    result = result.sort(criterias[orderCriteria]);

    return result;
}

console.log(solve(['Philadelphia|94.20|available',
'New York City|95.99|available',
'New York City|95.99|sold',
'Boston|126.20|departed'],
'destination'
));

console.log(solve(['Philadelphia|94.20|available',
'New York City|95.99|available',
'New York City|95.99|sold',
'Boston|126.20|departed'],
'status'
));