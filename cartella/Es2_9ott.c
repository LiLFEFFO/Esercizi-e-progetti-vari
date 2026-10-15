#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <sys/wait.h>
#include <ctype.h>
#include <string.h>

int main() {
    int pipe1[2], pipe2[2];
    pid_t pid;
    char testo[256];
    int vocali = 0;

    pipe(pipe1);
    pipe(pipe2);

    pid = fork();

    if (pid == 0) {
        close(pipe1[1]);
        close(pipe2[0]);

        read(pipe1[0], testo, sizeof(testo));
        close(pipe1[0]);

        for (int i = 0; testo[i] != '\0'; i++) {
            testo[i] = toupper((unsigned char)testo[i]);

            if (testo[i] == 'A' || testo[i] == 'E' || testo[i] == 'I' || testo[i] == 'O' || testo[i] == 'U') {
                vocali++;
            }
        }

        write(pipe2[1], testo, sizeof(testo));
        write(pipe2[1], &vocali, sizeof(vocali));

        close(pipe2[1]);
        exit(0);
    } else {
        close(pipe1[0]);
        close(pipe2[1]);

        printf("Inserisci una stringa: ");
        fgets(testo, sizeof(testo), stdin);
        testo[strcspn(testo, "\n")] = '\0';

        write(pipe1[1], testo, sizeof(testo));
        close(pipe1[1]);

        read(pipe2[0], testo, sizeof(testo));
        read(pipe2[0], &vocali, sizeof(vocali));

        close(pipe2[0]);

        wait(NULL);

        printf("Stringa maiuscola: %s\n", testo);
        printf("Numero di vocali: %d\n", vocali);
    }

    return 0;
}
