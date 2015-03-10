using System;
using System.Globalization;
using System.Threading;

class NumberComparer
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        Console.Write("a = ");
        double a = Double.Parse(Console.ReadLine());
        Console.Write("b = ");
        double b = Double.Parse(Console.ReadLine());
        Console.WriteLine("Greater: { 0}", Math.Max(a,b));
    }
}
