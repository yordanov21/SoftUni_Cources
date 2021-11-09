function solve(arr){
    let delimiter=arr[arr.length-1];
    arr.pop();
    return arr.join(delimiter);
}

console.log(solve(['One', 
'Two', 
'Three', 
'Four', 
'Five', 
'-']
));
