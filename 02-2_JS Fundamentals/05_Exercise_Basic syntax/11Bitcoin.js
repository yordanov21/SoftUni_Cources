function mininngGold(goldArray) {

    const goldCourse = 67.51;
    const bitcoinCourse = 11949.16;

    let gold = 0;
    let bitcoins = 0;
    let dayPutchasedBitcoin = 0;

    let leva = 0;

    for (i = 0; i < goldArray.length; i++) {

        gold = goldArray[i];
        if ((i+1) % 3 == 0) {

            gold *= 0.7;
        }

        leva += gold * goldCourse;

        if (leva >= bitcoinCourse && dayPutchasedBitcoin == 0) {

            dayPutchasedBitcoin = i+1;
        }

        while (leva >= bitcoinCourse) {

            bitcoins++;
            leva -= 11949.16;
        }
    }

    console.log(`Bought bitcoins: ${bitcoins}`);
    if(dayPutchasedBitcoin>0){

        console.log(`Day of the first purchased bitcoin: ${dayPutchasedBitcoin}`);  
    }

    console.log(`Left money: ${leva.toFixed(2)} lv.`);
}

mininngGold([100,200,300]);
mininngGold([50,100]);
mininngGold([3124.15, 504.212, 2511.124]);