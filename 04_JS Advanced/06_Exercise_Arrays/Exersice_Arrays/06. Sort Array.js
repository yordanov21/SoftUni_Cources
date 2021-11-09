function solve(arr) {
   // arr.sort().sort((a, b) => (a.length) - (b.length)).forEach(el => console.log(el));  //и така си работи!
    arr.sort((a, b) => (a.length) - (b.length)||a.localeCompare(b)).forEach(el => console.log(el)); //localeCompare сортира по азбучен ред.
}

solve(['alpha', 
'beta', 
'gamma']
);

solve(['Isacc',
    'Theodor',
    'Jack',
    'Harrison',
    'George']

);

solve(['test',
    'Deny',
    'omen',
    'Default']
);