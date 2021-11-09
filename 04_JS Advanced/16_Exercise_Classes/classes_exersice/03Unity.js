class Rat {
    rats = [];
    constructor(name) {
        this.name = name
    }

    unite(otherRat) {
        if (otherRat instanceof Rat) {
            this.rats.push(otherRat)
        }
    }

    getRats() {
       return this.rats;
    }

    toString() {
        return this.name+this.rats.map(rat=> `\n##${rat.name}`).join("")
        // console.log(this.name);
        // this.rats.map(rat=>{
        //     console.log(`##${rat.name}`);
        // })
    }
}



let firstRat = new Rat("Peter");
console.log(firstRat.toString()); // Peter

console.log(firstRat.getRats()); // []

firstRat.unite(new Rat("George"));
firstRat.unite(new Rat("Alex"));
console.log(firstRat.getRats());
// [ Rat { name: 'George', unitedRats: [] },
//  Rat { name: 'Alex', unitedRats: [] } ]

console.log(firstRat.toString());
// Peter
// ##George
// ##Alex
