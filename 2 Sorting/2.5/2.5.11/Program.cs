﻿using System;
using SortApplication;

namespace _2._5._11
{
    /*
     * 2.5.11
     * 
     * 描述排序结果的一种方法是创建一个保存 0 到 a.length - 1 的排列 p[]，
     * 使得 p[i] 的值为 a[i] 元素的最终位置。
     * 用这种方法描述插入排序、选择排序、希尔排序、归并排序、快速排序和堆排序
     * 对一个含有 7 个相同元素的数组的排序结果。
     * 
     */
    class Program
    {
        /// <summary>
        /// 用来排序的元素，记录有自己的初始下标。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        class Item<T> : IComparable<Item<T>> where T : IComparable<T>
        {
            public int Index;
            public T Key;

            public Item(int index, T key)
            {
                this.Index = index;
                this.Key = key;
            }

            public int CompareTo(Item<T> other)
            {
                return this.Key.CompareTo(other.Key);
            }
        }

        static void Main(string[] args)
        {
            // 插入排序
            Console.WriteLine("Insertion Sort");
            Test(new InsertionSort(), 7, 1);
            // 选择排序
            Console.WriteLine("Selection Sort");
            Test(new SelectionSort(), 7, 1);
            // 希尔排序
            Console.WriteLine("Shell Sort");
            Test(new ShellSort(), 7, 1);
            // 归并排序
            Console.WriteLine("Merge Sort");
            Test(new MergeSort(), 7, 1);
            // 快速排序
            Console.WriteLine("Quick Sort");
            QuickSortAnalyze quick = new QuickSortAnalyze
            {
                NeedShuffle = false,
                NeedPath = false
            };
            Test(quick, 7, 1);
            // 堆排序
            Console.WriteLine("Heap Sort");
            Item<int>[] array = new Item<int>[7];
            for (int i = 0; i < 7; i++)
                array[i] = new Item<int>(i, 1);
            Heap.Sort(array);
            for (int i = 0; i < 7; i++)
                Console.Write(array[i].Index + " ");
            Console.WriteLine();
        }

        static void Test(BaseSort sort, int n, int constant)
        {
            Item<int>[] array = new Item<int>[n];
            for (int i = 0; i < n; i++)
                array[i] = new Item<int>(i, constant);
            sort.Sort(array);
            for (int i = 0; i < n; i++)
                Console.Write(array[i].Index + " ");
            Console.WriteLine();
        }
    }
}
