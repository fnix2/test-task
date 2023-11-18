namespace AreaCompute;

public readonly struct Circle : IFigure
{
    public double Radius { get; }
    public Circle(double radius)
    {
        if (radius <= 0)
            throw new ArgumentException("Радиус должен быть больше нуля!");

        if (!double.IsFinite(radius))
            throw new ArgumentException("Радиус должен быть конечным числом!");

        Radius = radius;
    }
    public static Circle Create(double radius) => new(radius);
    public double ComputeArea()
    {
        return Math.Pow(Radius, 2) * double.Pi;
    }
}