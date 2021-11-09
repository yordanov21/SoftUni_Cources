function solve(number){

    
    for(let i=1; i<=number; i++){

        let currentNuber=i;
        let sum=0;
        while(currentNuber!=0){
            sum+=currentNuber%10;
            currentNuber=parseInt( currentNuber/10);
        }  
        
        if(sum==5|| sum==7|| sum==11){

            console.log(`${i} -> True`);
            
        } else{
            console.log(`${i} -> False`);
            
        }
    }
}

solve(15);