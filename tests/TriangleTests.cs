namespace tests;
using AreaCompute;

public class TriangleTests
{
    [TestCase(3, 4, 5, 6)]
    [TestCase(3, 4, 6, 5.332682251925386)]
    [TestCase(1, 1, 1, 0.4330127018922193)]
    [TestCase(2, 1, 2, 0.9682458365518543)]
    [TestCase(10, 5, 5, 0)]
    [TestCase(5, 5, 10, 0)]
    [TestCase(double.MaxValue, double.MaxValue, double.MaxValue, double.PositiveInfinity)]
    [TestCase(double.MaxValue / 2, double.MaxValue / 2, double.MaxValue / 2, double.PositiveInfinity)]
    [TestCase(double.MaxValue / 2, double.MaxValue / 2, double.MaxValue / 1000, double.PositiveInfinity)]
    [TestCase(double.MaxValue, double.MaxValue / 2, double.MaxValue / 2, 0)]
    public void TriangleArea(double a, double b, double c, double expectedArea)
    {
        double realArea = Triangle.Create(a, b, c).ComputeArea();
        Assert.That(realArea, Is.EqualTo(expectedArea));
    }

    [TestCase(0, 1, 1)]
    [TestCase(0, 0, 0)]
    [TestCase(-1, 0, 1)]
    [TestCase(-1, -1, -1)]
    [TestCase(10, 1, 1)]
    [TestCase(double.NegativeInfinity, 1, 1)]
    [TestCase(1, double.NaN, 1)]
    [TestCase(double.NegativeInfinity, double.PositiveInfinity, 1)]
    public void TriangleCreatingWrongArguments(double a, double b, double c)
    {
        Assert.Throws<ArgumentException>(() => Triangle.Create(a, b, c));
    }

    [TestCase(3, 4, 5, true)]
    [TestCase(3, 4, 6, false)]
    [TestCase(1, 1, 1, false)]
    [TestCase(2, 1, 2, false)]
    [TestCase(10, 5, 5, false)]
    [TestCase(5, 5, 10, false)]
    [TestCase(60, 91, 109, true)]
    [TestCase(109, 91, 60, true)]
    [TestCase(12, 10, 15.620499351813308, true)]
    [TestCase(10, 7.0710678118654755, 7.0710678118654755, true)]
    [TestCase(double.MaxValue, double.MaxValue / 2, double.MaxValue / 2, false)]
    public void IsRightTriangle(double a, double b, double c, bool isRight)
    {
        Assert.That(Triangle.Create(a, b, c).IsRightTriangle(), Is.EqualTo(isRight));
    }
}