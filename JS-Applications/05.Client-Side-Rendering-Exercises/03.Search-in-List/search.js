import { render } from "./../node_modules/lit-html/lit-html.js";
import searchTownTemplates from "./templates/searchTownTemplates.js";
import { towns } from "./towns.js";

let townsContainer = document.getElementById('towns');
let baseTowns = towns.map(t => ({name: t}));

render(searchTownTemplates.townsUlTemplate(baseTowns), townsContainer);

let searchBtn = document.querySelector('article > button');

searchBtn.addEventListener('click', search);

function search(e) {
   let searchInput = document.getElementById('searchText');
   let searchText = searchInput.value.toLowerCase();

   let allTowns = towns.map(t => ({name: t}));

   let searchedTowns = allTowns.filter(t => t.name.toLowerCase().includes(searchText));

   searchedTowns.forEach(t => t.class = 'active'); 

   let matchesElement = document.getElementById('result');

   let matchesText = `${searchedTowns.length} matches found`;
   matchesElement.textContent = matchesText;

   render(searchTownTemplates.townsUlTemplate(allTowns), townsContainer);

}
