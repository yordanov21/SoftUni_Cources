function vacation(a, b ,c){
    let people = parseFloat(a);
    let kind = b;
    let day = c;
 
        let price = 0;
 
        if(day === "Friday" && kind === "Students"){
            price = people * 8.45;
        }
        else if (day === "Friday" && kind === "Business"){
            price = people * 10.90;
        }
        else if (day === "Friday" && kind === "Regular"){
            price = people * 15;
        }
 
 
        else if(day === "Saturday" && kind === "Students"){
            price = people * 9.80;
        }
        else if (day === "Saturday" && kind === "Business"){
            price = people * 15.60;
        }
        else if (day === "Saturday" && kind === "Regular"){
            price = people * 20;
        }
 
       
        else if(day === "Sunday" && kind === "Students"){
            price = people * 10.46;
        }
        else if (day === "Sunday" && kind === "Business"){
            price = people * 16;
        }
        else if (day === "Sunday" && kind === "Regular"){
            price = people * 22.50;
        }
 
 
       if (people >= 30 && kind === "Students"){
            price = price - 0.15 * price;
        }
        else if (people >= 100 && kind === "Business"){
            price = price - (price / people * 10);
        }
       else  if (people >= 10 && people <= 20 && kind === "Regular"){
            price = price - 0.05 * price;
        }
 
       
       console.log('Total price: ' + price.toFixed(2));
}

vacation(30,
    "Students",
    "Sunday"
    );