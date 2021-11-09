function login(inputArray) {

   const userName=inputArray[0];
    let count = 0;

    function reverseString (word) {
      const reversedString=  word.split("").reverse().join("");
        return reversedString;
    }

    for (let i=1;i<inputArray.length;i++) {
 
        count++;
        let reversedString=reverseString(inputArray[i])
        if (userName ==reversedString ) {

            console.log(`User ${userName} logged in.`);
            break;
        } else if (count==4){
            console.log(`User ${userName} blocked!`);
            break;
           
        } else{

            console.log("Incorrect password. Try again.");
        }

       
    }
}

login(['Acer','login','go','let me in','recA']);
login(['momo','omom']);