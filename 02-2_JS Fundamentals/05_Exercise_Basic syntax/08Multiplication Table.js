function multiplicationTable(number){
    
    //{number} X {times} = {product}
  for(let times=1; times<=10;times++){

    console.log(`${number} X ${times} = ${number*times}`);   
  }
}

multiplicationTable(10);