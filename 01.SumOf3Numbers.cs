using System;
using System.Threading;
using System.Globalization;
class PrintCompanyInformation
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
        Console.WriteLine("sum = {0}", a + b + c); 
    }
}
