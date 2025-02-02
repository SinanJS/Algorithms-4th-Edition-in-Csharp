﻿using System;

namespace _1._2._6
{
    /*
     * 1.2.6
     * 
     * 如果字符串 s 中的字符循环移动任意位置之后能够得到另一个字符串 t，
     * 那么 s 就被称为 t 的回环变位（circular rotation）。
     * 例如，ACTGACG 就是 TGACGAC 的一个回环变位，反之亦然。
     * 判定这个条件在基因组序列的研究中是很重要的。
     * 编写一个程序检查两个给定的字符串 s 和 t 是否互为回环变位。
     * 提示：答案只需要一行用到 indexOf()、length() 和字符串连接的代码。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "ACTGACG";
            string s2 = "TGACGAC";

            Console.WriteLine(Circular(s1, s2));
        }


        // 对于任意字符串 s，将其拆分成 s = s1 + s2（s2长度即为循环移动的位数）
        // 其回环变位则为 s' = s2 + s1
        // 显然 s' + s' = s2 + s1 + s2 + s1
        // 即 s' + s' = s2 + s + s1，其中必定包含 s
        // 例如 ABC 和 BCA， BCABCA 显然包含 ABC
        static bool Circular(string s1, string s2)
        {
            return s1.Length == s2.Length && (s2 + s2).Contains(s1);
        }
    }
}
