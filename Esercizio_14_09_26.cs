class CMoto
{
    private string _Targa;
    private string _Marca;
    private string _Modello;
    private float _PrezzoBase;
    private float _Chilometraggio;
    private int _Cilindrata;
    private float _Serbatoio;

    public string Targa
    {
        get{return _Targa;}
        set{_Targa = value;}
    }

    public string Marca
    {
        get{return _Marca;}
        set{_Marca = value;}
    }

    public string Modello
    {
        get{return _Modello;}
        set{_Modello = value;}
    }

    public float PrezzoBase
    {
        get{return _PrezzoBase;}
        set{_PrezzoBase = value;}
    }

    public float Chilometraggio
    {
        get{return _Chilometraggio;}
        set{_Chilometraggio = value;}
    }

    public int Cilindrata
    {
        get{return _Cilindrata;}
        set{_Cilindrata = value;}
    }

    public float Serbatoio
    {
        get{return _Serbatoio;}
        set{_Serbatoio = value;}
    }


    public CMoto(string targa, string marca, string mdoello, float prezzobase, float chilometraggio, int cilindrata, float serbatoio)
    {
        _Targa = targa;
        _Marca = marca;
        _Modello = mdoello;
        _PrezzoBase = prezzobase;
        _Chilometraggio = chilometraggio;
        _Cilindrata = cilindrata;
        _Serbatoio = serbatoio;
    }

    public CMoto()
    {
        _Targa = "";
        _Marca = "";
        _Modello = "";
        _PrezzoBase = 0.0f;
        _Chilometraggio = 0.0f;
        _Cilindrata = 0;
        _Serbatoio = 0.0f;
    }

    public override string ToString()
    {
        return $"Targa: {_Targa}, Marca: {_Marca}, Prezzo Base: {_PrezzoBase}, Chilometraggio: {_Chilometraggio}, Cilindrata: {_Cilindrata}, Serbatoio: {_Serbatoio}";
    }

    public void AggiornaChilometraggio(float kmPercorsi)
    {
        _Chilometraggio = kmPercorsi;
    }
}

class COfficina()
{
    private string _Nome;
    private string _Indirizzo;
    private CMoto[] _Elenco;

    public string Nome
    {
        get{return _Nome;}
        set{_Nome = value;}
    }

    public string Indirizzo
    {
        get{return _Indirizzo;}
        set{_Indirizzo = value;}
    }

    public CMoto[] Elenco
    {
        get{return _Elenco;}
        set{_Elenco = value;}
    }

    public COfficina()
    {
        _Nome = "";
        _Indirizzo = "";
        _Elenco = new CMoto[0];
    }

    public COfficina(string nome, string indirizzo, CMoto[] elenco)
    {
        _Nome = nome;
        _Indirizzo = indirizzo;
        _Elenco = elenco;
    }

    public void MotoDaRiparare()
    {
        CMoto[] _Elenco = new CMoto[_Elenco.Length + 1];
    }

    public float CalcolaCostoDiRiparazione(CMoto moto)
    {
        float prezzobase = moto.PrezzoBase + moto.Cilindrata;
        float coefficienteChilometri = 0.0f;
        if (moto.Chilometraggio <= 5_000)
        {
            coefficientChilometraggio = 1.00f;
        }
        else if (moto.Chilometraggio <= 20_000)
        {
            coefficientChilometraggio = 0.95f;
        }
        else if (moto.Chilometraggio <= 40_000)
        {
            coefficientChilometraggio = 0.85f;
        }
        else if (moto.Chilometraggio <= 70_000)
        {
            coefficientChilometraggio = 0.72f;
        }
        else
        {
            coefficientChilometraggio = 0.58f;
        }

        float prezzofinale = prezzobase * coefficienteChilometri;

        return prezzofinale;
    }

    public float ProvaCalcoloSconto(float percentuale)
    {
        
        if(percentuale >= 5 && percentuale <= 20)
        {
            
        } else
        {
            return 0;
        }
    }

    public string ListaMoto()
    {
        string stringa = "";

        for(int i = 0; i < _Elenco.Length; i++)
        {
            stringa += $"{_Elenco[i]}";
        }

        return stringa;
    }

    public override string ToString()
    {
        string stringa = $"Nome: {_Nome}, Indirizzo: {_Indirizzo}, ";
        for(int i = 0; i < _Elenco.Length; i++)
        {
            stringa += Console.WriteLine(_Elenco[i].ToString());
        }
    }
}
