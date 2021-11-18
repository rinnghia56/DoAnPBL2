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

        public IEnumerator<T> GetEnumerator()
        {
            LinkedNode<T> cur = head;
            
            do
            {
                T d = cur.item;
                cur = cur.next;
                yield return d;
            } while (cur != null);
           
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
