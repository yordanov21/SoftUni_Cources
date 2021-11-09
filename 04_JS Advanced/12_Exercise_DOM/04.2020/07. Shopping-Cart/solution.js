function solve() {
    let shopingCard = document.querySelector('.shopping-cart');
    let textArea = document.querySelector("textarea");
    let totalPrice = 0;
    let list = [];
    //addBtn=document.querySelectorAll('.add-product');
    price = document.querySelectorAll('.product-line-price');

    shopingCard.addEventListener('click', (e) => {

        if (e.target.className === 'add-product') {

            let parentBtn = e.target.parentNode;
            let parentProduct = parentBtn.parentNode;
            let price = parentProduct.lastElementChild.textContent;
            let productDetails = parentBtn.previousElementSibling;
            let productName = productDetails.firstElementChild.textContent;

            //Show on the console
            console.log(parentBtn);
            console.log(price);
            console.log(productName);
            totalPrice += +price
            list.push(productName)
            textArea.textContent += `Added ${productName} for ${price} to the cart.\n`
        }
    })

    let checkOutBtn = document.querySelector('.checkout');

    checkOutBtn.addEventListener('click', (e) => {
        list = list.filter((item, index) => list.indexOf(item) === index);
        textArea.textContent += `You bought ${list.join(", ")} for ${totalPrice.toFixed(2)}.`
        let btns = document.querySelectorAll('.add-product');
        btns.forEach(element => {
            element.disabled = true;
            checkOutBtn.disabled = true;
        });
        console.log('chekout');

    })

}