function solve(arr = []) {
    // arr = arr.reverse()
    let arrObjects = [];
    arr.forEach(element => {
        let obj = {
            width: element[0],
            height: element[1],
            area: () => {
                return this.whidth * this.height
            },
            compareTo: function(other) {
                if (this.area() < other.area()) {
                    return -1
                } else if (this.area() === other.area()) {
                    return 0;
                } else {
                    return 1;
                }
            }
        }
        arrObjects.push(obj)
    });

    return arrObjects.sort((a, b) => b.compareTo(a) === 0 ? b.width - a.width : b.compareTo(a));

}

console.log(solve([
    [10, 5],
    [5, 12]
]));

console.log(solve([
    [1, 1],
    [15, 1],
    [1, 1],
    [1, 15],
    [7, 7],
    [25, 3],
    [13, 3],
    [15, 5]
]));