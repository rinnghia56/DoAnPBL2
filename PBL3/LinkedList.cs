using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3
{
    // mlem mlem
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
    public class LinkedList<T> : IEnumerable<T>
    {
        public LinkedNode<T> Head
        {
            get
            {
                return head;
            }
            set
            {
                head = value;
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
        public void add(T item)
        {
            LinkedNode<T> node = new LinkedNode<T>(item);
            LinkedNode<T> cur = head;
            if (cur == null)
            {
                head = node;
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
            int i = 0;
            while (cur != null)
            {
                Console.WriteLine( i++  + " " + cur.item.ToString());
                cur = cur.next;
            }
        }
        public LinkedNode<T> paritionLast(LinkedNode<T> start, LinkedNode<T> end, Func<T, T, bool> checkSort)
        {
            if (start == end || start == null || end == null) return start;

            LinkedNode<T> cur = start;

            LinkedNode<T> pivot_pre = start;
            
            T pivot = end.item;
            T temp;
         
            DisplayAll();
            while (start != end )
            {
                if (checkSort(start.item, pivot))
                {
                    pivot_pre = cur;
                    temp = cur.item;
                    cur.item = start.item;
                    start.item = temp;
                    cur = cur.next;
                }
                start = start.next;
            }
            temp = cur.item;
            cur.item = pivot;
            end.item = temp;
            return pivot_pre;
        }
        public void sort(Func<T, T, bool> checkSort)
        {
            LinkedNode<T> start = head;
            if (start != null)
            {
                LinkedNode<T> end = start;
                while (end.next != null) end = end.next;
                quickSort(start, end, checkSort);
            }
        }
        public void quickSort(LinkedNode<T> start, LinkedNode<T> end, Func<T, T, bool> checkSort)
        {
            if (start == end) return;
            LinkedNode<T> pivot_pre = paritionLast(start, end, checkSort);
            quickSort(start, pivot_pre, checkSort);
            if (pivot_pre != null && pivot_pre == start)
            {
                quickSort(pivot_pre.next, end, checkSort);
            }
            else if (pivot_pre != null && pivot_pre.next != null)
            {
                quickSort(pivot_pre.next, end, checkSort);
            }

        }
        public IEnumerator<T> GetEnumerator()
        {
            LinkedNode<T> cur = head;

            while(cur != null)
            {
                T d = cur.item;
                cur = cur.next;
                yield return d;
            }
           
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
