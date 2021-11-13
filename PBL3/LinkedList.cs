using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3
{
    public class LinkedNode<T>
    {
        public LinkedNode<T> next;
        public T item;
        public LinkedNode(T item)
        {
            this.item = item;
            next = null;
        }
    }
    public class LinkedList<T>
    {
        public LinkedNode<T> Head
        {
            get
            {
                return head;
            }
        }
        public int Length
        {
            get
            {
                return length;
            }
        }
        private int length;
        private LinkedNode<T> head;
        public void add(LinkedNode<T> node)
        {
            LinkedNode<T> cur = head;

            if (cur == null)
            {
                head = node;
                //   head.next = null;
            }
            else
            {
                while (cur.next != null)
                {
                    cur = cur.next;
                }
                cur.next = node;
            }
            length++;
        }
        public void DisplayAll()
        {
            LinkedNode<T> cur = Head;
            while (cur != null)
            {
                Console.WriteLine(cur.item.ToString());
                cur = cur.next;
            }
        }

    }
}
