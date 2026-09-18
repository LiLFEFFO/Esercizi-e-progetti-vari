#include <stdio.h>

int *trova_massimo(int *array, int dimensione);

int main()
{
    int array[] = {69, 67, 104, 3, 88};
    int dimensione = sizeof(array) / sizeof(array[0]);

    int *massimo = trova_massimo(array, dimensione);

    int indice = massimo - array;

    printf("Valore massimo: %d\n", *massimo);
    printf("Indice del massimo: %d\n", indice);

    return 0;
}

int *trova_massimo(int *array, int dimensione)
{
    int *massimo = &array[0];

    for (int i = 1; i < dimensione; i++) {
        if (array[i] > *massimo) {
            massimo = &array[i];
        }
    }

    return massimo;
}
