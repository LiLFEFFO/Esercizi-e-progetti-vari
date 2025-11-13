function calcoli(){
    const cognome = document.getElementById("cognome").value;
    const nome = document.getElementById("nome").value;
    const saluto = document.getElementById("saluto");
    const risultato = document.getElementById("risultato");

    const consonantiCognome = consonanti(cognome);
    const consonantiNome = consonanti(nome);

    risultato.textContent = "Il tuo cognome ha " + consonantiCognome + " consonanti";
    risultato.textContent = "Il tuo nome ha " + consonantiNome + " consonanti";

    if (cognome && nome){
        saluto.textContent = "Ciao " + nome + cognome + ", benvenuto!" ;
    } else {
        saluto.textContent = "Per favore, inserisci il nome e il cognome";
    }
}

function consonanti(stringa){
    let risultato = ""
    for (lettera of stringa){
        if (vocale(lettera) === false ){
            risultato += lettera;
        }
    }
    return risultato
}

vocale(){
    if (lettera === A || lettera === E ||  lettera === I || lettera === O || lettera === U || lettera === a || lettera === e || lettera === i || lettera === o || lettera === u ||){
        return true
    } else {
        return false
    }
}
