using System;
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
                this._end = node;
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

        public string LinkString()
        {
            Node pointer = this._start;

            string str = "";

            while (pointer != null)
            {
                str += pointer.Value.ToString() + " ";    
                pointer = pointer.Next;
            }
            return str;
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

        public void Copy()
        {
            
        }

        /* public void Slice(int begin, int end)
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

        public void PrintAll()
        {
            Console.Write("[");

            for (int i = 0; i < this._nums.Length; i += 1) 
            {
                Console.Write(this._nums[i] + ", ");
            }
            Console.WriteLine("]");
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
        public int CountNegative(int[] nums)
        {
            int count = 0;
            foreach (int n in nums)
            {
                if (n < 0)
                    count += 1;
            }
            return count;
        }

        public static int LinearSearch(int[] nums, int target)
        {
            for (int i = 0;i < nums.Length;i += 1)
            {
                int value = nums[i];
                if (value == target)
                    return i;
            }
            return -1;
        }
        
        public static int CountMult7(int n)
        {
            if (n == 0)
                return 1;

            if (n % 7 == 0)
                return 1 + CountMult7(n - 1);

            return CountMult7(n - 1);
        }

        public static void SelectionSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int minElementIndex = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[minElementIndex] > arr[j])
                        minElementIndex = j;
                }
                if (minElementIndex != i)
                    Swap(arr, i, minElementIndex);
            }
        }

        static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        public static void Sort(int[] arr)
        {
            if (arr.Length < 2)
                return; // no need to sort
            int mid = arr.Length / 2;
            int[] left = new int[mid];
            int[] right = new int[arr.Length - mid];
            for (int i = 0; i < mid; i++)
                left[i] = arr[i];
            for (int i = 0; i < arr.Length - mid; i++)
                right[i] = arr[mid + i];
            Sort(left);
            Sort(right);
            Merge(left, right, arr);
        }

        private static void Merge(int[] a, int[] b, int[] all)
        {
            int i = 0, j = 0, k = 0;
            while ((i < a.Length) && (j < b.Length))
            {
                if (a[i] < b[j])
                {
                    all[k] = a[i];
                    i++;
                }
                else
                {
                    all[k] = b[j];
                    j++;
                }
                k++;
            }
            while (i < a.Length)
                all[k++] = a[i++];
            while (j < b.Length)
                all[k++] = b[j++];
        }


        public static int BinarySearch(int[] arr, int key)
        {
            int min = 0;
            int max = arr.Length - 1;
            while (min <= max)
            {
                int mid = (min + max) >> 1;
                if (key == arr[mid])
                    return mid;
                else if (key < arr[mid])
                    max = mid - 1;
                else
                    min = mid + 1;
            }
            return -1;
        }

        public static string AToString(int[] nums)
        {
            IntegerLinkedList arr = new IntegerLinkedList();
            for (int i = 0; i < nums.Length; i++)
            {
                arr.Add(nums[i]);
            }
            return arr.LinkString();
        }

        public static void Search(int[] arr, int key)
        {
            if (arr.Length == 1)
            {
                Console.WriteLine("the array is " + arr[0]);
                if (arr[0] == key)
                {
                    Console.WriteLine(key + " located at index 0");
                    return;
                }
                else
                {
                    Console.WriteLine(key +" was not found");
                    return;
                }
            }
            Console.WriteLine("the unsorted array is:");
            Console.WriteLine(AToString(arr));
            Console.WriteLine("the sorted array is:");
            if (arr.Length <= 10)
                SelectionSort(arr);
            else
                Sort(arr);
            Console.WriteLine(AToString(arr));
            int a = BinarySearch(arr, key);
            if (a == -1)
                Console.WriteLine(key + " was not found");
            else
                Console.WriteLine(key + " located at index "  + a);
        }

        public static void Main(string[] args)
        {
            /*Console.WriteLine(Fibonacci(0)); //0
            Console.WriteLine(Fibonacci(1)); //1
            Console.WriteLine(Fibonacci(2)); //1
            Console.WriteLine(Fibonacci(3)); //2
            Console.WriteLine(Fibonacci(6)); //8
            Console.WriteLine(ChangeA("arial")); //-ri-l
            int[] a = {1, 2, 3};
            int[] b = {4, 5, 6};
            int[] c = ConcatArray(a, b);
            string str = c.ToString();
            Console.WriteLine(str);
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
            l.Add(7);
            l.Add(8);
            l.Add(9);
            l.Add(10);
            l.PrintAll();
            */

            int[] a = { 5, 3, 7, 9, 3, 5, 2, 5, 3, 6, 12, 6, 3, 45, 100 };
            int[] b = { 3, 5, 2, 4, 3 };
            int[] c = { 5, 2, 6, 2, 6, 1, 6, 2, 100, 30, -1, 4, -30, 20, 25, 104, 300, 2 };
            int[] d = { 1, 3, 3, 2 };
            int[] e = { 1 };
            int[] f = { 20 };
            Search(a, 5);
            Search(b, 3);
            Search(a, 1);
            Search(c, 100);
            Search(d, 4);
            Search(e, 1);
            Search(f, 1);



        }
    }
}