function solve(arr) {
    let resultarr = [];
    let count = 0;
    for (let i = 0; i <= arr.length; i++) {
        count++
        if (arr[i] == 'add') {

            resultarr.push(count);
        } else if (arr[i] == ['remove']) {
            resultarr.pop();
        }
    }

    // resultarr.length == 0 ? console.log('Empty') : resultarr.forEach(element => {
    //     console.log(element);
    //});
console.log(resultarr.length>0? resultarr.join('\n'): 'Empty'); 
}

// solve(['add', 
// 'add', 
// 'add', 
// 'add']
// );

solve(['add',
    'add',
    'remove',
    'add',
    'add']
);

solve(['remove',
    'remove',
    'remove']
);