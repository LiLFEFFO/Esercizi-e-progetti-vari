#include <stdio.h>
#include <stdlib.h>
int main()
{
    int *numero = malloc(sizeof(int));
    *numero = 42;
    printf("Valore %d\n", *numero);
    printf("Indirizzo: %p\n", *numero);
    
    *numero += 34;
    printf("Valore %d\n", *numero);
    printf("Indirizzo: %p", *numero);
    free(numero);

    return 0;
}
