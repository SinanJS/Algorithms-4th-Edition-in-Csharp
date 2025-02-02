﻿using System;

namespace PriorityQueue
{
    /// <summary>
    /// 元素保持输入顺序的优先队列。（基于数组）
    /// </summary>
    /// <typeparam name="Key">优先队列中的元素类型。</typeparam>
    public class OrderedArrayMaxPQ<Key> : IMaxPQ<Key> where Key : IComparable<Key>
    {
        /// <summary>
        /// 保存元素的数组。
        /// </summary>
        private readonly Key[] pq;

        /// <summary>
        /// 队列中的元素数量。
        /// </summary>
        private int n = 0;

        /// <summary>
        /// 默认构造函数，建立一条优先队列。
        /// </summary>
        /// <param name="capacity">优先队列的初始容量。</param>
        public OrderedArrayMaxPQ(int capacity)
        {
            this.pq = new Key[capacity];
            this.n = 0;
        }

        /// <summary>
        /// 向优先队列中插入一个元素。
        /// </summary>
        /// <param name="v">需要插入的元素。</param>
        public void Insert(Key v)
        {
            int i = this.n - 1;
            while (i >= 0 && Less(v, this.pq[i]))
            {
                this.pq[i + 1] = this.pq[i];
                i--;
            }
            this.pq[i + 1] = v;
            this.n++;
        }

        /// <summary>
        /// 返回并删除优先队列中的最大值。
        /// </summary>
        /// <returns></returns>
        public Key DelMax() => this.pq[--this.n];
        
        /// <summary>
        /// 检查优先队列是否为空。
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty() => this.n == 0;

        /// <summary>
        /// 检查优先队列中含有的元素数量。
        /// </summary>
        /// <returns></returns>
        public int Size() => this.n;

        /// <summary>
        /// 获得（但不删除）优先队列中的最大元素。
        /// </summary>
        /// <returns></returns>
        public Key Max() => this.pq[this.n - 1];

        /// <summary>
        /// 比较第一个元素是否小于第二个元素。
        /// </summary>
        /// <param name="a">第一个元素。</param>
        /// <param name="b">第二个元素。</param>
        /// <returns></returns>
        private bool Less(Key a, Key b) => a.CompareTo(b) < 0;
    }
}
