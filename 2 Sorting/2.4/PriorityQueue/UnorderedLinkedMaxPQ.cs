﻿using System;

namespace PriorityQueue
{
    /// <summary>
    /// 不保持元素输入顺序的优先队列。（基于链表）
    /// </summary>
    /// <typeparam name="Key">优先队列中的元素类型。</typeparam>
    public class UnorderedLinkedMaxPQ<Key> : IMaxPQ<Key> where Key : IComparable<Key>
    {
        /// <summary>
        /// 保存元素的链表。
        /// </summary>
        private readonly LinkedList<Key> pq;

        /// <summary>
        /// 默认构造函数，建立一条优先队列。
        /// </summary>
        public UnorderedLinkedMaxPQ()
        {
            this.pq = new LinkedList<Key>();
        }

        /// <summary>
        /// 获得（但不删除）优先队列中的最大元素。
        /// </summary>
        /// <returns></returns>
        public Key Max()
        {
            int max = 0;
            for (int i = 1; i < this.pq.Size(); i++)
                if (Less(this.pq.Find(max), this.pq.Find(i)))
                    max = i;
            return this.pq.Find(max);
        }

        /// <summary>
        /// 返回并删除优先队列中的最大值。
        /// </summary>
        /// <returns></returns>
        public Key DelMax()
        {
            int max = 0;
            for (int i = 1; i < this.pq.Size(); i++)
                if (Less(this.pq.Find(max), this.pq.Find(i)))
                    max = i;

            return this.pq.Delete(max);
        }

        /// <summary>
        /// 向优先队列中插入一个元素。
        /// </summary>
        /// <param name="v">需要插入的元素。</param>
        public void Insert(Key v) => this.pq.Insert(v);

        /// <summary>
        /// 检查优先队列是否为空。
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty() => this.pq.IsEmpty();

        /// <summary>
        /// 检查优先队列中含有的元素数量。
        /// </summary>
        /// <returns></returns>
        public int Size() => this.pq.Size();

        /// <summary>
        /// 比较第一个元素是否小于第二个元素。
        /// </summary>
        /// <param name="a">第一个元素。</param>
        /// <param name="b">第二个元素。</param>
        /// <returns></returns>
        private bool Less(Key a, Key b) => a.CompareTo(b) < 0;
    }
}
