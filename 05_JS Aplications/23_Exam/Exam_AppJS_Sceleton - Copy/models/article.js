let db = firebase.firestore();
export default {
    create(data) {
        return db.collection('articles').add(data)
    },

    getAll() {
        //return array of all causes 
        return db.collection('articles').get();
    },

    get(id) {
        return db.collection('articles').doc(id).get();
    },
    delete(id) {
        debugger;
        return db.collection('articles').doc(id).delete();
    },
    like(id, data) {
        return db.collection('articles').doc(id).update(data)
    },
    edit(id, data) {
        debugger;
        return db.collection('articles').doc(id).update(data)
    }
};