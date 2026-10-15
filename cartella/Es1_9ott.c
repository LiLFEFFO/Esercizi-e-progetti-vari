#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <sys/wait.h>
#include <ctype.h>
#include <string.h>

int main() {
    int pipe1[2], pipe2[2];
    pid_t pidF;
    
    pipe(pipe1);
    pipe(pipe2);
    
    pidF = fork();
    
    int array[10] = {5, 2, 7, 34, 12, 90, 56, 32, 71, 66};
    
    int somma = 0;
    int somma2 = 0;
    
    if(pidF == 0){
        for(int i = 0; i < 10; i++){
            if(array[i] %2 == 0){
                somma += array[i];
            }
        }
        
        write(pipe1[1], &somma, sizeof(somma));
    } else {
        //processo padre
        read(pipe1[0], &somma, sizeof(somma));
        for(int i = 0; i < 10; i++){
            if(array[i] %2 != 0){
                somma2 += array[i];
            }
        }
        
        printf("Somma numeri pari: %d\n", somma);
        printf("Somma dispari: %d", somma2);
    }
	
	return 0;
}
