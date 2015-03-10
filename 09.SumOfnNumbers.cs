using System;
using System.Globalization;
using System.Threading;

class SumOfnNumbers
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        int n = Int32.Parse(Console.ReadLine());
        double num;
        double sum = 0;
        for (int i = 0; i < n; i++)
        {
            num = Double.Parse(Console.ReadLine());
            sum += num; 
        }
        Console.WriteLine("Sum = {0}", sum);
    }
}
