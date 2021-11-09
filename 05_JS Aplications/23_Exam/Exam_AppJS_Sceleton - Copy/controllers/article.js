import extend from '../utils/context.js';
import models from '../models/index.js';
import docModifier from '../utils/doc-modifier.js';
export default {
    //get object
    get: {

        edit(context) {

            extend(context).then(function() {
                this.partial('../views/article/edit.hbs')
            })
        },

        create(context) {
            extend(context).then(function() {
                this.partial('../views/article/create.hbs')
            })
        },

        details(context) {
            const { articleId } = context.params;

            models.article.get(articleId).then((response) => {

                const article = docModifier(response);
                //console.log(article);

                //залепяме всички пропъртита от каузата на най-външно ниво
                Object.keys(article).forEach((key) => {
                    context[key] = article[key];
                });
                context.canModify = article.uId === localStorage.getItem('userId');
                extend(context).then(function() {
                    this.partial('../views/article/details.hbs')
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
                //   likes: 0,
                //  comments: []
            };

            models.article.create(data).then((response) => {
                console.log(response);
                console.log(context.category);
                context.redirect('#/home')
            }).catch((e) => console.error(e));
        }
    },
    del: {
        delete(context) {
            const { articleId } = context.params;
            //console.log(articleId);

            models.article.delete(articleId).then((response) => {
                context.redirect('#/home');
            })
        }
    },
    put: {
        edit(context) {
            debugger;
            console.log(context);
            const { articleId, newTitle, newCategory, newConntent } = context.params;

            console.log(articleId);
            console.log(newTitle);
            console.log(newCategory);
            console.log(newConntent);
            models.article.get(articleId).then((response) => {
                    const article = docModifier(response);
                    console.log(article);
                    article.title = newTitle;
                    article.category = newCategory;
                    article.comment = newConntent;


                    return models.article.edit(articleId, article);
                })
                .then((response) => {
                    context.redirect('#/home');
                })

        }
    }
};