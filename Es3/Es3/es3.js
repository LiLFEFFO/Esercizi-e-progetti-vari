function calcolaSomme() {
  const start = parseInt(document.getElementById('start').value);
  const end = parseInt(document.getElementById('end').value);
  if (isNaN(start) || isNaN(end)) {
    alert('Inserisci due numeri validi!');
    return;
  }
  let numbers = [];
  for (let i = start; i <= end; i++) {
    numbers.push(i);
  }
  let sommaPari = 0;
  let sommaDispari = 0;
  numbers.forEach(num => {
    if (num % 2 === 0) {
      sommaPari += num;
    } else {
      sommaDispari += num;
    }
  });
  document.getElementById('array').innerHTML = `Array: [${numbers.join(', ')}]`;
  document.getElementById('pari').innerHTML = `Somma numeri pari: <strong>${sommaPari}</strong>`;
  document.getElementById('dispari').innerHTML = `Somma numeri dispari: <strong>${sommaDispari}</strong>`;
}