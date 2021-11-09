class Stringer {
    innerString; //пропъртитата може да ги дефинираме директно в конструктора и те ще се закачат към класа, т.е. това може да го пропуснем.
    innerLength; //пропъртитата може да ги дефинираме директно в конструктора и те ще се закачат към класа, т.е. това може да го пропуснем.

    constructor(stringValue, length) {
        this.innerString = stringValue;
        this.innerLength = length;
    }

    increase(lengthIncrease) {
        this.innerLength += lengthIncrease;
    }

    decrease(lengthDecrease) {
        this.innerLength = this.innerLength - lengthDecrease > 0 ? this.innerLength - lengthDecrease : 0;
    }

    toString() {
        if (this.innerLength === 0) {
            return '...'
        }

        return this.innerString.slice(0, this.innerLength) + ((this.innerLength >= this.innerString.length) ? '' : '...')
    }
}


let test = new Stringer("Test", 5);
console.log(test.toString()); // Test

test.decrease(3);
console.log(test.toString()); // Te...

test.decrease(5);
console.log(test.toString()); // ...

test.increase(4);
console.log(test.toString()); // Test
