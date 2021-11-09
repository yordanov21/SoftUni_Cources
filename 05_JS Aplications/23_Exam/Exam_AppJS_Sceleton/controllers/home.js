import extend from '../utils/context.js';
import models from '../models/index.js';
import docModifier from '../utils/doc-modifier.js';

export default {
    get: {
        home(context) {

            models.article.getAll().then((response) => {
                //da se doberem do kolekciata ot articles
                // const articles = response.docs.map((d) => d.data());
                const articles = response.docs.map(docModifier).sort((a, b) => a.title - b.title);
                //за да излязат колекцията на екрана:)
                context.articles = articles;

                extend(context).then(function() {
                    this.partial('../views/home/home.hbs');

                })

            })



        }
    }

}