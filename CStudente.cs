using System.ComponentModel;

public class CStudente
{
    private string _nome;
    private int[] _voti = new int[5];

    public string nome
    {
        get {return _nome;}
        set {_nome = value;}
    }
    
    public int[] voti
    {
        get {return _voti;}
        set {_voti = 0;}
    }

    public CStudente(string nome)
    {
        _nome = nome;
    }

    public void InserisciVoto(int posizione, int voto)
    {
        if((posizione >= 0 && posizione < 5) && (voto >= 1 && voto <= 10))
        {
            _voti[posizione] = voto;
        } else
        {
            Console.WriteLine("Posizione o voto non valida/o");
        }
    }

    public double CalcolaMedia()
    {
        int somma = 0;
        double media;
        for(int i = 0; i < 5; i++)
        {
            somma += _voti[i];
        }

        media = somma / 5;
        return media;
    }

    public int VotoMassimo()
    {
        int massimo = _voti[0];

        for(int i = 1; i < 5; i++)
        {
            if(_voti[i] > massimo)
                massimo = _voti[i];
        }

        return massimo;
    }

    public int VotoMinimo()
    {
        int minimo = _voti[0];

        for(int i = 1; i < 5; i++)
        {
            if(_voti[i] < minimo)
                minimo = _voti[i];
        }

        return minimo;
    }

    public void StampaVoti()
    {
        Console.WriteLine($"Lo studente si chiama {_nome} e i suoi voti sono:");

        for(int i = 0; i < 5; i++)
        {
            Console.WriteLine($"{_voti[i]}");
        }
    }
}