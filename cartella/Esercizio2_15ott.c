#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <ctype.h>
#include <unistd.h>

// Struct scambiata dal figlio al padre tramite pipe2
struct Messaggio {
    char testo_maiuscolo[256];
    int num_vocali;
};

// Dice se un carattere (gia' maiuscolo) e' una vocale
static int e_vocale(char c) {
    return (c == 'A' || c == 'E' || c == 'I' || c == 'O' || c == 'U');
}

int main(void) {
    int pipe1[2]; // padre -> figlio (stringa originale)
    int pipe2[2]; // figlio -> padre (struct Messaggio)
    pid_t pid;
    char input[256];

    // Il padre crea entrambe le pipe prima della fork
    if (pipe(pipe1) == -1) {
        perror("pipe1");
        exit(-1);
    }
    if (pipe(pipe2) == -1) {
        perror("pipe2");
        exit(-1);
    }

    // Il padre genera il figlio
    pid = fork();
    if (pid < 0) {
        perror("fork");
        exit(-1);
    }

    if (pid == 0) {
        //processo figlio
        char buffer[256];
        ssize_t n;
        size_t len;
        struct Messaggio msg;

        // Il figlio legge da pipe1 e scrive su pipe2
        close(pipe1[1]); // chiude scrittura di pipe1 (non usata)
        close(pipe2[0]); // chiude lettura di pipe2 (non usata)

        // Legge la stringa inviata dal padre
        n = read(pipe1[0], buffer, sizeof(buffer) - 1);
        if (n <= 0) {
            if (n < 0) perror("read pipe1");
            else fprintf(stderr, "read pipe1: nessun dato\n");
            close(pipe1[0]);
            close(pipe2[1]);
            exit(-1);
        }
        buffer[n] = '\0'; // termina la stringa ricevuta
        close(pipe1[0]);  // finito di leggere da pipe1

        // Trasforma in maiuscolo e conta le vocali
        msg.num_vocali = 0;
        len = strlen(buffer);
        if (len > sizeof(msg.testo_maiuscolo) - 1) {
            len = sizeof(msg.testo_maiuscolo) - 1; // evita overflow
        }
        for (size_t i = 0; i < len; i++) {
            msg.testo_maiuscolo[i] = (char) toupper((unsigned char) buffer[i]);
            if (e_vocale(msg.testo_maiuscolo[i])) {
                msg.num_vocali++; // conta la vocale trovata
            }
        }
        msg.testo_maiuscolo[len] = '\0'; // termina la stringa maiuscola

        // Invia la struct al padre tramite pipe2
        if (write(pipe2[1], &msg, sizeof(msg)) != sizeof(msg)) {
            perror("write pipe2");
            close(pipe2[1]);
            exit(-1);
        }

        // Chiude pipe2 e termina
        close(pipe2[1]);
        exit(0);
    } else {
        size_t len;
        struct Messaggio ricevuto;
        ssize_t n;

        // Il padre scrive su pipe1 e legge da pipe2
        close(pipe1[0]); // chiude lettura di pipe1 (non usata)
        close(pipe2[1]); // chiude scrittura di pipe2 (non usata)

        // Legge la stringa da tastiera
        printf("Inserisci una stringa: ");
        fflush(stdout);
        if (fgets(input, sizeof(input), stdin) == NULL) {
            fprintf(stderr, "Errore lettura input\n");
            close(pipe1[1]);
            close(pipe2[0]);
            exit(-1);
        }
        // Rimuove il newline finale se presente
        len = strlen(input);
        if (len > 0 && input[len - 1] == '\n') {
            input[len - 1] = '\0';
        }

        // Invia la stringa al figlio tramite pipe1
        // (+1 per includere il terminatore)
        len = strlen(input) + 1;
        if (write(pipe1[1], input, len) != (ssize_t) len) {
            perror("write pipe1");
            close(pipe1[1]);
            close(pipe2[0]);
            exit(-1);
        }
        close(pipe1[1]); // finito di scrivere su pipe1

        // Legge la struct inviata dal figlio tramite pipe2
        n = read(pipe2[0], &ricevuto, sizeof(ricevuto));
        if (n != sizeof(ricevuto)) {
            if (n < 0) perror("read pipe2");
            else fprintf(stderr, "read pipe2: dati incompleti\n");
            close(pipe2[0]);
            exit(-1);
        }
        close(pipe2[0]);

        // Stampa la stringa maiuscola e il numero di vocali
        printf("Stringa maiuscola: %s\n", ricevuto.testo_maiuscolo);
        printf("Numero di vocali: %d\n", ricevuto.num_vocali);

        return 0;
    }
}
