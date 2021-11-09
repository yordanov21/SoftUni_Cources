function smallesttwoNumbers(arr) {
    arr = arr.map(Number);

    console.log(arr.sort((a,b)=>a-b).slice(0,2).join(" "));
}

smallesttwoNumbers([30,15,50,5]);