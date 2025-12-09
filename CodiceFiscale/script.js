function calcolaCodiceFiscale() {
    const nome = document.getElementById('nome').value.toUpperCase();
    const cognome = document.getElementById('cognome').value.toUpperCase();
    const dataNascita = new Date(document.getElementById('dataNascita').value);
    const comuneCodice = document.getElementById('codiceComune').value.toUpperCase();
    const sesso = document.getElementById('sesso').value.toUpperCase();

    const lettereNome = estraiLettere(nome, true);
    const lettereCognome = estraiLettere(cognome, false);
    const dataCodice = calcolaDataCodice(dataNascita, sesso);
    const calcolaComune = calcolaComuneCodice(comuneCodice);
    const codiceFiscaleBase = lettereCognome + lettereNome + dataCodice + comuneCodice;
    const caratterediControllo = calcolaCarattereControllo(codiceFiscaleBase);

    const codiceFiscale = codiceFiscaleBase + caratterediControllo;

    document.getElementById('codiceFiscale').textContent = codiceFiscale;
}

function calcolaDataCodice(data, sesso) {
    const anno = data.getFullYear().toString().slice(-2);
    const mese = 'ABCDEHLMPRST'[data.getMonth()];
    let giorno = data.getDate();

    if (sesso === 'F') {
        giorno += 40;
    }

    giorno = giorno < 10 ? '0' + giorno : giorno;

    return anno + mese + giorno;
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

function calcolaComuneCodice(comune) {
    return comune; 
}

function calcolaCarattereControllo(codiceFiscale) {

    const valoriDispari = {
        0: 1, 1: 0, 2: 5, 3: 7, 4: 9, 5: 13, 6: 15, 7: 17, 8: 19, 9: 21,
        A: 1, B: 0, C: 5, D: 7, E: 9, F: 13, G: 15, H: 17, I: 19, J: 21,
        K: 2, L: 4, M: 18, N: 20, O: 11, P: 3, Q: 6, R: 8, S: 12, T: 14,
        U: 16, V: 10, W: 22, X: 25, Y: 24, Z: 23
    };

    const valoriPari = {
        0: 0, 1: 1, 2: 2, 3: 3, 4: 4, 5: 5, 6: 6, 7: 7, 8: 8, 9: 9,
        A: 0, B: 1, C: 2, D: 3, E: 4, F: 5, G: 6, H: 7, I: 8, J: 9,
        K: 10, L: 11, M: 12, N: 13, O: 14, P: 15, Q: 16, R: 17, S: 18, T: 19,
        U: 20, V: 21, W: 22, X: 23, Y: 24, Z: 25
    };

    let somma = 0;

    for (let i = 0; i < codiceFiscale.length; i++) {
        const char = codiceFiscale[i].toUpperCase();
        if ((i + 1) % 2 === 1) {
            somma += valoriDispari[char];
        } else {
            somma += valoriPari[char];
        }
    }

    const lettere = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    return lettere[somma % 26];
}
