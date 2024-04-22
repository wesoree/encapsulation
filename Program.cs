using System;
using System.Collections.Generic;
using System.ComponentModel;
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
                return 0;
            
            if (n == 1)
                return 1;
            

            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        public string ChangeA(string str)
        {
            

            if (str.Length < 1)
                return "";

            if (str[0] == 'a')
            {
                return "-" + ChangeA(str.Substring(1));
            }

            return str[0] + ChangeA(str.Substring(1));
        }

        public static int Triangle(int n)
        {
            if (n == 0)
                return 0;

            return n + Triangle(n - 1);
        }

        public static int CountNegative(int[] nums)
        {
            int count = 0;
            foreach (int n in nums)
            {
                if (n < 0)
                    count += 1;
            }
            return count;
        }

        public static int[] ConcatArray(int[] a, int[] b)
        {
            int newLength = a.Length + b.Length;
            int[] newArr = new int[newLength];
            int cursor = 0;
            for (int i = 0; i < newArr.Length; i++, cursor++)
                newArr[cursor] = b[i - b.Length];

            return newArr;
        }

        /*
    1. Recursively convert all letter 'a' to a hyphen '-'
    2. Trace the call stack for Triangle(4)
    3. Given an array of ints, create a STATIC method
       to count all numbers lower than 0
    pre 4. Create a method to contenate two arrays.
    4. Create a method called ConcatPositive that will take two arrays
       and concatenate them together with only the positive numbers.
       No extra space in the array.
    */

        /*public static int Triangle(int n)
        {
            if (n == 0)
                return 0;

            return n + Triangle(n - 1);
        }*/
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
            string test = f.ChangeA("arial"); //-ri-l
            Console.WriteLine(test);
            // int[] re = f.ConcatArray([1, 3, 5], [2, 4, 6]);
            // Console.WriteLine(re);
        }
    }
}