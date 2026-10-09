#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>

int main(void) {
    int array[] = {3, 8, 12, 5, 7, 20, 11, 4, 9, 16};
    int fd[2];
    pid_t pid;

    //il padre crea la pipe anonima
    if (pipe(fd) == -1) {
        perror("pipe");
        exit(-1);
    }

    //il processo padre genera il processo figlio
    pid = fork();
    if (pid < 0) {
        perror("fork");
        exit(-1);
    }

    if (pid == 0) {
        int somma_pari = 0;

        close(fd[0]);

        for (int i = 0; i < sizeof(array); i++) {
            if (array[i] % 2 == 0) {
                somma_pari += array[i];
            }
        }

        if (write(fd[1], &somma_pari, sizeof(somma_pari)) != sizeof(somma_pari)) {
            perror("write");
            close(fd[1]);
            exit(-1);
        }

        close(fd[1]);
        exit(0);
    } else {
        int somma_dispari = 0;
        int somma_pari_figlio = 0;
        ssize_t n;

        close(fd[1]);
        for (int i = 0; i < sizeof(array); i++) {
            if (array[i] % 2 != 0) {
                somma_dispari += array[i];
            }
        }

        n = read(fd[0], &somma_pari_figlio, sizeof(somma_pari_figlio));
        if (n != sizeof(somma_pari_figlio)) {
            if (n < 0) perror("read");
            else fprintf(stderr, "read: dati incompleti\n");
            close(fd[0]);
            exit(-1);
        }
        close(fd[0]);

        printf("Somma numeri pari (figlio):   %d\n", &somma_pari_figlio);
        printf("Somma numeri dispari (padre): %d\n", &somma_dispari);
        printf("Somma totale complessiva:     %d\n", &somma_pari_figlio + somma_dispari);

        return 0;
    }
}
