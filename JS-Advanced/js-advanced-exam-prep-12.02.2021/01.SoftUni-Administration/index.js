function solve() {
    let addButtonElement = document.querySelector('.admin-view .action button');
    let modules = {};

    addButtonElement.addEventListener('click', (e) => {
        e.preventDefault();

        let lectureInputElement = document.querySelector('input[name="lecture-name"]');
        let dateInputElement = document.querySelector('input[name="lecture-date"]'); 
        let moduleSelectElement = document.querySelector('select[name="lecture-module"]');

        
        if (!lectureInputElement.value || !dateInputElement.value || moduleSelectElement.value == 'Select module')  {
            return;
        }
        if (!modules[moduleSelectElement.value]) {
            modules[moduleSelectElement.value] = [];
        }
        
        let currentLecture = { name: lectureInputElement.value, date: formatDate(dateInputElement.value) }
        modules[moduleSelectElement.value].push(currentLecture);

        lectureInputElement.value = '';
        dateInputElement.value = '';
        moduleSelectElement.value = 'Select module'

        createTrainings(modules);
    });

    function createTrainings(modules){
        let modulesElement = document.querySelector('.container .modules');
        modulesElement.innerHTML = '';

        for (const moduleName in modules) {
            let moduleElement = createModule(moduleName);
            let lectureListElement = document.createElement('ul');

            let lectures = modules[moduleName];

            lectures
            .sort((a, b) => a.date.localeCompare(b.date))
            .forEach(({name, date}) => {
                let lectureElement = createLecture(name, date);
                lectureListElement.appendChild(lectureElement);

                let deleteButtonElement = lectureElement.querySelector('button');

                deleteButtonElement.addEventListener('click', (e) => {
                    modules[moduleName] = modules[moduleName].filter(x => x.name != name && x.date != date);

                    if (modules[moduleName].length == 0) {
                        delete modules[moduleName];
                        e.currentTarget.parentNode.parentNode.parentNode.remove();
                    }else{
                        e.currentTarget.parentNode.remove();
                    }
                });
            });
            
            moduleElement.appendChild(lectureListElement);
            modulesElement.appendChild(moduleElement);
        }   
    }

    function createModule(name){
        let divElement = document.createElement('div');

        let moduleHeadingElement = document.createElement('h3');

        moduleHeadingElement.textContent = `${name.toUpperCase()}-MODULE`;
        divElement.classList.add('module');

        divElement.appendChild(moduleHeadingElement);

        return divElement;
    }

    function createLecture(name, date){
        let liElement = document.createElement('li');
        liElement.classList.add('flex');

        let headingLectureElement = document.createElement('h4');
        headingLectureElement.textContent = `${name} - ${date}`;
        let deleteButtonElement = document.createElement('button');
        deleteButtonElement.classList.add('red');
        deleteButtonElement.textContent = 'Del';

        liElement.appendChild(headingLectureElement);
        liElement.appendChild(deleteButtonElement);

        return liElement;
    }

    function formatDate(dateInput) {
        let [date, time] = dateInput.split('T');
        date = date.replace(/-/g, '/');

        return `${date} - ${time}`;
    }
   
};