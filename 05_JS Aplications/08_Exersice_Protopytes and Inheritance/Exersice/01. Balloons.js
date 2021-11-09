function solve() {
    class Balloon {
        constructor(color, gasWeight) {
            this.color = color;
            this.gasWeight = gasWeight;
        }
    }

    class PartyBalloon extends Balloon {
        constructor(color, gasWeight, ribbonColor, ribbonLenght) {
                super(color, gasWeight);
                this._ribbon = {
                    color: ribbonColor,
                    length: ribbonLenght
                }
            }
            //slaga se _ za da nqma rekursia
        get ribbon() {
            return this._ribbon;
        }
    }

    class BirthdayBalloon extends PartyBalloon {
        constructor(color, gasWeight, ribbonColor, ribbonLenght, text) {
            super(color, gasWeight, ribbonColor, ribbonLenght);
            this._text = text
        }

        get text() {
            return this._text
        }
    }

    return {
        Balloon: Balloon,
        PartyBalloon: PartyBalloon,
        BirthdayBalloon: BirthdayBalloon
    }

}



// expect(ribbon.length).to.be.equal(10.25,
//             "'PartyBalloon ribbon length' does not return correct results");
console.log(solve());