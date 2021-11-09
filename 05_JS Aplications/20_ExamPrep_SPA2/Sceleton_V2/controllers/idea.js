import extend from '../utils/context.js';
import models from '../models/index.js';
import docModifier from '../utils/doc-modifier.js';
export default {
    //get object
    get: {
        //function dashboard
        dashboard(context) {

            models.idea.getAll().then((response) => {
                //da se doberem do kolekciata ot ideas
                // const ideas = response.docs.map((d) => d.data());

                const ideas = response.docs.map(docModifier).sort((a, b) => b.likes - a.likes);

                //за да излязат колекцията на екрана:)
                context.ideas = ideas;

                extend(context).then(function() {
                    this.partial('../views/idea/dashboard.hbs')
                })
            })


        },
        create(context) {
            extend(context).then(function() {
                this.partial('../views/idea/create.hbs')
            })
        },

        details(context) {
            const { ideaId } = context.params;

            models.idea.get(ideaId).then((response) => {

                const idea = docModifier(response);
                //console.log(idea);

                //залепяме всички пропъртита от каузата на най-външно ниво
                Object.keys(idea).forEach((key) => {
                    context[key] = idea[key];
                });
                context.canModify = idea.uId !== localStorage.getItem('userId');
                extend(context).then(function() {
                    this.partial('../views/idea/details.hbs')
                })


            }).catch((e) => console.error(e))

        }
    },

    //post object handle-ва post заявките с  каузите
    post: {
        //context-a идва от sammy
        create(context) {
            //...context.params за да трансвормираме от sammy object, и след това го записваме в fb
            // params e обекта(sammy object), който се пълни с подадената информация от формата
            const data = {
                ...context.params,
                uId: localStorage.getItem('userId'),
                creator: localStorage.getItem('userEmail'),
                likes: 0,
                comments: []
            };

            models.idea.create(data).then((response) => {
                console.log(response);
                context.redirect('#/idea/dashboard')
            }).catch((e) => console.error(e));
        }
    },
    del: {
        close(context) {
            const { ideaId } = context.params;
            //console.log(ideaId);

            models.idea.close(ideaId).then((response) => {
                context.redirect('#/idea/dashboard');
            })
        }
    },
    put: {
        like(context) {

            console.log(context);

            const { ideaId } = context.params;

            console.log(ideaId);

            models.idea.get(ideaId).then((response) => {
                    const idea = docModifier(response);
                    debugger;
                    console.log(idea);
                    idea.likes += 1;
                    console.log(idea.likes);

                    //idea.likes.push(localStorage.getItem('userEmail'));
                    return models.idea.like(ideaId, idea);
                })
                .then((response) => {
                    context.redirect(`#/idea/details/${ideaId}`);
                })


        },

        comment(context) {

            console.log(context);
            const { ideaId, newComment } = context.params;

            console.log(ideaId);
            console.log(newComment);
            models.idea.get(ideaId).then((response) => {
                    const idea = docModifier(response);
                    console.log(idea);
                    //pushe the user in the colection
                    // idea.comments.push(localStorage.getItem('userEmail'));
                    //push the conntent
                    idea.comments.push(newComment);


                    console.log(idea.comments);

                    return models.idea.comment(ideaId, idea);
                })
                .then((response) => {
                    context.redirect('#/idea/dashboard');
                })


        }
    }
};