using AreaCompute;

Console.WriteLine($"Площадь треугольника со сторонами 5, 6, 5: {Triangle.Create(5, 6, 5).ComputeArea()}");
Console.WriteLine($"Треугольник со сторонами 3, 4, 5 {(Triangle.Create(3, 4, 5)
    .IsRightTriangle() ? "является" : "не является")} прямоугольным");
Console.WriteLine($"Площадь круга с радиусом 1: {Circle.Create(1).ComputeArea()}");