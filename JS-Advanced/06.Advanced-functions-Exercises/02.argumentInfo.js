function solve(...params){
    let occurences = {};
    let result = [];
    params.forEach(el => {
        let type = typeof(el);

        result.push(`${type}: ${el}`);
        
        if (occurences[type] !== undefined) {
            occurences[type]++;
        } 
        occurences[type] = 1;
    });

    Object.keys(occurences).sort((a, b) => occurences[b] - occurences[a]).forEach(key => result.push(`${key}: ${occurences[key]}`));

    return result.join('\n');
}

console.log(solve('cat', 42, function () { console.log('Hello world!'); }));