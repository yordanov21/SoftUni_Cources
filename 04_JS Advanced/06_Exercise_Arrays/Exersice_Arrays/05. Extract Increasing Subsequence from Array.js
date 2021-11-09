function solve(input){

    let output=input.reduce((acc,currElement)=>{

        const lastElement=acc[acc.length-1];
        if(currElement>=lastElement||lastElement===undefined){
            acc.push(currElement);
        }

        return acc;
    },[]);

    console.log(output.join('\n'));
    
}

solve([1,3,8,4,10,12,3,2,24]);
solve([1,2,3,4]);
solve([20,3,2,15,6,1])