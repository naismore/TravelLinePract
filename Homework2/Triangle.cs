using Homework2;

public class Triangle : IShape
{
    private double _a, _b, _c, _p, _s;
    public double A
    {
        get { return _a; }
        set
        {
            if (value > 0)
            {
                _a = value;
            }
        }
    }

    public double B
    {
        get { return _b; }
        set
        {
            if (value > 0)
            {
                _b = value;
            }
        }
    }

    public double C
    {
        get { return _c; }
        set
        {
            if (value > 0)
            {
                _c = value;
            }
        }
    }

    public Triangle(double a, double b, double c)
    {
        if (a > 0 && b > 0 && c > 0)
        {
            _a = a;
            _b = b;
            _c = c;
        }
    }

    public double CalculateArea()
    {
        _p = (_a + _b + _c) / 2;
        _s = Math.Sqrt(_p*(_p-_a)*(_p-_b)*(_p-_c));
        return _s;
    }

    public double CalculatePerimeter() => _a + _b + _c;
}