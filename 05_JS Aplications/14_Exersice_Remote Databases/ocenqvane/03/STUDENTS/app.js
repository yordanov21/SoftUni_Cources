function displayStudents() {

    const tableBody = document.querySelector('#results tbody');
    const idInput = document.querySelector('#idInput');
    const firstNameInp = document.querySelector('#firstName');
    const lastNameInp = document.querySelector('#lastName');
    const fNumberInp = document.querySelector('#number');
    const gradeInp = document.querySelector('#grade');
    const submitBtn = document.querySelector('#submit');
    const loadBtn = document.querySelector('#load');

    const URL = 'https://studentsdata-e459a.firebaseio.com/students.json';

    loadBtn.addEventListener('click' , function(e){
        
        e.preventDefault();
        displayStudents()

    })

    submitBtn.addEventListener('click' , createNewStudent);

    function createNewStudent(e) {
       
        e.preventDefault()

        let id = idInput.value;
        let firstName = firstNameInp.value;
        let lastName = lastNameInp.value;
        let fNumber = fNumberInp.value;
        let grade = gradeInp.value;

        let isValid = true;

        (function() {

           for (const arg of arguments) {
               if (arg === '') {
                   isValid = false;
               }
           };

        }(id , firstName , lastName , fNumber , grade));

        if (isValid) {
            
            let studentObj = {id , firstName , lastName , fNumber , grade};

            const headersObj = {
                method: 'POST',
                headers: {'Content-type' : 'application/json'},
                body: JSON.stringify(studentObj)
            };

            fetch(URL , headersObj)
            .then(() => {
                console.log('Success')
                displayStudents()
            })
            .catch(() => {
                console.error('Oops...Something went wrong')
            })

        }else {
            
            setTimeout(() => {
                alert('Invalid Input');
            } , 100)
            
        }

        idInput.value = '';
        firstNameInp.value = '';
        lastNameInp.value = '';
        fNumberInp.value = '';
        gradeInp.value = '';

    };

    function displayStudents() {

        fetch(URL)
        .then((res) => res.json())
        .then((data) => {
            
            data = Object.entries(data).sort(sortStudents);

            tableBody.innerHTML = ''
            data.forEach(([ , student]) => {

                let tableRow = document.createElement('tr');

                tableRow.innerHTML = `<th>${student.id}</th>
                                      <th>${student.firstName}</th>
                                      <th>${student.lastName}</th>
                                      <th>${student.fNumber}</th>
                                      <th>${student.grade}</th>`

                tableBody.appendChild(tableRow)

            })

            function sortStudents(a , b) {

                let [randomId1 , studentInfo1] = a;
                let [randomId2 , studentInfo2] = b;

                let firstId = Number(studentInfo1.id);
                let secondId = Number(studentInfo2.id);

                return firstId - secondId;

            };

        })
        .catch(() => {
            console.error('Oops...Something went wrong')
        });

    };

};

displayStudents()