#include <stdio.h>

void scambia(int *a, int *b);

int main()
{
    int a = 3;
    int b = 4;
    scambia(&a, &b);

    return 0;
}

void scambia(int *a, int *b){

    printf("Prima dello scambio: %d", *a);
    printf(" %d\n", *b);
    
    int x = *b;
    *b = *a;
    *a = x;
    printf("Dopo lo scambio: %d", *a);
    printf(" %d", *b);
    
}
