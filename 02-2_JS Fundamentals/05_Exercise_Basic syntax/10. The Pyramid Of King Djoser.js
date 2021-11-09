function calculatePyramid(base, increment) {

    let heigth = increment;

    let stoneCount = 0;
    let marblesCount = 0;
    let lapisLazulisCount = 0;
    let goldCount = 0;
    let pyramideHeight = 0;

    for (i = base; i >= 1; i -= 2) {

        pyramideHeight++;
        if (i > 2) {

            stoneCount += ((i - 2) * (i - 2))
        }
        if (i == 1) {
            goldCount++;
            break;
        }
        if (i == 2) {
            goldCount += 4;
            break;
        }

        if ( pyramideHeight % 5 == 0) {
            lapisLazulisCount += (i - 1) * 4;
        } else {
            marblesCount += (i - 1) * 4;
        }

        
    }

 
    let stoneWeigth = stoneCount * heigth;
    let marbleWeigth = marblesCount * heigth;
    let lapisLazulisWeigth = lapisLazulisCount * heigth;
    let goldWeigth = goldCount * heigth;
    let totalPyramideHeight =pyramideHeight * heigth;

    console.log(`Stone required: ${Math.ceil(stoneWeigth)}`);
    console.log(`Marble required: ${Math.ceil(marbleWeigth)}`);
    console.log(`Lapis Lazuli required: ${Math.ceil(lapisLazulisWeigth)}`);
    console.log(`Gold required: ${Math.ceil(goldWeigth)}`)
    console.log(`Final pyramid height: ${Math.floor(totalPyramideHeight) }`);
}


calculatePyramid(11,0.75);
calculatePyramid(23,0.5)

calculatePyramid(12,1);