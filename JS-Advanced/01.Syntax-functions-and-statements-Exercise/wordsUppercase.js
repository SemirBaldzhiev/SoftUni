function solve(input){

    let pattern = /\W+/g;
    let inputTokens = input.split(pattern).filter(x => x);

    let result = [];

    for (let index = 0; index < inputTokens.length; index++) {
        result[index] = inputTokens[index].toUpperCase();
    }
    
    console.log(result.join(', '));
}