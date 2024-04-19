using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace encapsulation
{
    class Factorial
    {

        /*
         * The fibonacci sequence is a famous bit of mathematics, and it happens to have a recursive
         * definition. The first two values in the sequence are 0 and 1 (essentially 2 base cases). Each
         * subsequent value is the sum of the previous two values, so the whole sequence is: 0, 1, 1,
         * 2, 3, 5, 8, 13, 21 and so on. Define a recursive fibonacci(n) method that returns the nth
         * fibonacci number, with n=0 representing the start of the sequence.
         */

        public int Fibonacci(int n)
        {
            if (n == 0)
            {
                return 0;
            }
            if (n == 1)
            {
                return 1;
            }

            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Factorial f = new Factorial();
            int a = f.Fibonacci(0); //0
            Console.WriteLine(a);
            int b = f.Fibonacci(1); //1
            Console.WriteLine(b);
            int c = f.Fibonacci(2); //1
            Console.WriteLine(c);
            int d = f.Fibonacci(3); //2
            Console.WriteLine(d);
            int e = f.Fibonacci(6); //8
            Console.WriteLine(e);
        }
    }
}