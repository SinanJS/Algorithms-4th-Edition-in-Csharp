﻿using System;
using Generics;

namespace _1._3._45
{
    /*
     * 1.3.45
     * 
     * 栈的可生成性。
     * 假设我们的栈测试用例会进行一系列的入栈和出栈操作，
     * 序列中的整数 0, 1, ... , N - 1 （按此先后顺序排列）表示入栈操作，N个减号表示出栈操作。
     * 设计一个算法，判定给定的混合序列是否会使数组向下溢出
     * （你使用的空间量与 N 无关，即不能用某种数据结构存储所有整数）。
     * 设计一个线性时间算法判定我们的测试用例能否产生某个给定的排列
     * （这取决于出栈操作指令的出现位置）。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            // 给定输入序列，判断是否会出现下溢出。
            string input = "- 0 1 2 3 4 5 6 7 8 9 - - - - - - - - -";
            Console.WriteLine(IsUnderflow(input.Split(' ')));//True
            input = "0 - 1 - 2 - 3 - 4 - 5 - 6 - 7 - 8 - 9 -";
            Console.WriteLine(IsUnderflow(input.Split(' ')));//False

            // 给定输出序列，判定是否可能。
            int[] output = { 4, 3, 2, 1, 0, 9, 8, 7, 6, 5 };
            Console.WriteLine(IsOutputPossible(output));//True
            output = new int[]{ 4, 6, 8, 7, 5, 3, 2, 9, 0, 1};
            Console.WriteLine(IsOutputPossible(output));//False
        }

        /// <summary>
        /// 判断是否会出现下溢出。
        /// </summary>
        /// <param name="input">输入序列。</param>
        /// <returns></returns>
        static bool IsUnderflow(string[] input)
        {
            // 记录栈中元素数量，如果元素数量小于 0 则会出现下溢出。
            int count = 0;

            foreach (string s in input)
            {
                if (count < 0)
                {
                    return true;
                }
                if (s.Equals("-"))
                {
                    count--;
                }
                else
                {
                    count++;
                }
            }

            return false;
        }

        /// <summary>
        /// 判断输出序列是否正确。
        /// </summary>
        /// <param name="output">输出序列。</param>
        /// <returns></returns>
        static bool IsOutputPossible(int[] output)
        {
            int input = 0;
            int N = output.Length;
            Stack<int> stack = new Stack<int>();

            foreach (int i in output)
            {
                // 如果栈为空，则从输入序列中压入一个数。
                if (stack.IsEmpty())
                {
                    stack.Push(input);
                    input++;
                }

                // 如果输入序列中的所有数都已经入栈过了，跳出循环。
                if (input == N && stack.Peek() != i)
                {
                    break;
                }

                // 如果输出序列的下一个数不等于栈顶的数，那么就从输入序列中压入一个数。
                while (stack.Peek() != i && input < N)
                {
                    stack.Push(input);
                    input++;
                }

                // 如果栈顶的数等于输出的数，弹出它。
                if (stack.Peek() == i)
                {
                    stack.Pop();
                }
            }

            return stack.IsEmpty();
        }
    }
}
