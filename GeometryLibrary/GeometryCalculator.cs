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
        private double radius;

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
        private double sideA;
        private double sideB;
        private double sideC;

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
    class Program
    {
        static void Main(string[] args)
        {
            Circle circle = new Circle(5);
            Triangle triangle = new Triangle(3, 4, 5);

            AreaVisitor areaVisitor = new AreaVisitor();

            double circleArea = circle.Accept(areaVisitor);
            double triangleArea = triangle.Accept(areaVisitor);

            Console.WriteLine("Circle area: " + circleArea);
            Console.WriteLine("Triangle area: " + triangleArea);

            Console.ReadKey();
        }
    }
}
