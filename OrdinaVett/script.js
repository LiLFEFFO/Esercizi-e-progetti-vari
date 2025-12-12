let vett = [10, 9, 8, 7, 6, 5, 4, 3, 2, 1];
let risultato = [];

function ordinaVett(vett) {
    let n = vett.length;
    let i = 0;
    
    while (i <= n) {
        let min = i;
        let j = i + 1;
        
        while (j < n) {
            if (vett[j] < vett[min]) {
                min = j;
            }
            j++;
        }
        let temp = vett[min];
        vett[min] = vett[i];
        vett[i] = temp;
        
        i++;
    }
    
    return vett;
}

risultato = ordinaVett(vett);
console.log(risultato);