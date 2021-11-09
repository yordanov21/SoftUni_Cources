function leapYear(year) {

    if (year % 4 == 0 && year % 100 != 0) {

        console.log('yes');

    } else if (year % 400 == 0) {

        console.log('yes');

    } else {
        console.log('no');

    }
}

leapYear(2000);
leapYear(400);
leapYear(4);
leapYear(2003);
