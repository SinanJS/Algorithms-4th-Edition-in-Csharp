﻿using System;
using Sort;

namespace _2._1._36
{
    /*
     * 2.1.36
     * 
     * 不均匀的数据。
     * 编写一个测试用例，
     * 生成不均匀的测试数据，包括：
     * 一半数据是 0，一半数据是 1
     * 一半数据是 0，1/4 是 1，1/4 是 2，以此类推
     * 一半数据是 0，一半是随机 int 值。
     * 评估并验证这些输入数据对本节讨论的算法的性能的影响。
     * 
     */
    class Program
    {
        // 选择排序的耗时与输入值的内容无关，不受影响。
        // 对于插入排序，以上几种情况都是重复值较多的情况，插入排序的速度会加快。
        // 希尔排序本质上也是插入排序，因此也会更快一些。
        static void Main(string[] args)
        {
            int n = 10000;
            InsertionSort insertionSort = new InsertionSort();
            SelectionSort selectionSort = new SelectionSort();
            ShellSort shellSort = new ShellSort();

            int[] arrayInsertion = new int[n];
            int[] arraySelection = new int[n];
            int[] arrayShell = new int[n];

            // 对照，完全随机
            arrayInsertion = HalfZeroHalfOne(n);
            arrayInsertion.CopyTo(arraySelection, 0);
            arrayInsertion.CopyTo(arrayShell, 0);

            Console.WriteLine("totally random");
            Console.WriteLine("Insertion Sort:" + SortCompare.TimeRandomInput(insertionSort, n, 1));
            Console.WriteLine("Selection Sort:" + SortCompare.TimeRandomInput(selectionSort, n, 1));
            Console.WriteLine("Shell Sort:" + SortCompare.TimeRandomInput(shellSort, n, 1));
            Console.WriteLine();

            // 一半是 0 一半是 1
            arrayInsertion = HalfZeroHalfOne(n);
            arrayInsertion.CopyTo(arraySelection, 0);
            arrayInsertion.CopyTo(arrayShell, 0);

            Console.WriteLine("half 0 and half 1");
            Console.WriteLine("Insertion Sort:" + SortCompare.Time(insertionSort, arrayInsertion));
            Console.WriteLine("Selection Sort:" + SortCompare.Time(selectionSort, arraySelection));
            Console.WriteLine("Shell Sort:" + SortCompare.Time(shellSort, arrayShell));
            Console.WriteLine();

            // 一半是 0， 1/4 是 1， 1/8 是 2……
            arrayInsertion = HalfAndHalf(n);
            arrayInsertion.CopyTo(arraySelection, 0);
            arrayShell.CopyTo(arrayShell, 0);

            Console.WriteLine("half and half and half ...");
            Console.WriteLine("Insertion Sort:" + SortCompare.Time(insertionSort, arrayInsertion));
            Console.WriteLine("Selection Sort:" + SortCompare.Time(selectionSort, arraySelection));
            Console.WriteLine("Shell Sort:" + SortCompare.Time(shellSort, arrayShell));
            Console.WriteLine();

            // 一半是 0，一半是随机 int 值
            arrayInsertion = HalfZeroHalfRandom(n);
            arrayInsertion.CopyTo(arraySelection, 0);
            arrayShell.CopyTo(arrayShell, 0);

            Console.WriteLine("half 0 half random");
            Console.WriteLine("Insertion Sort:" + SortCompare.Time(insertionSort, arrayInsertion));
            Console.WriteLine("Selection Sort:" + SortCompare.Time(selectionSort, arraySelection));
            Console.WriteLine("Shell Sort:" + SortCompare.Time(shellSort, arrayShell));
        }

        /// <summary>
        /// 获取一半是 0 一半是 1 的随机 <see cref="int"/> 数组。
        /// </summary>
        /// <param name="n">数组大小。</param>
        /// <returns>一半是 0 一半是 1 的 <see cref="int"/>数组。</returns>
        static int[] HalfZeroHalfOne(int n)
        {
            int[] result = new int[n];
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                if (random.NextDouble() >= 0.5)
                {
                    result[i] = 0;
                }
                else
                {
                    result[i] = 1;
                }
            }
            return result;
        }

        /// <summary>
        /// 生成 1/2 为 0， 1/4 为 1， 1/8 为 2 …… 的 <see cref="int"/> 数组。
        /// </summary>
        /// <param name="n">数组长度。</param>
        /// <returns>1/2 为 0， 1/4 为 1， 1/8 为 2 …… 的 <see cref="int"/> 数组。</returns>
        static int[] HalfAndHalf(int n)
        {
            int[] array = new int[n];
            HalfIt(0, 0, n / 2, array);
            Shuffle(array);
            return array;
        }

        /// <summary>
        /// 递归生成 1/2 为 0， 1/4 为 1， 1/8 为 2 …… 的 <see cref="int"/> 数组。
        /// </summary>
        /// <param name="start">填充起点。</param>
        /// <param name="number">起始编号。</param>
        /// <param name="length">填充长度</param>
        /// <param name="array">用于填充的数组。</param>
        /// <returns>一个 <see cref="int"/> 数组。</returns>
        static int[] HalfIt(int start, int number, int length, int[] array)
        {
            if (length == 0)
                return array;

            for (int i = 0; i < length; i++)
            {
                array[start + i] = number;
            }

            return HalfIt(start + length, number + 1, length / 2, array);
        }

        /// <summary>
        /// 生成一半是 0 一半是随机整数的 <see cref="int"/> 数组。
        /// </summary>
        /// <param name="n">数组大小。</param>
        /// <returns>生成一半是 0 一半是随机整数的 <see cref="int"/> 数组。</returns>
        static int[] HalfZeroHalfRandom(int n)
        {
            int[] array = new int[n];
            Random random = new Random();
            for (int i = 0; i < n / 2; i++)
            {
                array[i] = 0;
            }

            for (int i = n / 2; i < n; i++)
            {
                array[i] = random.Next();
            }

            Shuffle(array);

            return array;
        }

        /// <summary>
        /// 打乱数组。
        /// </summary>
        /// <param name="a">需要打乱的数组。</param>
        static void Shuffle(int[] a)
        {
            int N = a.Length;
            Random random = new Random();
            for (int i = 0; i < N; i++)
            {
                int r = i + random.Next(N - i);// 等于StdRandom.uniform(N-i)
                int temp = a[i];
                a[i] = a[r];
                a[r] = temp;
            }
        }
    }
}
