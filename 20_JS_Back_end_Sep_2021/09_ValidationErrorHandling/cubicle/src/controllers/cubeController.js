const express = require('express');
const validator = require('validator');
const { body, validationResult } = require('express-validator');



const cubeService = require('../services/cubeService');
const cubeAccessoryController = require('./cubeAccessoryController');
const { isAuth } = require('../middlewares/authMiddleware');

const router = express.Router();

const getCreateCubePage = (req, res) => {
    res.render('cube/create');
};

const createCube = async (req, res) => {

    // destructuring
    let { name, description, imageUrl, difficulty } = req.body;

    // if (!validator.isURL(imageUrl)) {
    //     return res.status(400).send('Invalid email');
    // }

    try {
        await cubeService.create(name, description, imageUrl, difficulty);

        res.redirect('/');
    } catch (error) {
        res.status(400).send(error.message).end();
    }

}

const cubeDetails = async (req, res) => {
    let cube = await cubeService.getOne(req.params.cubeId);
    res.render('cube/details', { ...cube });
}

const getEditCubePage = async (req, res) => {
    let cube = await cubeService.getOne(req.params.cubeId);
    res.render('cube/edit', { ...cube });
}

const postEditCubePage = async (req, res) => {
    let { name, description, imageUrl, difficulty } = req.body;

    await cubeService.updateOne(req.params.cubeId, { name, description, imageUrl, difficulty })

    res.redirect(`/cube/${req.params.cubeId}`);
};

const getDeleteCubePage = async (req, res) => {
    let cube = await cubeService.getOne(req.params.cubeId);
    res.render('cube/delete', { ...cube });
}

const postDeleteCubePage = async (req, res) => {
    await cubeService.deleteOne(req.params.cubeId);

    res.redirect(`/`);
};


router.get('/create', isAuth, getCreateCubePage);
router.post('/create', isAuth, body('imageUrl').isURL().isLength({ min: 5 }), createCube);
router.get('/:cubeId', cubeDetails);
router.get('/:cubeId/edit', isAuth, getEditCubePage);
router.post('/:cubeId/edit', isAuth, postEditCubePage);
router.get('/:cubeId/delete', isAuth, getDeleteCubePage);
router.post('/:cubeId/delete', isAuth, postDeleteCubePage);

router.use('/:cubeId/accessory', cubeAccessoryController);

module.exports = router;