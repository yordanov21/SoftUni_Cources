import extend from '../utils/context.js';
import models from '../models/index.js';
import docModifier from '../utils/doc-modifier.js';
export default {
    //get object
    get: {
        //function dashboard
        dashboard(context) {

            models.trek.getAll().then((response) => {
                //da se doberem do kolekciata ot treks
                // const treks = response.docs.map((d) => d.data());

                const treks = response.docs.map(docModifier);
                console.log(treks);

                //за да излязат пътеките на екрана:)
                context.treks = treks;

                extend(context).then(function() {
                    this.partial('../views/trek/dashboard.hbs')
                })
            })


        },
        create(context) {
            extend(context).then(function() {
                this.partial('../views/trek/create.hbs')
            })
        },

        details(context) {
            const { trekId } = context.params;

            models.trek.get(trekId).then((response) => {

                const trek = docModifier(response);
                //console.log(trek);

                //залепяме всички пропъртита от каузата на най-външно ниво
                Object.keys(trek).forEach((key) => {
                    context[key] = trek[key];
                });
                context.canDonate = trek.uId !== localStorage.getItem('userId');
                extend(context).then(function() {
                    this.partial('../views/trek/details.hbs')
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
                organizator: localStorage.getItem('userEmail'),
                likes: 0
            };

            models.trek.create(data).then((response) => {
                console.log(response);
                context.redirect('#/home')

            }).catch((e) => console.error(e));
        }
    },
    del: {
        close(context) {
            const { trekId } = context.params;
            //console.log(trekId);

            models.trek.close(trekId).then((response) => {
                context.redirect('#/trek/dashboard');
            })
        }
    },
    put: {
        donate(context) {
            const { trekId, donatedAmount } = context.params;
            // console.log(trekId);
            // console.log(donatedAmount);
            models.trek.get(trekId).then((response) => {
                    const trek = docModifier(response);
                    trek.collectedFunds += Number(donatedAmount);
                    trek.donors.push(localStorage.getItem('userEmail'));
                    return models.trek.donate(trekId, trek);
                })
                .then((response) => {
                    context.redirect('#/trek/dashboard');
                })


        }
    }
};