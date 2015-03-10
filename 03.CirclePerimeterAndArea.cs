using System;
using System.Threading;
using System.Globalization;

class CirclePerimeterAndArea
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        Console.Write("r = ");
        double r = Double.Parse(Console.ReadLine());
        double perimeter = 2 * Math.PI * r;
        double area = Math.PI * r * r;
        Console.WriteLine("Perimeter = {0:f2}", perimeter);
        Console.WriteLine("Area = {0:f2}", area);
    }
}
