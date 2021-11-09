function solve(arr = []) {

    let output = [];
    arr.forEach(element => {
        const [command, item] = element.split(" ");
        if (command === 'add') {
            output.push(item);
        } else if (command === 'remove') {
            output = output.filter(x => x !== item);
        } else {
            console.log(output.join(","));
        }
    });
}

solve(['add hello', 'add again', 'remove hello', 'add again', 'print']);
solve(['add pesho', 'add george', 'add peter', 'remove peter', 'print']);
solve(['add peter', 'add george', 'add peter', 'remove peter', 'print']);