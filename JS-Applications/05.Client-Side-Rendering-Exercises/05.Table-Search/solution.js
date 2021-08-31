import { render } from "./../node_modules/lit-html/lit-html.js";
import tableTemplates from "./templates/tableTemplates.js";

function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   let tBody = document.querySelector('.container tbody');
   let students = [];

   function loadStudents(){
      fetch('http://localhost:3030/jsonstore/advanced/table')
      .then(res => res.json())
      .then(studentsData => {
         students = Object.values(studentsData)
         render(tableTemplates.allTrTemplate(students), tBody)
      })
      .catch(err => {
         console.error(err);
      });
   }

   loadStudents();
   
   function onClick() {
      let searchInput = document.getElementById('searchField');
      let searchText = searchInput.value.toLowerCase();

      let allStudents = students.map(s => Object.assign({}, s));

      let matchedStudents = allStudents.filter(s => Object.values(s).some(val => val.toLowerCase().includes(searchText)));

      matchedStudents.forEach(s => s.class = 'select');
      searchInput.value = '';
      render(tableTemplates.allTrTemplate(allStudents), tBody)
   }
}

solve()