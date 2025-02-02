﻿namespace _2._1._5
{
    /*
     * 2.1.5
     * 
     * 构造一个含有 N 个元素的数组，
     * 使插入排序（算法 2.2）运行过程中内循环（for）的两个判断结果总是假。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            // 一个已排序的数组即可。
            // 条件为：j > 0 && less(a[j], a[j - 1])
            // 第一个条件总是满足，
            // 只要每个 a[j] 都不小于它前一个元素，第二个条件就总是为假，
            // 故一个已排序的数组满足题意。
        }
    }
}
