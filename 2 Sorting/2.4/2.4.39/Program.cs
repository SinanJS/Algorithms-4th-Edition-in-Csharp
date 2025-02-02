﻿using System;
using System.Diagnostics;

namespace _2._4._39
{
    /*
     * 2.4.39
     * 
     * 构造函数的代价。
     * 对于 N=10^3、10^6 和 10^9，
     * 根据经验判断堆排序时构造堆所占总耗时的比例。
     * 
     */
    class Program
    {
        static Random random = new Random();

        static void Main(string[] args)
        {
            Console.WriteLine("n\tBuild\tSort\tRatio");

            int n = 1000;     // 当数据量到达 10^9 时会需要 2G 左右的内存
            int multiTen = 7;
            for (int i = 0; i < multiTen; i++)
            {
                short[] data = GetRandomArray(n);
                Stopwatch fullSort = new Stopwatch();
                Stopwatch buildHeap = new Stopwatch();

                fullSort.Restart();

                buildHeap.Restart();
                BuildHeap(data);
                buildHeap.Stop();

                HeapSort(data);
                fullSort.Stop();

                long buildTime = buildHeap.ElapsedMilliseconds;
                long fullTime = fullSort.ElapsedMilliseconds;
                Console.WriteLine(n + "\t" + buildTime + "\t" + fullTime + "\t" + (double)buildTime / fullTime);
                n *= 10;
            }
        }

        static short[] GetRandomArray(int n)
        {
            short[] data = new short[n];
            for (int i = 0; i < n; i++)
            {
                data[i] = (short)random.Next();
            }
            return data;
        }

        /// <summary>
        /// 将数组构造成堆。
        /// </summary>
        /// <param name="data">数组。</param>
        static void BuildHeap(short[] data)
        {
            int n = data.Length;
            for (int k = n / 2; k >= 1; k--)
            {
                Sink(data, k, n);
            }
        }

        /// <summary>
        /// 利用已经生成的堆排序。
        /// </summary>
        /// <param name="heap">最大堆。</param>
        static void HeapSort(short[] heap)
        {
            int n = heap.Length;
            while (n > 1)
            {
                Exch(heap, 1, n--);
                Sink(heap, 1, n);
            }
        }

        /// <summary>
        /// 令堆中的元素下沉。
        /// </summary>
        /// <param name="pq">需要执行操作的堆。</param>
        /// <param name="k">需要执行下沉的结点下标。</param>
        /// <param name="n">堆中元素的数目。</param>
        static void Sink(short[] pq, int k, int n)
        {
            while (2 * k <= n)
            {
                int j = 2 * k;
                if (j < n && Less(pq, j, j + 1))
                    j++;
                if (!Less(pq, k, j))
                    break;
                Exch(pq, k, j);
                k = j;
            }
        }

        /// <summary>
        /// 比较堆中下标为 <paramref name="a"/> 的元素是否小于下标为 <paramref name="b"/> 的元素。
        /// </summary>
        /// <param name="pq">元素所在的数组。</param>
        /// <param name="a">需要比较是否较小的结点序号。</param>
        /// <param name="b">需要比较是否较大的结点序号。</param>
        /// <returns></returns>
        static bool Less(short[] pq, int a, int b)
            => pq[a - 1].CompareTo(pq[b - 1]) < 0;

        /// <summary>
        /// 交换堆中的两个元素。
        /// </summary>
        /// <param name="pq">要交换的元素所在堆。</param>
        /// <param name="a">要交换的结点序号。</param>
        /// <param name="b">要交换的结点序号。</param>
        static void Exch(short[] pq, int a, int b)
        {
            short temp = pq[a - 1];
            pq[a - 1] = pq[b - 1];
            pq[b - 1] = temp;
        }
    }
}
