function calcolaCodiceFiscale() {
    const nome = document.getElementById('nome').value.toUpperCase();
    const cognome = document.getElementById('cognome').value.toUpperCase();
    const dataNascita = new Date(document.getElementById('dataNascita').value);
    const comuneNascita = document.getElementById('comuneNascita').value.toUpperCase();

    const lettereNome = estraiLettere(nome, true);
    const lettereCognome = estraiLettere(cognome, false);
    const dataCodice = calcolaDataCodice(dataNascita);
    const comuneCodice = calcolaComuneCodice(comuneNascita);

    const codiceFiscale = lettereCognome + lettereNome + dataCodice + comuneCodice;

    document.getElementById('codiceFiscale').textContent = codiceFiscale;
}

function estraiLettere(parola, isNome) {
    const consonanti = parola.replace(/[AEIOU]/gi, '');
    const vocali = parola.replace(/[^AEIOU]/gi, '');

    let risultato = consonanti + vocali;
    if (isNome && consonanti.length > 3) {
        risultato = consonanti[0] + consonanti[2] + consonanti[3];
    }

    return (risultato + 'XXX').substring(0, 3);
}

function calcolaDataCodice(data) {
    const anno = data.getFullYear().toString().slice(-2);
    const mese = 'ABCDEHLMPRST'[data.getMonth()];
    let giorno = data.getDate();

    // Aggiungere 40 se il sesso è femminile (qui consideriamo sempre maschile)
    giorno = giorno < 10 ? '0' + giorno : giorno;

    return anno + mese + giorno;
}

function calcolaComuneCodice(comune) {
    // Questa è una funzione semplificata. Normalmente, avresti bisogno di una mappa comune-codice.
    return 'H501'; // Codice fittizio per esempio
}