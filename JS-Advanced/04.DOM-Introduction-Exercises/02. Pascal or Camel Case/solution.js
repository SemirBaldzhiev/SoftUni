function solve() {
  let currentInputText = document.getElementById('text').value;
  let namingConvention = document.getElementById('naming-convention').value;
  let resultSpanElement = document.getElementById('result');

  resultSpanElement.textContent = convertToCase(currentInputText, namingConvention); 

  console.log(currentInputText);
  console.log(namingConvention);


  function convertToCase(text, convention){
    
    let result = [];

    if (convention === 'Camel Case') {
      result = text.toLowerCase().split(' ').map((x, i) => x = (i !== 0 ? x[0].toUpperCase() + x.slice(1) : x));
    } else if(convention === 'Pascal Case'){
      result = text.toLowerCase().split(' ').map(x => x[0].toUpperCase() + x.slice(1));
    } else{
      result = ['Error!'];
    }

    console.log(result);

    return result.join('');
  }
}