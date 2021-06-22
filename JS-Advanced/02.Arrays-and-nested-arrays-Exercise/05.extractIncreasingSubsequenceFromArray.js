function solve(arr) {
    return arr.reduce((a, x) => 
    {
        x >= (a.slice(-1)) ? a.push(x) : null; 
        return a
    }
    , []);
}

console.log(solve([1, 3, 8, 4, 10, 12, 3, 2, 24]))
