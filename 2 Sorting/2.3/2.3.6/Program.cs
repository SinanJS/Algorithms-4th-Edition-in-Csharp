﻿using System;
using Quick;

namespace _2._3._6
{
    /*
     * 2.3.6
     * 
     * 编写一段代码来计算 C_N 的准确值，
     * 在 N=100、1000 和 10 000 的情况下比较准确值和估计值 2NlnN 的差距。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("N\t准确值\t估计值\t比值");
            QuickSortAnalyze sort = new QuickSortAnalyze();
            int N = 100;
            int trialTime = 500;
            for (int i = 0; i < 3; i++)
            {
                int sumOfCompare = 0;
                int[] a = new int[N];
                for (int j = 0; j < trialTime; j++)
                {
                    for (int k = 0; k < N; k++)
                    {
                        a[k] = k;
                    }
                    SortCompare.Shuffle(a);
                    sort.Sort(a);
                    sumOfCompare += sort.CompareCount;
                }
                int averageCompare = sumOfCompare / trialTime;
                double estimatedCompare = 2 * N * Math.Log(N);
                Console.WriteLine(N + "\t" + averageCompare + "\t" + (int)estimatedCompare + "\t" + averageCompare / estimatedCompare);
                N *= 10;
            }
        }
    }
}
