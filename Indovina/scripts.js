function calcolaMaxTentativi(){
    let max = max;
    let MaxTentativi = ((max/diff)/2);
}
let diff = prompt("Scegli la difficoltà tra: Facile (1), Media (2) o Difficile (3)");
let max;
let numeroDaIndovinare;

//verifica della difficoltà -->
if (diff == 1) {
    max = 1000;
} else if (diff == 2) {
    max = 10000;
} else if (diff == 3) {
    max = 100000;
} else {
    alert("Scelta non valida. Impostata difficoltà Facile.");
    max = 1000;
}

let tentativi_max = calcolaMaxTentativi();

//Richiesta del numero da parte del programma -->
numeroDaIndovinare = Math.floor(Math.random() * max) + 1;
let num = parseInt(prompt("Inserisci un numero tra 1 e " + max), 10);
MaxTentativi = (MaxTentativi-1);

//verifica del valore del numero inserito e calcolo dei tentativi -->
while (num !== numeroDaIndovinare) {
    if (num < numeroDaIndovinare) {
        num = parseInt(prompt("Numero troppo basso. Riprova: "), 10);
    } else if (num > numeroDaIndovinare) {
        num = parseInt(prompt("Numero troppo alto. Riprova: "), 10);
    }
    MaxTentativi = (MaxTentativi-1);
}

alert("Complimenti! Hai indovinato il numero " + numeroDaIndovinare + " in " + tentativi + " tentativi.");
