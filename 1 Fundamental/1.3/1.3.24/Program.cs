﻿using System;
using Generics;

namespace _1._3._24
{
    /*
     * 1.3.24
     * 
     * 编写一个方法 removeAfter()，接受一个链表结点作为参数并删除该结点的后续结点。
     * （如果参数结点的后续结点为空则什么也不做）
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            Node<string> first = new Node<string>();
            Node<string> second = new Node<string>();
            Node<string> third = new Node<string>();
            Node<string> fourth = new Node<string>();

            first.item = "first";
            second.item = "second";
            third.item = "third";
            fourth.item = "fourth";

            first.next = second;
            second.next = third;
            third.next = fourth;
            fourth.next = null;

            Node<string> current = first;
            while (current != null)
            {
                Console.Write(current.item + " ");
                current = current.next;
            }

            RemoveAfter(second);
            Console.WriteLine();

            current = first;
            while (current != null)
            {
                Console.Write(current.item + " ");
                current = current.next;
            }
        }

        static void RemoveAfter<Item>(Node<Item> i)
        {
            i.next = null;
        }
    }
}
