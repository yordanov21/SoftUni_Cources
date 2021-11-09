import { getRequest,postRequest } from './reqests.js';
let url = 'https://mybooks-a3607.firebaseio.com/'
let appName = 'students'
let endPoint = '/.json'

window.onload = async () => {
    createInputForm();
    loadStudents();
    let addStudentButton = document.getElementById('submit');
    let studentTable = document.getElementsByTagName('tbody')[0];

    addStudentButton.addEventListener('click',(e)=>{
        e.preventDefault();
        let errMessage = document.getElementById('err');
        errMessage.textContent="";

        let id = document.getElementById('id');
        let firstName = document.getElementById('FirstName');
        let lastName = document.getElementById('LastName');
        let facultyNumber = document.getElementById('FacultyNumber');
        let grade = document.getElementById('Grade');
                
        if(!(id.value&&firstName.value&&lastName.value&&facultyNumber.value&&grade.value)){
            errMessage.textContent ='All fields are required'
            return;
        };

        if(Number(id.value) > 6 || Number(id.value) < 2){
            errMessage.textContent ='The Grade should be between 2.00 and 6.00'
            return;
        }

        let newStudent ={
            id : id.value,
            firstName: firstName.value,
            lastName: lastName.value,
            facultyNumber: facultyNumber.value,
            grade: Number(grade.value).toFixed(2)
        }


        postRequest(url,appName,endPoint,newStudent);

        //errMessage.textContent='You have added a new student'
        id.value='';
        firstName.value='';
        lastName.value ='';
        facultyNumber.value ='';
        grade.value='';
        studentTable.innerHTML=''
        loadStudents();
    });

    async function loadStudents() {
        let studentList = await getRequest(url, appName, endPoint)
        Object.values(studentList).sort((a,b) => a.id - b.id).forEach(element => {
            let tempRow = document.createElement('tr');
            tempRow.innerHTML=`<td>${element.id}</td>
            <td>${element.firstName}</td>
            <td>${element.lastName}</td>
            <td>${element.facultyNumber}</td>
            <td>${element.grade}</td>`
            studentTable.appendChild(tempRow)
        });
    }
    

    function createInputForm() {
        let bodyRef = document.getElementsByTagName('body')[0];
        let newStudentForm = document.createElement('form')
        newStudentForm.id = 'form'
        newStudentForm.innerHTML = `<p id ="err"></p>
        <label>ID</label>
        <input type="number" id="id" placeholder="ID...">
        <label>First Name</label>
        <input type="text" id="FirstName" placeholder="First Name...">
        <label>Last Name</label>
        <input type="text" id="LastName" placeholder="Last Name...">
        <label>Faculty Number</label>
        <input type="text" id="FacultyNumber" placeholder="Faculty Number..." maxlength="12" pattern="[1-9]{1}[0-9]{11}">
        <label>Grade</label>
        <input type="number" step=0.01 id="Grade" placeholder="Grade...">
        <button id="submit">Add New Student</button>`
        bodyRef.appendChild(newStudentForm)
    };
}