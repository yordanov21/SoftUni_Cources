class Bank {

    constructor(bankName) {
        this._bankName = bankName;
        this._allCustomers = [];
    }


    newCustomer({ firstName, lastName, personalId }) {

        const customer = this._allCustomers.find(c => c.personalId === personalId);

        if (customer) {
            throw new Error(`${firstName} ${lastName} is already our customer!`);
        }

        let newCustomer = {
            firstName,
            lastName,
            personalId,
            totalMoney: 0,
            transactions: []
        };
        this._allCustomers.push(newCustomer);
        return newCustomer;
    }

    depositMoney(personalId, amount) {
        const customer = this._allCustomers.find(c => c.personalId === personalId);

        if (!customer) {
            throw new Error('We have no customer with this ID!');
        }


        customer.totalMoney += amount;
        customer.transactions.push(`${customer.firstName} ${customer.lastName} made deposit of ${amount}$!`);
        return `${customer.totalMoney}$`;

    }

    withdrawMoney(personalId, amount) {
        const customer = this._allCustomers.find(c => c.personalId === personalId);

        if (!customer) {
            throw new Error('We have no customer with this ID!');
        }

        if (customer.totalMoney < amount) {
            throw new Error(`${customer.firstName} ${customer.lastName} does not have enough money to withdraw that amount!`);
        }

        customer.totalMoney -= amount;
        customer.transactions.push(`${customer.firstName} ${customer.lastName} withdrew ${amount}$!`);

        return `${customer.totalMoney}$`;
    }

    customerInfo(personalId) {

        const customer = this._allCustomers.find(c => c.personalId === personalId);

        if (!customer) {
            throw new Error('We have no customer with this ID!');
        }

        let result = "";
        result += `Bank name: ${this._bankName}\n`;

        let index = customer.transactions.length;
        result += `Customer name: ${customer.firstName} ${customer.lastName}\n`;
        result += `Customer ID: ${customer.personalId}\n`;
        result += `Total Money: ${customer.totalMoney}$\n`;
        result += 'Transactions:\n'

        for (const transaction of customer.transactions.reverse()) {
            result += `${index}. ${transaction}\n`;
            index--;
        }

        return result.trim();

    }
}

let bank = new Bank('SoftUni Bank');

console.log(bank.newCustomer({ firstName: 'Svetlin', lastName: 'Nakov', personalId: 6233267 }));
console.log(bank.newCustomer({ firstName: 'Mihaela', lastName: 'Mileva', personalId: 4151596 }));

bank.depositMoney(6233267, 250);
console.log(bank.depositMoney(6233267, 250));
bank.depositMoney(4151596, 555);

console.log(bank.withdrawMoney(6233267, 125));

console.log(bank.customerInfo(6233267));