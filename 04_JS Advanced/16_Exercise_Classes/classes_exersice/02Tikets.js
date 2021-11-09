function solve(input = [], inputString) {
    let tickets = [];
    input.forEach(element => {
        let token = element.split("|")

        // Ticket { destination: 'Boston',
        // price: 126.20,
        // status: 'departed' }, 

        class Ticket {
            constructor(destination, price, status) {
                this.destination = destination;
                this.price = +price;
                this.status = status;
            }
        }
        let ticket = new Ticket(token[0], token[1], token[2])
        tickets.push(ticket);
    })
//sortirane na masiva
    tickets.sort((a,b) => {
        if(typeof a[inputString] === 'string'){
            return a[inputString].localeCompare(b[inputString]);
        }
        else {
            return a[inputString] - b[inputString];
        }
    })
   return tickets;
}


solve(['Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'],
    'destination') 
