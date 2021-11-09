function squareStars(count){

    if(count===undefined){

        for(i=1; i<=5; i++){

            console.log("* ".repeat(5));
        }
     
    } else{

        for(i=1; i<=count; i++){

            console.log("* ".repeat(count));
        }
    }

}

squareStars();
squareStars(1);
squareStars(2);
squareStars(5);