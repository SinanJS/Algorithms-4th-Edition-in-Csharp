﻿using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace _1._1._34
{
    /*
     * 1.1.34

     * 过滤。
     * 以下那些任务需要（在数组中，比如）保存标准输入中的所有值？
     * 那些可以被实现为一个过滤器且仅使用固定数量的变量和固定大小的数组（和 N 无关）？
     * 每个问题中，输入都是来自于标准输入且含有 N 个 0 到 1 的实数。

     * 打印出最大和最小的数
     * 打印出所有数的中位数————需要
     * 打印出第 k 小的数， k 小于 100
     * 打印出所有数的平方和
     * 打印出 N 个数的平均值
     * 打印出大于平均值的数的百分比————需要
     * 将 N 个数按照升序打印————需要
     * 将 N 个数按照随机顺序打印————需要
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            string[] AllNumbers = File.ReadAllLines("largeW.txt");
            int N = AllNumbers.Length;
            int[] input = new int[N];

            for (int i = 0; i < N; i++)
            {
                input[i] = int.Parse(AllNumbers[i]);
            }

            MinAndMax(input);
            Console.WriteLine();

            MidNumber(input);
            Console.WriteLine();

            NumberK(4, input);
            Console.WriteLine();

            SquareSum(input);
            Console.WriteLine();

            AboveAverage(input);
            Console.WriteLine();

            Ascending(input);
            Console.WriteLine();

            Shuffle(input);
            Console.WriteLine();
        }

        /// <summary>
        /// 获取最大值和最小值。
        /// </summary>
        /// <param name="input">输入流。</param>
        static void MinAndMax(int[] input)
        {
            // 只用到了两个变量
            int min = input[0];
            int max = input[0];

            // 只对输入值正向遍历一遍，不需要保存
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] > max)
                {
                    max = input[i];
                }

                if (input[i] < min)
                {
                    min = input[i];
                }
            }

            Console.WriteLine("Min and Max:");
            Console.WriteLine($"Min: {min}\nMax: {max}");
        }

        /// <summary>
        /// 获取中位数。
        /// </summary>
        /// <param name="input">输入流。</param>
        /// <returns></returns>
        static int MidNumber(int[] input)
        {
            // 需要对输入值进行去重 & 排序，故需要保存
            List<int> DistinctNumbers = new List<int>(input.Distinct());
            DistinctNumbers.Sort();
            Console.WriteLine("MidNumber:");
            Console.WriteLine(DistinctNumbers[DistinctNumbers.Count / 2]);

            return DistinctNumbers[DistinctNumbers.Count / 2];
        }

        /// <summary>
        /// 获取第 k 小的数。
        /// </summary>
        /// <param name="k">需要获取的排名。</param>
        /// <param name="input">输入流。</param>
        /// <returns></returns>
        static int NumberK(int k, int[] input)
        {
            int[] temp = new int[101];

            // 只正向遍历一遍，不需要保存
            for (int i = 0; i < input.Length; i++)
            {
                if (i < 100)
                {
                    temp[i] = input[i];
                }
                else
                {
                    temp[100] = input[i];
                    Array.Sort(temp);
                }
            }

            Console.WriteLine("NumberK");
            Console.WriteLine($"No.k: {temp[k - 1]}");

            return temp[k - 1];
        }

        /// <summary>
        /// 计算输入流中所有数的平方和。
        /// </summary>
        /// <param name="input">输入流。</param>
        /// <returns>所有数的平方和。</returns>
        static long SquareSum(int[] input)
        {
            long sum = 0;
            // 只正向遍历一遍，不需要保存
            for (int i = 0; i < input.Length; i++)
            {
                sum += input[i] * input[i];
            }

            Console.WriteLine("Sum Of Square:");
            Console.WriteLine(sum);

            return sum;
        }

        /// <summary>
        /// 计算所有输入数据的平均值。
        /// </summary>
        /// <param name="input">输入流。</param>
        /// <returns>所有输入数据的平均值。</returns>
        static double Average(int[] input)
        {
            long sum = 0;

            // 只遍历一遍，且不保存整个数组
            for (int i = 0; i < input.Length; i++)
            {
                sum += input[i];
            }

            double ave = sum / (double)input.Length;

            Console.WriteLine("Average:");
            Console.WriteLine(ave);

            return ave;
        }

        /// <summary>
        /// 计算大于平均值的元素数量。
        /// </summary>
        /// <param name="input">输入流。</param>
        /// <returns>大于平均值的元素数量。</returns>
        static double AboveAverage(int[] input)
        {
            double ave = Average(input);
            Console.WriteLine();
            double count = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] > ave)
                {
                    count++;
                }
            }

            Console.WriteLine("AboveAverage:");
            Console.WriteLine($"{(count / input.Length) * 100}%");

            return count;
        }

        /// <summary>
        /// 升序打印数组。
        /// </summary>
        /// <param name="input">输入流。</param>
        static void Ascending(int[] input)
        {
            Array.Sort(input);

            Console.WriteLine("Ascending:");
            for (int i = 0; i < input.Length; i++)
            {
                Console.Write($" {input[i]}");
            }
            Console.Write("\n");
        }

        /// <summary>
        /// 随机打印数组。
        /// </summary>
        /// <param name="input">输入流。</param>
        static void Shuffle(int[] input)
        {
            Random random = new Random();
            List<int> All = new List<int>(input);
            int N = input.Length;
            int temp = 0;

            Console.WriteLine("Shuffle:");
            for (int i = 0; i < N; i++)
            {
                temp = random.Next(0, All.Count - 1);
                Console.Write($" {All[temp]}");
                All.RemoveAt(temp);
            }
        }
    }
}