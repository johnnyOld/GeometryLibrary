namespace GeometryLibrary
{
    public interface IShapeVisitor
    {
        double Visit(Circle circle);
        double Visit(Triangle triangle);
    }

    public abstract class Shape
    {
        public abstract double Accept(IShapeVisitor visitor);
    }

    public class Circle : Shape
    {
        private readonly double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public override double Accept(IShapeVisitor visitor)
        {
            return visitor.Visit(this);
        }

        public double GetRadius()
        {
            return radius;
        }
    }

    public class Triangle : Shape
    {
        private readonly double sideA;
        private readonly double sideB;
        private readonly double sideC;

        public Triangle(double sideA, double sideB, double sideC)
        {
            this.sideA = sideA;
            this.sideB = sideB;
            this.sideC = sideC;
        }

        public override double Accept(IShapeVisitor visitor)
        {
            return visitor.Visit(this);
        }

        public double GetSideA()
        {
            return sideA;
        }

        public double GetSideB()
        {
            return sideB;
        }

        public double GetSideC()
        {
            return sideC;
        }
        public bool IsRightTriangle()
        {
            // Проверка на прямоугольность треугольника по теореме Пифагора
            double aSquare = sideA * sideA;
            double bSquare = sideB * sideB;
            double cSquare = sideC * sideC;

            return (aSquare + bSquare == cSquare) || (aSquare + cSquare == bSquare) || (bSquare + cSquare == aSquare);
        }
    }

    public class AreaVisitor : IShapeVisitor
    {
        public double Visit(Circle circle)
        {
            double radius = circle.GetRadius();
            return Math.PI * radius * radius;
        }

        public double Visit(Triangle triangle)
        {
            double sideA = triangle.GetSideA();
            double sideB = triangle.GetSideB();
            double sideC = triangle.GetSideC();

            // Используем формулу Герона для вычисления площади треугольника
            double semiPerimeter = (sideA + sideB + sideC) / 2;
            return Math.Sqrt(semiPerimeter * (semiPerimeter - sideA) * (semiPerimeter - sideB) * (semiPerimeter - sideC));
        }
    }

    public class GeometryCalculator
    {
        static void Main(string[] args)
        {
            Circle circle = new(5);
            Triangle triangle = new(3, 4, 5);

            AreaVisitor areaVisitor = new();

            double circleArea = circle.Accept(areaVisitor);
            double triangleArea = triangle.Accept(areaVisitor);
            bool isRightTriangle = triangle.IsRightTriangle();

            Console.WriteLine("Circle area: " + circleArea);
            Console.WriteLine("Triangle area: " + triangleArea);
            Console.WriteLine("Triangle is right: " + isRightTriangle);

            Console.ReadKey();
        }
    }
}
