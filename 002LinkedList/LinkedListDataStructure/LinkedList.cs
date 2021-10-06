﻿using System;
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
        public LinkedList<T> Reverse()
        {
            // Below algorithm works like this. Suppose that we have 10,20,30,40 in the list.
            // 10 -> 20 -> 30 -> 40
            // p     c
            // While start
            //             n
            // 10 <- 20    30 -> 40 current.Next = previous;
            //       p
            //              c 
            // While restart
            //                    n
            // 10 <- 20 <- 30    40 current.Next = previous;
            //             p
            //                   c
            // While restart
            // n = null
            // 10 <- 20 <- 30 <- 40 current.Next = previous;
            //                   p
            // c = null
            // While Exit
            // 
            // Tail = Head
            // Tail.Next = null (It was pointing to 20)
            // Head = p (Now node p is 40 which have chain of Next nodes of 30 to 20 to 10)

            if (IsEmpty())
                return this; // No need to throw exception!

            var previous = Head;
            var current = Head.Next;
            // If we only have one item in the list, below loop will bypass
            while (current is not null) // We reach to the Tail
            {
                var next = current.Next; // Store 3rd node address
                current.Next = previous;
                previous = current;
                current = next;
            }

            Tail = Head;
            Tail.Next = null;
            Head = previous;

            return this;
        }
        #endregion

        #region [STEP 10]
        public T? GetKthNodeFromTheEnd(int k)
        {
            // this algorithm works like this. Let assume we have 4 items in the list:
            // 10 -> 20 -> 30 -> 40
            // and we want 3rd item from end. (it mean 20) 
            // 1st) we set both pointer to the Head node:
            // 10 -> 20 -> 30 -> 40
            // *
            // 2nd) We move second pointer to k-1 = 3rd - 1 = 2 items away from Head:
            // 10 -> 20 -> 30 -> 40
            // *           *
            // 3rd) At while we start moving both pointers to the next node:
            // 10 -> 20 -> 30 -> 40
            //       *           *
            // While Exit (since second pointer is equal to Tail)
            // 4th) firstPointer value will return. (20)

            if (IsEmpty())
                throw new Exception("Empty LinkedList");

            if (k <= 0 || k > Count)
                throw new Exception( $"Your value must be between 1 and {Count}!");

            var firstPointer = Head;
            var secondPointer = Head;

            // To get Kth node from the end, we make k-1 distance between "secondPointer" and "firstPointer"
            for (int i = 0; i < k-1; i++)
                secondPointer = secondPointer.Next;
            
            // NOTE: If we didn't OR not allowed to defined "Count" property, We should use below loop instead of above one.
            //for (int i = 0; i < k; i++)
            //    if (secondPointer == null)
            //        throw new ArgumentOutOfRangeException($"Your value is out of list boundary!");

            // Move forward both pointers until second pointer hit the Tail node.
            while (secondPointer != Tail)
            {
                firstPointer = firstPointer.Next;
                secondPointer = secondPointer.Next;
            }

            return firstPointer.Value;
        }
        #endregion

        // AddAfter
        // RemoveBefore
    }
}
