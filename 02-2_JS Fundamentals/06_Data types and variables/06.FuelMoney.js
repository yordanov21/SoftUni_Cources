function solve(distance, passengers, pricePerLitterFuel){
  
    let consumptionPer100km=(distance/100)*7;
    consumptionPer100km+=0.100*passengers;
    let neededMoney=consumptionPer100km*pricePerLitterFuel;
    console.log(`Needed money for that trip is ${neededMoney}lv.`);  
}

solve(260,9,2.49);
solve(90,14,2.88);