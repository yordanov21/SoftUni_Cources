export const apiKey = 'https://bookdatabasejssoftuni.firebaseio.com/' //if do NOT  work add your firebase url here

export const getAllStudents = (collectionName) => {
    return fetch(apiKey + 'students.json').then(x => x.json());
};

export const getStudentById = (studentId) => {
    return fetch(`${apiKey}students/${studentId}.json`).then(x => x.json());
};

export const createNewStudent = (studentBody) => {
    return fetch(apiKey + 'students.json', {
        method: 'POST',
        body: JSON.stringify(studentBody)
    }).then(x => x.json());
};

export const updateStudent = (studentBody, studentId) => {
    return fetch(`${apiKey}students/${studentId}.json`, {
        method: 'PUT',
        body: JSON.stringify(studentBody)
    }).then(x => x.json());
};

export const deleteStudent = (studentId) => {
    return fetch(`${apiKey}students/${studentId}.json`, {
        method: 'DELETE'
    }).then(x => x.json())
};