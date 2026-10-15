#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <sys/wait.h>
#include <ctype.h>
#include <string.h>

int main() {
    int pipe1[2], pipe2[2];
	
	pipe(pipe1);
	pipe(pipe2);
	
	pid_t pidB, pidC;
    pidB = fork();
    
    int numero = rand() %100 + 1;
	
	if(pidB == 0){
	    read(pipe1[0], &numero, sizeof(numero));
	    if(numero >= 50){
	        write(pipe2[1], &numero, sizeof(numero));
	    } else {
	        printf("Numero scartato");
	    }
	    //il processo figlio invia il contenuto della pipe
	} else {
	    pidC = fork();
	    
	    if(pidC == 0){
	        read(pipe2[0], &numero, sizeof(numero));
	        printf("Numero: %d", numero);  
	    }
	    
	    for(int i = 0; i <= 20; i++){
	        int numero = rand() %100 + 1;
	        write(pipe1[1], &numero, sizeof(numero));
	    }
	    //il processo padre riceve il contenuto nella pipe
	}
	
	return 0;
}
