const router = require('express').Router();

const { isAuth } = require('../middlewares/authMiddleware');
const postService = require('../services/postService');
const authService = require('../services/authService');


router.get('/', async (req, res) => {

    let posts = await postService.getAll();

    res.render('post', { posts });
});

router.get('/create', isAuth, (req, res) => {
    res.render('post/create');
});

router.post('/create', isAuth, async (req, res) => {

    try {
        let { title, keyword, location, dateOfCreation, image, description } = req.body;

        // default rating is zero
        let ratingOfPost = 0;
        await postService.create({ title, keyword, location, dateOfCreation, image, description, author: req.user._id, ratingOfPost });
        let createdPost = await postService.getLastAddedPost();
        let createdPostData = await createdPost.toObject();
        await postService.addToUserPosts(createdPostData._id, req.user._id,)

        res.redirect('/post');
    } catch (error) {
        res.render('post/create', { error: getErrorMessage(error) })
    }
});

router.get('/:postId/details', async (req, res) => {
    let post = await postService.getOne(req.params.postId);
    let postData = await post.toObject();

    let isAuthor = postData.author._id == req.user?._id;
    let author = postData.author;
    let isUserVode = await postService.findUserVotesOnPosts(req.params.postId, req.user?._id);

    res.render('post/details', { ...postData, isAuthor, author, isUserVode });
});

router.get('/:postId/vodeUp', isAuth, isNotCreator, async (req, res) => {
    await postService.addVotesOnPosts(req.params.postId, req.user._id)
    await postService.voteUp(req.params.postId);
    res.redirect(`/post/${req.params.postId}/details`);
});

router.get('/:postId/vodeDown', isAuth, isNotCreator, async (req, res) => {
    await postService.addVotesOnPosts(req.params.postId, req.user._id)
    await postService.voteDown(req.params.postId);
    res.redirect(`/post/${req.params.postId}/details`);
});

router.get('/:postId/delete', isCreator, async (req, res) => {

    await postService.delete(req.params.postId);

    res.redirect('/post');
});

router.get('/:postId/edit', isCreator, async (req, res) => {

    let post = await postService.getOne(req.params.postId);
    let postData = await post.toObject();

    res.render('post/edit', { ...postData });
});

router.post('/:postId/edit', isCreator, async (req, res) => {

    try {
        let { title, keyword, location, dateOfCreation, image, description } = req.body;

        await postService.updateOne(req.params.postId, { title, keyword, location, dateOfCreation, image, description })
        res.redirect(`/post/${req.params.postId}/details`);
    } catch (error) {
        res.render('/post/${req.params.postId}/edit', { error: getErrorMessage(error) })
    }
});

// for security guards
async function isNotCreator(req, res, next) {
    let post = await postService.getOne(req.params.postId);


    if (post.author._id == req.user._id) {
        res.redirect(`/course/${req.params.postId}/details`);
    } else {
        next();
    }
};

// // for security guards
async function isCreator(req, res, next) {
    let post = await postService.getOne(req.params.postId);

    if (post.author._id == req.user._id) {
        next();
    } else {
        res.redirect(`/post/${req.params.postId}/details`);
    }
};

function getErrorMessage(error) {
    let errorNames = Object.keys(error.errors);

    if (errorNames.length > 0) {
        return error.errors[errorNames[0]];
    } else {
        error.message;
    }
}

module.exports = router;