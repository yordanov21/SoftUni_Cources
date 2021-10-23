const Course = require('../models/Course');


exports.create = (courseData) => Course.create(courseData);

exports.getOne = (housingId) => Course.findById(housingId).populate('tenants');

exports.getAll = () => Course.find().lean();

exports.getTopHouses = () => Course.find().sort({ createdAt: -1 }).limit(3).lean(); // dont forget the lean() to the end :), when return objects form the mongoose

exports.addTenant = (housingId, tenantId) => {
    // let housing = await housingService.getOne(req.params.housingId);
    // housing.tenants.push(req.user._id);
    // return housing.save();

    return Course.findOneAndUpdate(
        { _id: housingId },
        {
            $push: { tenants: tenantId },
            $inc: { availablePieces: -1 }
        },
        { runValidators: true });
}

exports.delete = (housingId) => Course.findByIdAndDelete(housingId);

exports.updateOne = (housingId, housingData) => Course.findByIdAndUpdate(housingId, housingData);

exports.search = (searchText) => Housing.find({ type: { $regex: searchText, $options: 'i' } }).lean();