using System;
using Xunit;
using Triangle2; // Убедитесь, что это правильное пространство имен

namespace Triangle2.Tests
{
    public class TriangleTests
    {
        [Fact]
        public void TestAcuteTriangle()
        {
            var (type, area) = Triangle.GetTriangleProperties(3, 4, 5);
            Assert.Equal("Прямоугольный треугольник", type);
            Assert.Equal(6, area, 6); // Площадь
        }

        [Fact]
        public void TestObtuseTriangle()
        {
            var (type, area) = Triangle.GetTriangleProperties(2, 3, 4);
            Assert.Equal("Тупоугольный треугольник", type);
            Assert.Equal(2.904737509, area, 6); // Площадь
        }

        [Fact]
        public void TestRightTriangle()
        {
            var (type, area) = Triangle.GetTriangleProperties(6, 8, 10);
            Assert.Equal("Прямоугольный треугольник", type);
            Assert.Equal(24, area, 6); // Площадь
        }

        [Fact]
        public void TestInvalidTriangleSides()
        {
            Assert.Throws<ArgumentException>(() => Triangle.GetTriangleProperties(1, 2, 3));
            Assert.Throws<ArgumentException>(() => Triangle.GetTriangleProperties(-1, 2, 2));
            Assert.Throws<ArgumentException>(() => Triangle.GetTriangleProperties(0, 1, 1));
            Assert.Throws<ArgumentException>(() => Triangle.GetTriangleProperties(1, 1, -1));
        }

        [Fact]
        public void TestZeroOrNegativeSides()
        {
            Assert.Throws<ArgumentException>(() => Triangle.GetTriangleProperties(0, 1, 1));
            Assert.Throws<ArgumentException>(() => Triangle.GetTriangleProperties(1, -1, 1));
            Assert.Throws<ArgumentException>(() => Triangle.GetTriangleProperties(1, 1, 0));
        }

        [Fact]
        public void TestLargeTriangle()
        {
            var (type, area) = Triangle.GetTriangleProperties(100, 200, 250);
            Assert.Equal("Остроугольный треугольник", type);
            Assert.Equal(9849.999999999998, area, 6); // Площадь
        }
    }
}
