function solve(names){

    let sortedNames = names.sort((a, b) => a.localeCompare(b));

    for (let i = 0; i < sortedNames.length; i++) {
        sortedNames[i] = `${i+1}.${sortedNames[i]}`;
        
    }
    return sortedNames.join('\n');
}

console.log(solve(["John", "Bob", "Christina", "Ema"]));