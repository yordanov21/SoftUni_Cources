function solve(n, k) {

    let resultArr = [];
    for (i = 1; i <= n; i++) {
        resultArr.push(1);
    }
    for (j = 2; j < resultArr.length; j++) {
        let num = 0;
        for (d = 1; d <= k; d++) {
            let currentnum = (resultArr[j - d] == undefined ? 0 : resultArr[j - d]);

            num += currentnum;

        }

        resultArr = resultArr.fill(num, j, j + 1);
    }
    return resultArr.join(' ');
}

console.log(solve(8, 2));
console.log(solve(6, 3));

