using encapsulation;
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
        public int BunnyEars(int bunnies)
        {
            if (bunnies == 0)
            {
                return 0;
            }
            return 2 + BunnyEars(bunnies - 1);
        }

        internal class Program
        {
            static void Main(string[] args)
            {
                Factorial f = new Factorial();
                int  a = f.BunnyEars(2); //2
                Console.WriteLine(a);
                int b = f.BunnyEars(4); //2
                Console.WriteLine(b);
                int c = f.BunnyEars(100); //2
                Console.WriteLine(c);
            }
        }
    }
}