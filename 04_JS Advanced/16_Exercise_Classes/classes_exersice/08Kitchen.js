class Kitchen {

    menu;
    productsInStock;
    actionsHistory;
    constructor(budget) {
        this.budget = budget;
    }

    loadProducts(data) {
        let parsedData = data.map(x => x.split(' '))
            .map(([productName, productQuantity, productPrice]) =>
               ( { productName, productQuantity: Number(productQuantity), productPrice: Number(productPrice)}))
    }

} 