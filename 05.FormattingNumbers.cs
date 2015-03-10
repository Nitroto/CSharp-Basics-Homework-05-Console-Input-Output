using System;
using System.Globalization;
using System.Threading;

class FormattingNumbers
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        Console.Write("a = ");
        int a = Int32.Parse(Console.ReadLine());
        Console.Write("b = ");
        double b = Double.Parse(Console.ReadLine());
        Console.Write("c = ");
        double c = Double.Parse(Console.ReadLine());
        Console.WriteLine("{0,-10:X}|{1}|{2,10:f2}|{3,-10:f3}", a, Convert.ToString(a, 2).PadLeft(10, '0'), b,c);
    }
}
