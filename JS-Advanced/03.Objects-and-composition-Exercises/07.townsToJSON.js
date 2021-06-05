function solve(inputArr){

    let titles = serializeRow(inputArr[0]);

    let rows = inputArr.slice(1).map(x => serializeRow(x).reduce((a, x, i) => {
        a[titles[i]] = x;
        return a;
    }, {})); 
    
    return JSON.stringify(rows);

    function serializeRow(str){
        return str
            .split(/\s*\|\s*/gim)
            .filter(x => x !== '')
            .map(x => isNaN(Number(x)) ? x : Number(Number(x).toFixed(2))); 
    }
}