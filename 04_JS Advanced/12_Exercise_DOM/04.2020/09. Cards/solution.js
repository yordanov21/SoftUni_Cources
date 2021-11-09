function solve() {
    let cards = document.querySelector('.cards');
    let history = document.querySelector("#history");

    let clickCount = 0;
    let playerOneCard;
    let playerTwoCard;
    cards.addEventListener('click', (e) => {

        let result = document.querySelector("#result");
        if (clickCount === 0) {
            result.innerHTML = ` 
         <span></span>
         <span>vs</span>
         <span></span>`;
        }
        if (e.target.name) {
            console.log(e.target.name);
            e.target.src = "images/whiteCard.jpg"


            if (e.target.parentNode.id === 'player1Div') {

                let playerOne = result.firstElementChild;
                playerOne.textContent = e.target.name;
                playerOneCard = e.target;
                console.log(playerOneCard);
                clickCount++;
            } else {
                let playerTwo = result.lastElementChild
                playerTwo.textContent = e.target.name;
                playerTwoCard = e.target;
                console.log(playerTwoCard);
                clickCount++;
            }

            if (clickCount === 2) {

                console.log(playerOneCard);
                console.log(playerTwoCard);

                if (playerOneCard.name > playerTwoCard.name) {
                    playerOneCard.style.border = "2px solid green";
                    playerTwoCard.style.border = '2px solid red';
                    playerOneCard.style.borderRadius = '10px';
                    playerTwoCard.style.borderRadius = '10px';
                } else {
                    playerTwoCard.style.border = "2px solid green";
                    playerOneCard.style.border = '2px solid red';
                    playerOneCard.style.borderRadius = '10px';
                    playerTwoCard.style.borderRadius = '10px';
                }

                history.textContent += `[${result.textContent}]`;

                clickCount = 0;
                playerOneCard;
                playerTwoCard;
            }

        }
    })
}