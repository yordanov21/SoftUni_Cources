function solve(a, b) {
let outputNumbers="";
    let sum=0;
    for (let i = a; i <= b; i++) {
      outputNumbers+=`${i} `;
        sum+=i;
    }

    console.log(outputNumbers);
    console.log(`Sum: ${sum}`);
}

solve(0,9);
