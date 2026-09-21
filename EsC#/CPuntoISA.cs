using System.Runtime.Intrinsics.X86;

class CPunto
{
    private int _x;
    private int _y;

    public int x
    {
        get{return _x;}
        set{_x = value;}
    }
    public int y
    {
        get{return _y;}
        set{_y = value;}
    }

    public CPunto()
    {
        _x = 0;
        _y = 0;
    }

    public CPunto(int x, int y)
    {
        _x = x;
        _y = y;
    }
}

class CCerchio : CPunto
{
    private float _raggio;

    public float raggio
    {
        get{return _raggio;}
        set{_raggio = value;}
    }

    public CRaggio() : base()
    {
        _raggio = 0;
    }

    public CRaggio(int x, int y, float raggio) : base(x, y)
    {
        _raggio = raggio;
    }
}

class CCilindro : CCerchio
{
    private float _altezza;
    
    public float altezza
    {
        get{return _altezza;}
        set{_altezza = value;}
    }

    public CCerchio() : base()
    {
        _altezza = 0;
    }

    public CCerchio(int x, int y, float raggio, float altezza) : base(x, y, raggio)
    {
        _altezza = altezza;
    }
}