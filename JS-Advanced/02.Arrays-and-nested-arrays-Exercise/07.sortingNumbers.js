function solve(arr) {
    let sorted = arr.sort((a, b) => a - b); 
    let result = [];
    while (sorted.length != 0) {
        let [smallest, biggest] = [sorted.shift(), sorted.pop()]; 
        result.push(smallest, biggest);
    }
    return result;
}
  