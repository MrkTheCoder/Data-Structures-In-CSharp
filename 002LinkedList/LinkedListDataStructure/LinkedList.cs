using System;
using System.Collections.Generic;
using System.Drawing;

#nullable enable
namespace LinkedListDataStructure
{
    public class LinkedList<T>
    {
        #region [STEP 1]
        // Head & Tail should be private, but for Unit Testing purpose I define them as public properties.
        public Node<T>? Head { get; set; } 
        public Node<T>? Tail { get; set; }
        public int Count { get; private set; }

        // Node class is implementation details of LinkedList it should defined as private also
        // we do not need to access it from outside. But to be able to use Head/Tail properties
        // in our unit Tests, for now we defined public.
        public class Node<TType>
        {
            public TType Value { get; set; }
            public Node<TType>? Next { get; set; }

            public Node(TType value)
            {
                Value = value;
            }
        }
        #endregion

        #region [STEP 2]
        public LinkedList<T> AddLast(T item)
        {
            var node = new Node<T>(item);

            // Check to see if is it first node?
            if (IsEmpty())
                // If you want to know how LinkedList works, these next three lines are the most important lines,
                // that you should understand them very well. Please check LinkedListUnitTests\"region [Tests for STEP 2]" 
                Head = Tail = node;
            else
            {
                Tail.Next = node;
                Tail = node;
            }

            Count++;
            return this;
        }

        private bool IsEmpty() => Head == null;
        #endregion

        #region [STEP 3]
        public LinkedList<T> AddFirst(T item)
        {
            var node = new Node<T>(item);

            // Check to see if is it first node?, we created this logic at STEP 1.
            if (IsEmpty())
                Head = Tail = node;
            else
            {
                node.Next = Head;
                Head = node;
            }

            Count++;
            return this;
        }        
        #endregion

        #region [STEP 4]
        public int IndexOf(T item)
        {
            var index = 0;
            var node = Head;
            while (node is not null)
            {
                // NOTE: if T is a reference type, we should implement IEquatable<T> interface on T.
                if (node.Value != null && node.Value.Equals(item))
                    return index;

                index++;
                node = node.Next;
            }

            return -1;
        }
        #endregion

        #region [STEP 5]
        public bool Contain(T item)
        {
            return IndexOf(item) != -1;
        }
        #endregion

        #region [STEP 6]
        public LinkedList<T> RemoveFirst()
        {
            if (IsEmpty())
                throw new Exception("No node exists!");

            if (!Reset())
            {
                var node = Head.Next;
                Head.Next = null;
                Head = node;
            }   
            
            Count--;
            return this;
        }

        private bool Reset()
        {
            if (Head == Tail)
            {
                Head = Tail = null;
                return true;
            }
            return false;
        }
        #endregion

        #region [STEP 7]
        public LinkedList<T> RemoveLast()
        {
            if (IsEmpty())
                throw new Exception("No node exists!");

            if (!Reset())
            {
                var previous = Head;
                while (previous is not null)
                {
                    if (previous.Next == Tail)
                        break;
                    previous = previous.Next;
                }

                Tail = previous;
                Tail.Next = null;
            }

            Count--;
            return this;
        }
        #endregion

        #region [STEP 8]
        public T[] ToArray()
        {
            T[] array = new T[Count];

            var current = Head;
            var index = 0;
            while (current is not null)
            {
                array[index++] = current.Value;
                current = current.Next;
            }

            return array;
        }
        #endregion

        #region [STEP 9]

        #endregion
        // DeleteFirst
        // DeleteLast
        // AddAfter
        // RemoveBefore
        // Reverse
        // FindKthNodeFromEnd
    }
}
