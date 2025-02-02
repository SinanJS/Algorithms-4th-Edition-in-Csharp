﻿using System.Collections.Generic;
using System.Diagnostics;
using Sort;

namespace _2._1._25
{
    /// <summary>
    /// 插入排序类。
    /// </summary>
    public class InsertionSort : BaseSort
    {
        /// <summary>
        /// 默认构造函数。
        /// </summary>
        public InsertionSort() { }

        /// <summary>
        /// 利用插入排序将数组按升序排序。
        /// </summary>
        /// <param name="a">需要排序的数组。</param>
        public override void Sort<T>(T[] a)
        {
            int n = a.Length;
            int exchanges = 0;

            for (int i = n - 1; i > 0 ; i--)
            {
                if (Less(a[i], a[i - 1]))
                {
                    Exch(a, i, i - 1);
                    exchanges++;
                }
            }
            if (exchanges == 0)
                return;

            for (int i = 2; i < n; i++)
            {
                int j = i;
                T v = a[i];
                while (Less(v, a[j - 1]))
                {
                    a[j] = a[j - 1];
                    j--;
                }
                a[j] = v;
                Debug.Assert(IsSorted(a, 0, i));
            }
            Debug.Assert(IsSorted(a));
        }

        /// <summary>
        /// 利用插入排序将数组排序。（使用指定比较器）
        /// </summary>
        /// <typeparam name="T">数组元素类型。</typeparam>
        /// <param name="a">需要排序的数组。</param>
        /// <param name="c">比较器。</param>
        public void Sort<T>(T[] a, IComparer<T> c)
        {
            int n = a.Length;
            int exchanges = 0;

            for (int i = n - 1; i > 0; i--)
            {
                if (Less(a[i], a[i - 1], c))
                {
                    Exch(a, i, i - 1);
                    exchanges++;
                }
            }
            if (exchanges == 0)
                return;

            for (int i = 2; i < n; i++)
            {
                int j = i;
                T v = a[i];
                while (Less(v, a[j - 1], c))
                {
                    a[j] = a[j - 1];
                    j--;
                }
                a[j] = v;
                Debug.Assert(IsSorted(a, 0, i, c));
            }
            Debug.Assert(IsSorted(a, c));
        }
    }
}
