﻿namespace _2._3._20
{
    /// <summary>
    /// 链表结点类。
    /// </summary>
    /// <typeparam name="T">结点存放的元素类型。</typeparam>
    public class Node<T>
    {
        public T item;
        public Node<T> next;

        public Node() { }

        public Node(Node<T> node)
        {
            this.item = node.item;
            this.next = node.next;
        }
    }
}
