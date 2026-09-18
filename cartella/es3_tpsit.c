#include <stdio.h>
#include <stdlib.h>

int main()
{
    float *numero = malloc(sizeof(float));
    printf("Inserisci il numero: ");
    scanf("%f", numero);
    
    *numero += (*numero / 100.0f * 20.0f);
    printf("Numero dopo un aumento del 20 percento: %f", *numero);
    free(numero);
    return 0;
}
