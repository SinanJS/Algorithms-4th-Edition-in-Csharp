﻿namespace _1._4._7
{
    /*
     * 1.4.7
     * 
     * 以统计涉及输入数字的算数操作（和比较）的成本模型分析 ThreeSum。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * ThreeSum 的成本模型
             * 在研究解决 ThreeSum 时，我们记录的是计算求和以及比较的次数。
             * 
             * 最外层循环进行了 N 次比较
             * 次外层循环进行了 N^2 次比较
             * 最里层循环进行了 N^3 次比较
             * 内部 if 语句进行了 N^3 次比较
             * if 内部进行了 N(N-1) 次加法
             * 
             * 加起来，~2N^3
             * 
             */
        }
    }
}
