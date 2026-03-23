using System;
using System.Threading;

class Labirinto
{
    static int n;
    static char[,] grid;
    static bool[,] visited;
    static Random rand = new Random();

    static int[] dx = { -1, 1, 0, 0 };
    static int[] dy = { 0, 0, -1, 1 };

    static void Main()
    {
        do
        {
            Console.Write("Inserisci la dimensione (minimo 4): ");
        } while (!int.TryParse(Console.ReadLine(), out n) || n < 4);

        grid = new char[n, n];
        visited = new bool[n, n];

        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                grid[i, j] = '*';

        GeneraLabirinto(1, 1);

        grid[1, 0] = ' ';
        grid[n - 2, n - 1] = ' ';

        Console.Clear();
        Stampa();

        Console.WriteLine("\nPremi un tasto per avviare...");
        Console.ReadKey();

        TrovaUscita(1, 0);

        Console.WriteLine("\nUscita trovata!");
    }

    static void GeneraLabirinto(int x, int y)
    {
        grid[x, y] = ' ';

        int[] dx2 = { -2, 2, 0, 0 };
        int[] dy2 = { 0, 0, -2, 2 };

        for (int i = 0; i < 4; i++)
        {
            int r = rand.Next(4);
            (dx2[i], dx2[r]) = (dx2[r], dx2[i]);
            (dy2[i], dy2[r]) = (dy2[r], dy2[i]);
        }

        for (int i = 0; i < 4; i++)
        {
            int nx = x + dx2[i];
            int ny = y + dy2[i];

            if (nx > 0 && ny > 0 && nx < n - 1 && ny < n - 1 && grid[nx, ny] == '*')
            {
                grid[x + dx2[i] / 2, y + dy2[i] / 2] = ' ';
                GeneraLabirinto(nx, ny);
            }
        }
    }

    static bool TrovaUscita(int x, int y)
    {
        if (x < 0 || y < 0 || x >= n || y >= n)
            return false;

        if (grid[x, y] == '*' || visited[x, y])
            return false;

        visited[x, y] = true;

        char temp = grid[x, y];
        grid[x, y] = 'F';

        Console.Clear();
        Stampa();
        Thread.Sleep(40);

        // uscita
        if (x == n - 2 && y == n - 1)
            return true;

        for (int i = 0; i < 4; i++)
        {
            if (TrovaUscita(x + dx[i], y + dy[i]))
            {
                grid[x, y] = '.'; // percorso giusto
                return true;
            }
        }

        // torna indietro (non fa parte del percorso)
        grid[x, y] = temp;

        return false;
    }

    static void Stampa()
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
                Console.Write(grid[i, j]);
            Console.WriteLine();
        }
    }
}using System;
using System.Threading;

class Labirinto
{
    static int n;
    static char[,] grid;
    static bool[,] visited;
    static Random rand = new Random();

    static int[] dx = { -1, 1, 0, 0 };
    static int[] dy = { 0, 0, -1, 1 };

    static void Main()
    {
        do
        {
            Console.Write("Inserisci la dimensione (minimo 4): ");
        } while (!int.TryParse(Console.ReadLine(), out n) || n < 4);

        grid = new char[n, n];
        visited = new bool[n, n];

        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                grid[i, j] = '*';

        GeneraLabirinto(1, 1);

        grid[1, 0] = ' ';
        grid[n - 2, n - 1] = ' ';

        Console.Clear();
        Stampa();

        Console.WriteLine("\nPremi un tasto per avviare...");
        Console.ReadKey();

        TrovaUscita(1, 0);

        Console.WriteLine("\nUscita trovata!");
    }

    static void GeneraLabirinto(int x, int y)
    {
        grid[x, y] = ' ';

        int[] dx2 = { -2, 2, 0, 0 };
        int[] dy2 = { 0, 0, -2, 2 };

        for (int i = 0; i < 4; i++)
        {
            int r = rand.Next(4);
            (dx2[i], dx2[r]) = (dx2[r], dx2[i]);
            (dy2[i], dy2[r]) = (dy2[r], dy2[i]);
        }

        for (int i = 0; i < 4; i++)
        {
            int nx = x + dx2[i];
            int ny = y + dy2[i];

            if (nx > 0 && ny > 0 && nx < n - 1 && ny < n - 1 && grid[nx, ny] == '*')
            {
                grid[x + dx2[i] / 2, y + dy2[i] / 2] = ' ';
                GeneraLabirinto(nx, ny);
            }
        }
    }

    static bool TrovaUscita(int x, int y)
    {
        if (x < 0 || y < 0 || x >= n || y >= n)
            return false;

        if (grid[x, y] == '*' || visited[x, y])
            return false;

        visited[x, y] = true;

        char temp = grid[x, y];
        grid[x, y] = 'F';

        Console.Clear();
        Stampa();
        Thread.Sleep(40);

        // uscita
        if (x == n - 2 && y == n - 1)
            return true;

        for (int i = 0; i < 4; i++)
        {
            if (TrovaUscita(x + dx[i], y + dy[i]))
            {
                grid[x, y] = '.'; // percorso giusto
                return true;
            }
        }

        // torna indietro (non fa parte del percorso)
        grid[x, y] = temp;

        return false;
    }

    static void Stampa()
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
                Console.Write(grid[i, j]);
            Console.WriteLine();
        }
    }
}
