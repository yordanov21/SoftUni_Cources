function timeToWalk(steps, footLength, studentSpeed) {

    let metersToUniversity = steps * footLength;
    let minuteBreak = Math.floor(metersToUniversity / 500);
    let hoursToWalk = metersToUniversity / studentSpeed / 1000;
    let allminutes = hoursToWalk*60 + minuteBreak;
let allseconds=Math.round(allminutes*60);
let seconds=allseconds%60;
let finalminutes=parseInt(allseconds/60);
let minutes= finalminutes/60;
let finalHours=parseInt(minutes%60);

let result=new Date(null, null,null,null, null, allseconds)
console.log(result.toTimeString().split(' ')[0]);


//console.log((finalHours < 10 ? "0" : "") + finalHours + ":" + (finalminutes < 10 ? "0" : "") + (finalminutes) + ":" + (seconds < 10 ? "0" : "") + seconds);
}

timeToWalk(4000, 0.60, 5);
timeToWalk(2564,0.70,5.5);