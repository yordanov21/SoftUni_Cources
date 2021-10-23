const Housing = require('../models/Housing');


exports.create = (housingData) => Housing.create(housingData);

exports.getOne = (housingId) => Housing.findById(housingId).populate('tenants');

exports.getAll = () => Housing.find().lean();

exports.getTopHouses = () => Housing.find().sort({ createdAt: -1 }).limit(3).lean(); // dont forget the lean() to the end :), when return objects form the mongoose 

exports.addTenant =  (housingId, tenantId) => {
    // let housing = await housingService.getOne(req.params.housingId);
    // housing.tenants.push(req.user._id);
    // return housing.save();

    return Housing.findOneAndUpdate(
        { _id: housingId },
        {
            $push: { tenants: tenantId },
            $inc: { availablePieces: -1}
        },
        { runValidators: true});
}

exports.delete = (housingId) => Housing.findByIdAndDelete(housingId);

exports.updateOne =(housingId, housingData) => Housing.findByIdAndUpdate(housingId, housingData);

exports.search = (searchText) => Housing.find({ type: {$regex: searchText, $options: 'i'}}).lean();