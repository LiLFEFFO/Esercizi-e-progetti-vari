let diff = prompt("Scegli la difficoltà tra: Facile (1), Media (2) o Difficile (3)");
let max;
let numeroDaIndovinare;

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

numeroDaIndovinare = Math.floor(Math.random() * max) + 1;
let num = parseInt(prompt("Inserisci un numero tra 1 e " + max), 10);
let tentativi = 1;

while (num !== numeroDaIndovinare) {
    if (num < numeroDaIndovinare) {
        num = parseInt(prompt("Numero troppo basso. Riprova: "), 10);
    } else if (num > numeroDaIndovinare) {
        num = parseInt(prompt("Numero troppo alto. Riprova: "), 10);
    }
    tentativi++;
}

alert("Complimenti! Hai indovinato il numero " + numeroDaIndovinare + " in " + tentativi + " tentativi.");