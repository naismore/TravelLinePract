using Homework2;

public class Square : IShape
{
    private double _side;

    public double Side
    {
        get { return _side; }
        set
        {
            if (value > 0)
            {
                _side = value;
            }
        }
    }
    public Square(double side)
    {
        if (side > 0)
        {
            _side = side;
        }
    }


    public double CalculateArea() => Math.Pow(_side, 2);

    public double CalculatePerimeter() => _side*4;
}