let db = firebase.firestore();
export default {
    create(data) {

        return db.collection('ideas').add(data)
    },

    getAll() {
        //return array of all causes 
        return db.collection('ideas').get();
    },

    get(id) {
        return db.collection('ideas').doc(id).get();
    },
    close(id) {
        return db.collection('ideas').doc(id).delete();
    },
    like(id, data) {
        return db.collection('ideas').doc(id).update(data)
    },
    comment(id, data) {
        return db.collection('ideas').doc(id).update(data)
    }
};