using System;
using System.Globalization;
using System.Linq;
using System.Threading;

class SumOf5Numbers
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        string[] input = Console.ReadLine().Split(' ');
        double[] numbers = new double[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            numbers[i] = Double.Parse(input[i]);
        }
        Console.WriteLine("Sum = {0}", numbers.Sum());
    }
}
