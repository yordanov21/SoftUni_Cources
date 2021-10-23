const router = require('express').Router();

const { isAuth } = require('../middlewares/authMiddleware');
const housingService = require('../services/housingService');

router.get('/', async (req, res) => {

    let housings = await housingService.getAll();

    res.render('housing', { housings });
});

router.get('/create', isAuth, (req, res) => {
    res.render('housing/create');
});

router.post('/create', isAuth, async (req, res) => {

    try {
        await housingService.create({ ...req.body, owner: req.user._id });

        res.redirect('/housing');
    } catch (error) {
        res.render('housing/create', {error: getErrorMessage(error)})
    }
});

function getErrorMessage(error) {
    let errorNames = Object.keys(error.errors);

    if(errorNames.length > 0) {
        return error.errors[errorNames[0]];
    } else {
        error.message;
    }
}

router.get('/:housingId/details', async (req, res) => {
    let housing = await housingService.getOne(req.params.housingId);
    let housingData = await housing.toObject();

    let isOwner = housingData.owner == req.user?._id;
    let tenants = housing.getTenants();


    let isAvailable = housing.availablePieces > 0;
    let isRentedByUser = housing.tenants.some(x => x._id == req.user?._id);

    res.render('housing/details', { ...housingData, isOwner, tenants, isAvailable, isRentedByUser });
});

router.get('/:housingId/rent', isOwner, async (req, res) => {

    await housingService.addTenant(req.params.housingId, req.user._id);

    res.redirect(`/housing/${req.params.housingId}/details`);
});

router.get('/:housingId/delete', isNotOwner, async (req, res) => {
    await housingService.delete(req.params.housingId);

    res.redirect('/housing');
});

router.get('/:housingId/edit', isNotOwner, async (req, res) => {
    let housing = await housingService.getOne(req.params.housingId);
    let housingData = await housing.toObject();

    res.render('housing/edit', { ...housingData });
});

router.post('/:housingId/edit', isNotOwner, async (req, res) => {
    await housingService.updateOne(req.params.housingId, req.body)

    res.redirect(`/housing/${req.params.housingId}/details`);
});

// for security guards
async function isOwner(req, res, next) {
    let housing = await housingService.getOne(req.params.housingId);

    if (housing.owner == req.user._id) {
        res.redirect(`/housing/${req.params.housingId}/details`);
    } else {
        next();
    }
};

// for security guards
async function isNotOwner(req, res, next) {
    let housing = await housingService.getOne(req.params.housingId);

    if (housing.owner != req.user._id) {
        next();
    } else {
        res.redirect(`/housing/${req.params.housingId}/details`);

    }
};

module.exports = router;