static void Main()
{
    CTombola tombola = new CTombola();

    tombola.Preparazione();
    tombola.Turno();
    tombola.Turno();
    tombola.Turno();
}

class CTombola
{
    private int?[,] _Tabellone;  // matrice 9x10, nullable: null = casella vuota
    private int[]   _Cartella;   // i 5 numeri assegnati al giocatore
    private bool[]  _Marcati;    // _Marcati[i] = true se _Cartella[i] è già uscito
    private int[]   _Sacchetto;  // numeri ancora da estrarre
    private int     _Rimasti;    // quanti numeri sono ancora nel sacchetto

    private Random _Rng;

    public int?[,] Tabellone
    {
        get => _Tabellone;
        set => _Tabellone = value;
    }

    public int[] Cartella
    {
        get => _Cartella;
        set => _Cartella = value;
    }

    public bool[] Marcati
    {
        get => _Marcati;
        set => _Marcati = value;
    }

    public int Rimasti
    {
        get => _Rimasti;
        set => _Rimasti = value;
    }

    public CTombola()
    {
        _Tabellone = new int?[9, 10];
        _Cartella  = new int[5];
        _Marcati   = new bool[5];
        _Sacchetto = new int[45];  // il tabellone ha sempre 5 numeri per colonna: 5 * 9 = 45 totali
        _Rimasti   = 45;
        _Rng       = new Random();
    }

    public void Preparazione()
    {
        int idx = 0;

        for (int col = 0; col < 10; col++)
        {
            int da    = col * 9 + 1;
            int a     = (col == 9) ? 90 : da + 8;
            int range = a - da + 1;

            int[] righe  = ScegliCinque(9);    // 5 righe casuali su 9 disponibili
            int[] numeri = ScegliCinque(range); // 5 indici casuali nella colonna

            for (int i = 0; i < 5; i++)
            {
                int numero = da + numeri[i];       // da + indice = numero reale della colonna
                _Tabellone[righe[i], col] = numero;
                _Sacchetto[idx++] = numero;        // aggiunge anche al sacchetto
            }
        }

        // Sceglie 5 posizioni casuali nel sacchetto e copia quei numeri nella cartella
        int[] posizioniCartella = ScegliCinque(45);
        for (int i = 0; i < 5; i++)
            _Cartella[i] = _Sacchetto[posizioniCartella[i]];
    }

    public int Turno()
    {
        if (_Rimasti == 0)
            return -1;

        int pos    = _Rng.Next(_Rimasti);  // indice casuale tra i numeri ancora disponibili
        int numero = _Sacchetto[pos];

        // Rimuove il numero estratto senza spostare elementi:
        // lo sovrascrive con l'ultimo elemento valido e scala _Rimasti di 1
        _Sacchetto[pos] = _Sacchetto[--_Rimasti];

        // Controlla se il numero è nella cartella e in caso lo marchia
        for (int i = 0; i < 5; i++)
            if (_Cartella[i] == numero)
                _Marcati[i] = true;

        return numero;
    }

    // Restituisce un array di 5 indici unici casuali nell'intervallo 0 - max
    private int[] ScegliCinque(int max)
    {
        int[] scelti = new int[5];
        int trovati  = 0;

        while (trovati < 5)
        {
            int n = _Rng.Next(max);
            bool duplicato = false;

            // Controlla che n non sia già stato scelto
            for (int i = 0; i < trovati; i++)
                if (scelti[i] == n) { duplicato = true; break; }

            if (!duplicato)
                scelti[trovati++] = n;
        }

        return scelti;
    }
}