let tBody = document.querySelector('#results tbody');
let submitBtn = document.getElementById('submit');

submitBtn.addEventListener('click', () => {
    let firstNameElement = document.querySelector('input[name="firstName"]');
    let lastNameElement = document.querySelector('input[name="lastName"]');
    let facultyNumberElement = document.querySelector('input[name="facultyNumber"]');
    let gradeElement = document.querySelector('input[name="grade"]');

    let newStudent = {
        firstName: firstNameElement.value,
        lastName: lastNameElement.value,
        facultyNumber: facultyNumberElement.value,
        grade: Number(gradeElement.value)
    }

    fetch('http://localhost:3030/jsonstore/collections/students', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(newStudent)
    })
        .then(res => res.json())
        .then(student => {
            let trToAdd = creteTableRow(student.firstName, student.lastName, student.facultyNumber, student.grade);
            tBody.appendChild(trToAdd);
        })
        .catch(err => {
            console.error(err);
        });
});

fetch('http://localhost:3030/jsonstore/collections/students')
    .then(res => res.json())
    .then(students => {

        Object.values(students).forEach(student => {

            let tr = creteTableRow(student.firstName, student.lastName, student.facultyNumber, student.grade);
            tBody.appendChild(tr);
        })
    })
    .catch(err => {
        console.error(err);
    });

function creteTableRow(firstName, lastName, facultyNumber, grade) {
    
    let tr = document.createElement('tr');

    let tdFirstName = document.createElement('td');
    tdFirstName.textContent = firstName;

    let tdLastName = document.createElement('td');
    tdLastName.textContent = lastName;

    let tdFacultyNumber = document.createElement('td');
    tdFacultyNumber.textContent = facultyNumber;

    let tdGrade = document.createElement('td');
    tdGrade.textContent = grade.toFixed(2);

    tr.appendChild(tdFirstName);
    tr.appendChild(tdLastName);
    tr.appendChild(tdFacultyNumber);
    tr.appendChild(tdGrade);

    return tr;
}



