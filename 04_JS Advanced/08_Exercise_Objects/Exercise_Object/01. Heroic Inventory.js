function main(input = []) {

   return JSON.stringify(input.reduce((acc, heroString, i, arr) => {
    let [heroName, level, items] = heroString.split('/').map(x=>x.trim())
   acc.push({name: heroName, level: Number(level), items: items? items.split(',').map(x=>x.trim()):[] })
   return acc;
 }, [])) 

    // let heroData = [];

    // for (let i = 0; i < input.length; i++) {
    //     let currentHeroArguments = input[i].split(' / ');

    //     let currentHeroName = currentHeroArguments[0];
    //     let currentHeroLevel = Number(currentHeroArguments[1]);
    //     let currentHeroItems = currentHeroArguments[2].split(', ');

    //     let hero = {
    //         name: currentHeroName,
    //         level: currentHeroLevel,
    //         items: currentHeroItems
    //     };

    //     heroData.push(hero);
    // }

    // console.log(JSON.stringify(heroData));

}

console.log(main(['Isacc / 25 / Apple, GravityGun',
'Derek / 12 / BarrelVest, DestructionSword',
'Hes / 1 / Desolator, Sentinel, Antara']
));
 