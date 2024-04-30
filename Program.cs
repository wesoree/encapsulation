﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
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

            for (int i = 0; i < a.Length; i++)
            {
                newArr[cursor] = a[i];
                cursor++;
            }

            for (int i = 0; i < b.Length; i++)
            {
                newArr[cursor] = b[i];
                cursor++;
            }

            return newArr;
        }


        

        public int Array11(int[] nums, int index)
        {
            if (index == nums.Length)
                return 0;

            if (nums[index] == 11)
                return 1 + Array11(nums, index + 1);

            return Array11(nums, index + 1);
        }

        
    }

    public class IntegerLinkedList
    {
        public class Node
        {
            public int Value;
            public Node Next;

            public Node(int n)
            {
                this.Value = n;
            }

        }
        
        private Node _start;
        private Node _end;

        public IntegerLinkedList()
        {
            this._start = null;
            this._end = null;
        }
        
        public void Add(int n)
        {
            Node node = new Node(n);
            if (this._start == null) 
            {
                this._start = node;
                this._end = node;
            }
            else
            {
                this._end.Next = node;
            }
        }
        
        public void PrintAll()
        {
            Node pointer = this._start;
            
            while (pointer != null)
            {
                Console.Write(pointer.Value + ", ");
                pointer = pointer.Next;
            }
            Console.WriteLine();
        }
        
        public void Concat(IntegerLinkedList other)
        {
            this._end.Next = other._start;
            this._start = other._end;
        }

        public int Get(int index)
        {
            Node pointer = this._start;
            for (int i = 0; i < index; i++)
            {
                if (pointer == null)
                    throw new IndexOutOfRangeException();
                pointer = pointer.Next;
            }
            return pointer.Value;
        }

        /* public void Slice(int i)
        {
            IntegerLinkedList split = new IntegerLinkedList();
            split._end = this._end;
            for (int j = 0; j < i; j++)
            {
                
            }
        }*/
    }

    public class IntegerArrayList
    {
        private int[] _nums;
        private int _nextIndex = 0;

        public IntegerArrayList()
        {
            this._nums = new int[5];
        }

        public void Add(int n)
        {
            if (this._nextIndex == this._nums.Length)
            {
                int[] newArr = new int[this._nums.Length + 5];
                for (int i = 0; i < this._nextIndex; i+= 1)
                {
                    newArr[i] = this._nums[i];
                }
                this._nums = newArr;
            }
            this._nums[this._nextIndex] = n;
            this._nextIndex += 1;
        }

        public int[] PrintAll()
        {
            return this._nums;
        }
    }



    internal class Program
    {
        public static int CountX(string str)
        {
            str = str.ToLower();

            if (str.Length < 1)
                return 0;

            if (str[0] == 'x')
                return 1 + CountX(str.Substring(1));

            return 0 + CountX(str.Substring(1));
        }
        public static int Triangle(int n)
        {
            if (n == 0)
                return 0;

            return n + Triangle(n - 1);
        }
        public static int Fibonacci(int n)
        {
            if (n == 0)
                return 0;

            if (n == 1)
                return 1;


            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
        public static string ChangeA(string str)
        {
            if (str.Length < 1)
                return "";

            if (str[0] == 'a')
            {
                return "-" + ChangeA(str.Substring(1));
            }

            return str[0] + ChangeA(str.Substring(1));
        }
        public static void Main(string[] args)
        {
            Console.WriteLine(Fibonacci(0)); //0
            Console.WriteLine(Fibonacci(1)); //1
            Console.WriteLine(Fibonacci(2)); //1
            Console.WriteLine(Fibonacci(3)); //2
            Console.WriteLine(Fibonacci(6)); //8
            Console.WriteLine(ChangeA("arial")); //-ri-l
            //int[] g = f.ConcatArray([1, 2, 3], [4, 5, 6]);
            //Console.WriteLine(g);
            //int g = f.Array11([3, 11, 20, 11, 30], 0);
            //Console.WriteLine(g);
            IntegerLinkedList list = new IntegerLinkedList();
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.PrintAll();

            IntegerLinkedList list2 = new IntegerLinkedList();
            list2.Add(6);
            list2.Add(35);
            list2.Add(59);

            list.Concat(list2);
            list.PrintAll();

            // Console.WriteLine(list2.Get(0));
            // Console.WriteLine(list2.Get(2));

            // list.Split(3);
            Console.WriteLine(CountX("hi")); //0
            Console.WriteLine(CountX("xhix")); //2
            Console.WriteLine(CountX("xxhixx")); //4
            Console.WriteLine(CountX("XXHIXX"));
            Console.WriteLine(CountX(""));


            IntegerArrayList l = new IntegerArrayList();
            l.Add(1);
            l.Add(2);
            l.Add(3);
            l.Add(4);
            l.Add(5);
            l.Add(6);
            Console.WriteLine(l.PrintAll());
        }
    }
}