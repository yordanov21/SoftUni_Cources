const cubeService = require('../services/cubeService');

exports.isOwnCube = function (req, res, next) {
    let id = req.params.cubeId;
    console.log(id);
    let cube = cubeService.getOne(id);
    //console.log(cube);
    //console.log(req.params.cubeId);
    console.log('sdfdsfsdggfjgh');
    console.log(cube.creator);
    console.log(req.user._id);
    if (cube.creator == req.user._id) {
        req.cube = cube;
        console.log('sdfdsfsdggfjgh222222');
        next();
    } else {
        console.log('sdfdsfsdggfjgh22222233333');
        next('you are not authorized to edit this cube')
    }
}