function solve(commands){
    let number = 1;
    let resultArr = [];

    for (let i = 0; i < commands.length; i++) {
        
        if (commands[i] === 'add') {
            resultArr.push(number);
        } 
        else if(commands[i] === 'remove'){
            resultArr.pop();
        }

        number++;
    }

    return resultArr.length === 0 ? 'Empty' : resultArr.join('\n');
}


console.log(solve(['add', 
'add', 
'add', 
'add']
))

console.log(solve(['remove', 
'remove', 
'remove']
));