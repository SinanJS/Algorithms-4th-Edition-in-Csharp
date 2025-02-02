﻿using System;
using System.Diagnostics;

namespace Sort
{
    public class ShellSort : BaseSort
    {
        /// <summary>
        /// 默认构造函数。
        /// </summary>
        public ShellSort() { }

        /// <summary>
        /// 利用希尔排序将数组按升序排序。
        /// </summary>
        /// <param name="a">需要排序的数组。</param>
        public override void Sort<T>(T[] a)
        {
            int n = a.Length;

            int h = 1;
            while (h < n / 3)
            {
                h = 3 * h + 1;
            }

            while (h >= 1)
            {
                for (int i = h; i < n; i++)
                {
                    for (int j = i; j >= h && Less(a[j], a[j - h]); j -= h)
                    {
                        Exch(a, j, j - h);
                    }
                }
                Debug.Assert(IsHSorted(a, h));
                h /= 3;
            }
            Debug.Assert(IsSorted(a));
        }

        /// <summary>
        /// 检查一次希尔排序后的子数组是否有序。
        /// </summary>
        /// <param name="a">排序后的数组。</param>
        /// <param name="h">子数组间隔。</param>
        /// <returns>是否有序。</returns>
        private bool IsHSorted<T>(T[] a, int h) where T : IComparable<T>
        {
            for (int i = h; i < a.Length; i++)
            {
                if (Less(a[i], a[i - h]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
