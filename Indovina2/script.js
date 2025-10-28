let numerodaIndovinare = Math.floor(Math.random() * 100) + 1;
let tentativi = 0;

function riavviaProgramma(){
    numerodaIndovinare = Math.floor(Math.random() * 100) + 1;
    tentativi = 0;
    document.getElementById("tentativi").innerText = ""
    document.getElementById("risultato").innerText = ""
}

function indovinaNumero() {

    tentativi++;
    document.getElementById("tentativi").innerText = "Numero tentativi: " + tentativi;

    let numeroUtente = Number(document.getElementById("numeroUtente").value);
    console.log("numero da indovinare : " + numerodaIndovinare);
    console.log("numero utente: " + numeroUtente);

    if (numeroUtente == numerodaIndovinare) {
        document.getElementById("risultato").innerText = "Hai vinto! Il numero era " + numerodaIndovinare
    }
    else if (numeroUtente < numerodaIndovinare) {
        document.getElementById("risultato").innerText = numeroUtente + " sembra troppo basso, riprova"
    }
    else {
        document.getElementById("risultato").innerText = numeroUtente + " sembra troppo alto, riprova"
    }
}