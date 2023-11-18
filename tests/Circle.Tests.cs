namespace tests;
using AreaCompute;

public class CircleTests
{
    [TestCase(1, double.Pi)]
    [TestCase(2, 12.566370614359172)]
    [TestCase(10.5, 346.3605900582747)]
    public void CircleArea(double radius, double expectedArea)
    {
        Assert.That(Circle.Create(radius).ComputeArea(), Is.EqualTo(expectedArea));
    }

    [TestCase(1 / 1.7724538509055159, 1)]
    [TestCase(2 / 1.7724538509055159, 4)]
    public void CircleAreaApproximateEqual(double radius, double expectedArea)
    {
        Assert.That(Circle.Create(radius).ComputeArea(), Is.EqualTo(expectedArea).Within(0.000000000001));
    }

    [TestCase(0)]
    [TestCase(-1)]
    [TestCase(double.NaN)]
    [TestCase(double.PositiveInfinity)]
    [TestCase(double.NegativeInfinity)]
    public void CircleCreatingWrongArguments(double radius)
    {
        Assert.Throws<ArgumentException>(() => Circle.Create(radius));
    }
}