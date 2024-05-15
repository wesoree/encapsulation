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
                int mid = min + ((max - min) / 2);
                if (key == arr[mid])
                    return mid;
                else if (key < arr[mid])
                    max = mid - 1;
                else
                    min = mid + 1;
            }
            return -1;
        }

        public static string ToString(int[] nums)
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
                    Console.WriteLine(key + " found at index 0");
                    return;
                }
                else
                {
                    Console.WriteLine(key +" was not found");
                    return;
                }
            }
            Console.WriteLine("the unsorted array is:");
            Console.WriteLine(ToString(arr));
            Console.WriteLine("the sorted array is:");
            if (arr.Length <= 10)
                SelectionSort(arr);
            else
                Sort(arr);
            Console.WriteLine(ToString(arr));
            int a = BinarySearch(arr, key);
            if (a == -1)
                Console.WriteLine(key + " was not found");
            else
                Console.WriteLine(key + " found at index "  + a);
        }

        public static void Main(string[] args)
        {
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