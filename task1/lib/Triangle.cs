namespace AreaCompute;

public readonly struct Triangle : IFigure
{
    public double A { get; }
    public double B { get; }
    public double C { get; }
    public Triangle(double aSideLength, double bSideLength, double cSideLength)
    {
        double[] arguments = { aSideLength, bSideLength, cSideLength };

        if (arguments.Any(arg => arg <= 0))
            throw new ArgumentException("Все длины сторон треугольника должны быть больше нуля!");

        if (arguments.Any(arg => !double.IsFinite(arg)))
            throw new ArgumentException("Все длины сторон треугольника должны быть конечными числами!");

        if (!IsThisTriangleCanExist(aSideLength, bSideLength, cSideLength))
            throw new ArgumentException("Треугольник с такими сторонами не может существовать!");

        A = aSideLength;
        B = bSideLength;
        C = cSideLength;
    }

    public static Triangle Create(double aSideLength, double bSideLength, double cSideLength)
    {
        return new(aSideLength, bSideLength, cSideLength);
    }

    public double ComputeArea()
    {
        double p = A / 2 + B / 2 + C / 2;
        return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
    }

    public bool IsRightTriangle()
    {
        double a = A, b = B, c = C;

        // Добиваемся того, чтобы длины сторон располагались так: a <= b <= c
        if (b > c)
            (b, c) = (c, b);
        if (a > b)
            (a, b) = (b, a);
        if (b > c)
            (b, c) = (c, b);

        // Наивная реализация, не учитывающая, что возведение в квадрат может дать Infinity, хотя
        // 'c' при этом может быть меньше double.MaxValue
        if (c == Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2)))
            return true;
        return false;
    }

    private static bool IsThisTriangleCanExist(double a, double b, double c)
    {
        // Будем считать что треугольник с углами 0 градусов возможен, просто
        // лежит на одной линии и его площадь 0
        return a + b >= c && a + c >= b && b + c >= a;
    }
}