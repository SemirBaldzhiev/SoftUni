function solve() {
  let textareaElements = document.querySelectorAll('#exercise textarea');
  let buttons = document.querySelectorAll('#exercise button');
  
  let generateTextareaElement = textareaElements[0];
  let generateButton = buttons[0];

  let buyButton = buttons[1];
  let resultTextarea = textareaElements[1];

  generateButton.addEventListener('click', () => {

    let items = JSON.parse(generateTextareaElement.value);
    console.log(items);
    let tbodyElement = document.querySelector('.table tbody');

    for (const item of items) {
      let tr = document.createElement('tr');
      
      let tdImage = document.createElement('td');
      let image = document.createElement('img');
      image.src = item.img;
      tdImage.appendChild(image);

      let tdName = document.createElement('td');
      let nameP = document.createElement('p');
      nameP.textContent = item.name;
      tdName.appendChild(nameP);

      let tdPrice = document.createElement('td');
      let priceP = document.createElement('p');
      priceP.textContent = Number(item.price);
      tdPrice.appendChild(priceP);

      let decFactorTd = document.createElement('td');
      let decFactorP = document.createElement('p');
      decFactorP.textContent = Number(item.decFactor);
      decFactorTd.appendChild(decFactorP);

      let markTd = document.createElement('td');
      let markInput = document.createElement('input');
      markInput.type = 'checkbox';
      markTd.appendChild(markInput);

      tr.appendChild(tdImage);
      tr.appendChild(tdName);
      tr.appendChild(tdPrice);
      tr.appendChild(decFactorTd);
      tr.appendChild(markTd);

      tbodyElement.appendChild(tr);
    }

  });

  buyButton.addEventListener('click', () => {

    let markedRows = Array.from(document.querySelectorAll('.table tbody tr')).filter(x => x.querySelector('td input:checked'));
    for (const row of markedRows) {
      
    }
    let names = markedRows.map(row => row.querySelector('td:nth-of-type(2) p').textContent);
    
    let totalPrice = markedRows
      .map(row => row.querySelector('td:nth-child(3) p'))
      .map(x => Number(x.textContent))
      .reduce((a, x) => a + x, 0);

    let averageDecFactor = markedRows
      .map(row => row.querySelector('td:nth-child(4) p'))
      .map(x => Number(x.textContent))
      .reduce((a, x) => a + x / markedRows.length, 0);

    let namesText = `Bought furniture: ${names.join(', ')}`; 
    let priceText = `Total price: ${totalPrice.toFixed(2)}`;
    let decFactorText = `Average decoration factor: ${averageDecFactor}`;

    let resultText = `${namesText}\n${priceText}\n${decFactorText}`;

    resultTextarea.value = resultText;

  });

}