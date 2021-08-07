let section = undefined;

function setupSection(domElement){
    section = domElement;
}


function getView(){
    return section;
}

let editMoviePage = {
    setupSection,
    getView
}

export default editMoviePage;