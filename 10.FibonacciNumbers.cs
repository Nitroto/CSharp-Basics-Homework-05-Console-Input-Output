using System;
using System.Globalization;
using System.Threading;

class FibonacciNumbers
{
    static void Main(string[] args)
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        int n = Int32.Parse(Console.ReadLine());
        int a = 0;
        int b = 1;
        if (n == 1)
        {
                Console.WriteLine("{0}", a);
        }
        else
        {
            Console.Write("{0} {1} ", a, b);
            for (int i = 2; i < n; i++)
            {
                int temp = a;
                a = b;
                b = temp + b;
                Console.Write("{0} ", b);
            }
            Console.WriteLine();
        }
    }
}
