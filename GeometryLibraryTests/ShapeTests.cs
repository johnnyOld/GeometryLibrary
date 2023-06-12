using GeometryLibrary;

namespace GeometryLibraryTests
{
    public class ShapeTests
    {
        [Test]
        public void Circle_CalculateArea_ReturnsCorrectArea()
        {
            // Arrange
            double radius = 5;
            Circle circle = new(radius);
            AreaVisitor areaVisitor = new();

            // Act
            double result = circle.Accept(areaVisitor);

            // Assert
            double expectedArea = Math.PI * radius * radius;
            Assert.That(result, Is.EqualTo(expectedArea));
        }

        [Test]
        public void Triangle_CalculateArea_ReturnsCorrectArea()
        {
            // Arrange
            double sideA = 3;
            double sideB = 4;
            double sideC = 5;
            Triangle triangle = new(sideA, sideB, sideC);
            AreaVisitor areaVisitor = new();

            // Act
            double result = triangle.Accept(areaVisitor);

            // Assert
            double semiPerimeter = (sideA + sideB + sideC) / 2;
            double expectedArea = Math.Sqrt(semiPerimeter * (semiPerimeter - sideA) * (semiPerimeter - sideB) * (semiPerimeter - sideC));
            Assert.That(result, Is.EqualTo(expectedArea));
        }

        [Test]
        public void Triangle_IsRightTriangle_ReturnsTrue()
        {
            // Arrange
            double sideA = 3;
            double sideB = 4;
            double sideC = 5;
            Triangle triangle = new(sideA, sideB, sideC);

            // Act
            bool isRightTriangle = triangle.IsRightTriangle();

            // Assert
            Assert.That(isRightTriangle, Is.True);
        }

        [Test]
        public void Triangle_IsRightTriangle_ReturnsFalse()
        {
            // Arrange
            double sideA = 2;
            double sideB = 3;
            double sideC = 4;
            Triangle triangle = new(sideA, sideB, sideC);

            // Act
            bool isRightTriangle = triangle.IsRightTriangle();

            // Assert
            Assert.That(isRightTriangle, Is.False);
        }
    }
}
