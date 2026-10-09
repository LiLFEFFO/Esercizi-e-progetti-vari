#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>

int main()
{
    int fd[2];

    if(pipe(fd) == -1){
        perror("Errore pipe");
        exit(-1);
    }
    
    pid_t ritorno_fork = fork();
    
    if(ritorno_fork == -1){
        //processo padre
        perror("Errore fork");
        exit(-1);
    }
    
    if(!ritorno_fork){
        //processo figlio
        
        close(fd[0]);
        
        sleep(10);
        char msg[] = "studiate per favore anche TPSIT";
        
        //strln toglie l'ultimo carattere dalla stringa (il terminatore) mentre sizeof() non lo fa
        write(fd[1], msg, sizeof(msg));
        
        close(fd[1]);
        exit(0);
    }
    
    //processo padre
    printf("Aspetto il buffer...\n");
    char buffer [100];
    
    //torna il numero di byte letti
    ssize_t byte_number = read(fd[0], buffer, sizeof(buffer));

    printf("%d\n", byte_number);
    printf("%s\n", buffer);
    
    return 0;
}
