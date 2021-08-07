let section = undefined;

function setupSection(domElement){
    section = domElement;
}


function getView(){
    return section;
}

let addMoviePage = {
    setupSection,
    getView
}

export default addMoviePage;
