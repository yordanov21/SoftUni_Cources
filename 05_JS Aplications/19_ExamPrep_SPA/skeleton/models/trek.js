let db = firebase.firestore();
export default {
    create(data) {
        return db.collection('treks').add(data)
    },

    getAll() {
        //return array of all treks 
        return db.collection('treks').get();
    },

    get(id) {
        return db.collection('treks').doc(id).get();
    },
    close(id) {
        return db.collection('treks').doc(id).delete();
    },
    donate(id, data) {
        return db.collection('treks').doc(id).update(data)
    }
};