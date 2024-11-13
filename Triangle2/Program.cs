using System;

namespace Triangle2
{
    public class Triangle
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Введите длины сторон треугольника (a, b, c):");
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());

            try
            {
                var (triangleType, area) = GetTriangleProperties(a, b, c);
                Console.WriteLine($"Вид треугольника: {triangleType}");
                Console.WriteLine($"Площадь треугольника: {area}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        public static (string triangleType, double area) GetTriangleProperties(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("Длины сторон должны быть положительными числами.");
            }

            if (a + b <= c || a + c <= b || b + c <= a)
            {
                throw new ArgumentException("Сумма двух сторон должна быть больше третьей стороны.");
            }

            double p = (a + b + c) / 2;
            double area = Math.Sqrt(p * (p - a) * (p - b) * (p - c));

            string triangleType;
            double a2 = a * a;
            double b2 = b * b;
            double c2 = c * c;

            if (a2 + b2 > c2 && a2 + c2 > b2 && b2 + c2 > a2)
            {
                triangleType = "Остроугольный треугольник";
            }
            else if (a2 + b2 == c2 || a2 + c2 == b2 || b2 + c2 == a2)
            {
                triangleType = "Прямоугольный треугольник";
            }
            else
            {
                triangleType = "Тупоугольный треугольник";
            }

            return (triangleType, area);
        }
    }
}
