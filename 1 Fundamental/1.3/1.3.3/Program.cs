﻿namespace _1._3._3
{
    /*
     * 1.3.3
     * 
     * 假设某个用例程序会进行一系列入栈和出栈操作的混合栈操作。
     * 入栈操作会将整数 0 到 9 按顺序压入栈；出栈操作会打印出返回值。
     * 下面那种序列是不可能产生的？
     * 
     * 4 3 2 1 0 9 8 7 6 5
     * 4 6 8 7 5 3 2 9 0 1
     * 2 5 6 7 4 8 9 3 1 0
     * 4 3 2 1 0 5 6 7 8 9
     * 1 2 3 4 5 6 9 8 7 0
     * 0 4 6 5 3 8 1 7 2 9
     * 1 4 7 9 8 6 5 3 0 2
     * 2 1 4 3 6 5 8 7 9 0
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            // 第 2、6、7 个不可能产生。
            // 第 2 个
            //     输出数   栈内数
            //      4        0~3
            //      6        0~3 + 5
            //      8        0~3 + 5 + 7
            //      7        0~3 + 5
            //      5        0~3
            //      3        0~2
            //      2        0~1
            //      9        0~1
            //      0        Error
            // 第 6 个
            //     输出数   栈内数
            //      0        null
            //      4        1~3
            //      6        1~3 + 5
            //      5        1~3
            //      3        1~2
            //      8        1~2 + 7
            //      1        Error
            // 第 7 个
            //     输出数   栈内数
            //      1        0
            //      4        0 + 2~3
            //      7        0 + 2~3 + 5~6
            //      9        0 + 2~3 + 5~6 + 8
            //      8        0 + 2~3 + 5~6
            //      6        0 + 2~3 + 5
            //      5        0 + 2~3
            //      3        0 + 2
            //      0        Error
        }
    }
}
