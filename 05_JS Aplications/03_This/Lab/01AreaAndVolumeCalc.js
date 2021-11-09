function area() {
    return this.x * this.y;
}

function vol() {
    return this.x * this.y * this.z;
}

function solve(area, vol, input) {
    let objects = JSON.parse(input);
    let result = [];
    objects.forEach(element => {
        let areaObj = Math.abs(area.call(element));
        let volumeObj = Math.abs(vol.call(element));
        return result.push({ area: areaObj, volume: volumeObj })
    });

    return result;
}
//може да се напише и така:
// function solve(area, vol, input) {
//     let objects = JSON.parse(input);
//     function calc(obj) {
//       let areaObj = Math.abs(area.call(obj));
//       let volumeObj = Math.abs(vol.call(obj));
//       return { area: areaObj, volume: volumeObj }
//     }
//     return objects.map(calc);
//   }


console.log(solve(area, vol, '[{"x":"1","y":"2","z":"10"},{"x":"7","y":"7","z":"10"},{"x":"5","y":"2","z":"10"}]'));