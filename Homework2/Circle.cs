using Homework2;

class Circle : IShape
{
    private double _radius = 0;

    public double Radius
    {
        get { return _radius; }
        set
        {
            if (value > 0)
            {
                _radius = value;
            }
        }
    }

    public Circle(double radius)
    {
        if (radius > 0)
        {
            _radius = radius;
        }
    }

    public double CalculateArea() => Math.PI * Math.Pow(_radius, 2);

    public double CalculatePerimeter() => 2 * Math.PI * _radius;
}