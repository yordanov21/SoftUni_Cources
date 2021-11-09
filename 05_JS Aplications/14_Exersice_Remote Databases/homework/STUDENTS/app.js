//!!!!!!!!!!!!!!!!!!!!!!!!NOT working: return Status 304 !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!


import { apiKey, createNewStudent, getAllStudents, getStudentById, updateStudent, deleteStudent } from './firebase-requester.js';

import { extractFromData, fillFormWithData } from "./form-helpers.js";

var firebaseConfig = {
    apiKey: "AIzaSyBMpGagRuoqpbIr4wY-O8E6cT5i2eg-Yec",
    authDomain: "bookdatabasejssoftuni.firebaseapp.com",
    databaseURL: "https://bookdatabasejssoftuni.firebaseio.com",
    projectId: "bookdatabasejssoftuni",
    storageBucket: "bookdatabasejssoftuni.appspot.com",
    messagingSenderId: "824106448519",
    appId: "1:824106448519:web:e98aa49b2ff8d2626bea22",
    measurementId: "G-P17T3MSN0S"
};
// Initialize Firebase
// firebase.initializeApp(firebaseConfig);
// firebase.analytics();


function addTableRow(tbody, bookValue, bookId) {

    let tempRow = document.createElement('tr');
    tempRow.setAttribute('data-book-id', bookId)

    tempRow.innerHTML = `
   <td>${bookId}</td>
   <td>${bookValue.firstName}</td>
   <td>${bookValue.lastName}</td>
   <td>${bookValue.facultyNumber}</td>
   <td>${bookValue.grade}</td>
   `;

    tbody.appendChild(tempRow)
}
(function() {

    firebase.auth().createUserrWithEmailAndPassword('gosho', '12345').then(x =>
        console.log(x)
    )
    let formRef = document.querySelector('form');
    let bodyRef = document.querySelector('tbody');
    const formConfig = ['firstName', 'lastName', 'facuilityNumber', 'grade'];
    getAllStudents()
        .then(students => {
            Object.entries(students)
                .sort((a, b) => +a.id - +b.id)
                .map(([id, studentData]) => {
                    addTableRow(bodyRef, studentData, id)
                })
        })

    formRef.addEventListener('submit', (e) => {
        e.preventDefault();
        let formResult = extractFromData(e.target, formConfig);

        getAllStudents()
            .then(students => {
                let nextStudentId = !students ? 0 : Object.keys(students).length;
                updateStudent(formResult, nextStudentId)
                    .then(() => getAllStudents())
                    .then(students => {

                        Object.entries(students).map(([id, studentData]) => {
                            addTableRow(bodyRef, studentData, id)
                        })
                    })
            })
    });
})();