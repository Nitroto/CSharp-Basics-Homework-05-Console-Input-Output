using System;
using System.Globalization;
using System.Threading;

class QuadraticEquation
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        Console.Write("a = ");
        double a = Double.Parse(Console.ReadLine());
        Console.Write("b = ");
        double b = Double.Parse(Console.ReadLine());
        Console.Write("c = ");
        double c = Double.Parse(Console.ReadLine());
        double determinant = b * b - 4 * a * c;
        if (determinant >= 0)
        {
            if (determinant > 0)
            {
                double x1 = (-b + Math.Sqrt(determinant))/(2*a);
                double x2 = (-b - Math.Sqrt(determinant)) / (2 * a);
                Console.WriteLine("x1 = {0}\r\nx2 = {1}", x1, x2);
            }
            else
            {
                Console.WriteLine("x1 = x2 = {0}", -(b/(2*a)));
            }
        }
        else
        {
            Console.WriteLine("no real roots");
        }
    }
}
