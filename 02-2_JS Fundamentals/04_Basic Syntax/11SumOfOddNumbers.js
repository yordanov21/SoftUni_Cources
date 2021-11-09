function solve(number){
    let sum=null;  
    for(let i=1;i<=number*2; i+=2){
        console.log(i);
        sum+=i;
    }

    console.log(`Sum: ${sum}`);
    
}

//solve(5);