function solve(httpObj){

    validateMethod(httpObj);
    validateUri(httpObj);
    validateVersion(httpObj);
    validateMessage(httpObj);

    return httpObj;

    function validateMethod(httpObj){
        let methods = ['GET', 'POST', 'DELETE', 'CONNECT'];
        let propName = 'method'
        
        if (httpObj[propName] === undefined || !methods.includes(httpObj[propName])) {
            throw new Error('Invalid request header: Invalid Method');
        }
    }

    function validateUri(httpObj){
        let uriRegex = /^([a-zA-Z0-9\.]+|\*)$/gm;
        let propName = 'uri'
        
        if (httpObj[propName] === undefined || !uriRegex.test(httpObj[propName])) {
            throw new Error('Invalid request header: Invalid URI');
        }
    }

    function validateVersion(httpObj){
        let versions = ['HTTP/0.9', 'HTTP/1.0', 'HTTP/1.1', 'HTTP/2.0']
        let propName = 'version'
        
        if (httpObj[propName] === undefined || !versions.includes(httpObj[propName])) {
            throw new Error('Invalid request header: Invalid Version');
        }
    }

    function validateMessage(httpObj){
        let msgRegex = /^[^<>\\&'"]*$/gm;
        let propName = 'message'
        
        if (httpObj[propName] === undefined || !msgRegex.test(httpObj[propName])) {
            throw new Error('Invalid request header: Invalid Message');
        }
    }

}
try {
    console.log(solve({
        method: 'OPTIONS',
        uri: 'git.master',
        version: 'HTTP/1.1',
        message: '-recursive'
      }
      
      ));
} catch (e) {
    console.log(e.message);
}