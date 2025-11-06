function calcoli(){
    const cognome = document.getElementById("cognome").value;
    const nome = document.getElementById("nome").value;
    const risultato = document.getElementById("risultato");

    const consonantiCognome = consonanti(cognome);
    const consonantiNome = consonanti(nome);

    risultato.textContent = "Il tuo cognome ha " + consonantiCognome + " consonanti";
    risultato.textContent = "Il tuo nome ha " + consonantiNome + " consonanti";

    if (cognome && nome){
        risultato.textContent = "Ciao " + nome + cognome + ", benvenuto!" ;
    } else {
        risultato.textContent = "Per favore, inserisci il nome e il cognome";
    }
}

function consonanti(stringa){
    
}