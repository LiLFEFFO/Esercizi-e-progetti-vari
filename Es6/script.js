let soggetti = ["mio zio ", " il professor Maniglio ", " Alvise ", " Il Gel Igenizzante ", " Sinico ", " Oscar Piastri ", " Panait ", " un merluzzo che si chiama Maurizio "];
let azioni = [" salta su ", " mangia ", " evoca ", " igenizza ", " copia da ", " suona ", " uccide ", " annusa "]
let oggetti = [" la pizza ", " il professor Costa ", " un merluzzo che si chiama Antonno ", " Ayano ", " Max Verstappen ", " Benincà ", " un orso gay ", " la shuko per la corrente "]

function oggetto(){
    let soggetto = Math.floor(Math.random() * soggetti.length);
    let azione = Math.floor(Math.random() * azioni.length);
    let oggetto = Math.floor(Math.random() * oggetti.length);
    let frase = document.getElementById("frase");
    frase.innerHTML = soggetti[soggetto] + azioni[azione] + oggetti[oggetto];
}
