function solve() {
  let inputElement = document.getElementById('input');
  let outputElement = document.getElementById('output');

  let inputText = inputElement.value;

  let sentences = inputText.split('.').filter(x => x !== '').map(x => x + '.');
  let pCount = Math.ceil(sentences.length / 3);

  for (let i = 0; i < pCount; i++) {
    outputElement.innerHTML += `<p>${sentences.splice(0, 3).join('')}</p>`;
  }

}