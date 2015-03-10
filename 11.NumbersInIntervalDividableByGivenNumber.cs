using System;
using System.Globalization;
using System.Threading;

class NumbersInIntervalDividableByGivenNumber
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        int start = Int32.Parse(Console.ReadLine());
        int stop = Int32.Parse(Console.ReadLine());
        int counter = 0;
        for (int i = start; i <= stop; i++)
        {
            if (i % 5 == 0)
            {
                counter++;
            }
        }
        Console.WriteLine(counter);
    }
}
