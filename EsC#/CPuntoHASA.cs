using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

class CPunto
{
    private int _x;
    private int _y;

    public float x
    {
        get{return _x;}
        set{_x = value;}
    }
    public float y
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

class CCerchio
{
    private CPunto _centro;
    private int _raggio;

    public CPunto centro
    {
        get{return _centro;}
        set{_centro = value;}
    }

    public int raggio
    {
        get{return _raggio;}
        set{_raggio = value;}
    }

    public CCerchio()
    {
        _centro = new CCerchio();
        _raggio = 0;
    }

    public CCerchio(CPunto centro, int raggio)
    {
        _centro = centro;
        _raggio = raggio;
    }
}

class CCilindro
{
    private int _altezza;
    private CCerchio _base;
    public int altezza
    {
        get{return _altezza;}
        set{_altezza = value;}
    }

    public CCerchio Base
    {
        get{return _base;}
        set{_base = value;}
    }

    public CCilindro()
    {
        _altezza = 0;
        _base = new CCilindro();
    }

    public CCilindro(CCerchio Base, int altezza)
    {
        _altezza = altezza;
        _base = Base;
    }
}