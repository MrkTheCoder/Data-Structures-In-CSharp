using System;
using System.Collections.Generic;
using System.Drawing;

#nullable enable
namespace LinkedListDataStructure
{
    public class LinkedList<T>
    {
        #region [STEP 1]
        // Head & Tail should be private, but for Unit Testing and learning purpose I define them as public
        // properties, so we can examine them further.
        public Node<T>? Head { get; private set; } 
        public Node<T>? Tail { get; private set; }
        public int Count { get; private set; }

        // Node class is implementation details of LinkedList it should defined as private also
        // we do not need to access it from outside. But to be able to use Head/Tail properties
        // in our unit Tests, for now we defined public.
        public class Node<TType>
        {
            public TType Value { get;}
            public Node<TType>? Next { get; set; }

            public Node(TType value)
            {
                Value = value;
            }
        }
        #endregion

        #region [STEP 2]
        public LinkedList<T> AddLast(T item) // O(1)
        {
            var node = new Node<T>(item);

            // Check to see if the list is empty?
            if (IsEmpty())
                // If you want to know how LinkedList works, these next three lines are the most important lines,
                // that you should understand them very well. Please check LinkedListUnitTests\"region [Tests for STEP 2]" 
                Head = Tail = node;
            else
            {
                Tail.Next = node;
                Tail = node;
            }

            // Always place counter at the end of your method.
            Count++;
            return this;
        }

        private bool IsEmpty() => Head == null;
        #endregion

        #region [STEP 3]
        public LinkedList<T> AddFirst(T item) // O(1)
        {
            var node = new Node<T>(item);

            // Check to see if the list is empty. We created this logic at STEP 2 and reuse it again.
            if (IsEmpty())
                Head = Tail = node;
            else
            {
                node.Next = Head;
                Head = node;
            }

            // Always place counter at the end of your method.
            Count++;
            return this;
        }        
        #endregion

        #region [STEP 4]
        public int IndexOf(T item) // O(n)
        {
            var index = 0;
            var node = Head;
            while (node is not null) // If node is null, either list is empty or we reach to Tail.Next. 
            {
                // NOTE: if T is a reference type, we should implement IEquatable<T> interface on T.
                if (node.Value != null && node.Value.Equals(item))
                    return index;

                index++;
                // Go to the next node! This is how we loop over LinkedLists:
                node = node.Next;
            }

            return -1;
        }
        #endregion

        #region [STEP 5]
        public bool Contain(T item) // O(n)
            => IndexOf(item) != -1;
        #endregion

        #region [STEP 6]
        public LinkedList<T> RemoveFirst() // O(1)
        {
            if (IsEmpty())
                throw new InvalidOperationException("No node exists!");

            // We should check, if there are only one item in the list,
            // Then Set both Head & Tail to null. (Reset the list)
            if (!Reset())
            {
                var node = Head.Next;
                Head.Next = null;
                Head = node;
            }   
            
            // Always place counter at the end of your method.
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
        public LinkedList<T> RemoveLast() // O(n)
        {
            if (IsEmpty())
                throw new InvalidOperationException("No node exists!");
            
            if (!Reset())
            {
                var previous = Head;
                // Based on our both previous checks (IsEmpty() & Reset() methods)
                // for sure we at least have 2 items in the list. so "previous" and
                // "previous.Next" at left side of this equation "(previous.Next != Tail)"
                // will never be null.
                while (previous.Next != Tail) 
                    previous = previous.Next;

                Tail = previous;
                Tail.Next = null;
            }

            // Always place counter at the end of your method.
            Count--;
            return this;
        }
        #endregion

        #region [STEP 8]
        public T[] ToArray() // O(n)
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
        public LinkedList<T> Reverse() // O(n)
        {
            // Below algorithm works like this. Suppose that we have 10,20,30,40 in the list.
            // 3 letters under each node stand for:  p = Previous     c = Current     n = Next
            // Nodes are:
            //      10 -> 20 -> 30 -> 40
            // After "IsEmpty()" check done, execution will go like these:

            if (IsEmpty())
                return this; // No need to throw exception!

            //
            // 10 -> 20 -> 30 -> 40
            // p     c
            // While start
            //             n
            // 10 <- 20    30 -> 40 Reverse Link (current.Next = previous;)
            //       p
            //              c 
            // While restart
            //                    n
            // 10 <- 20 <- 30    40 Reverse Link (current.Next = previous;)
            //             p
            //                   c
            // While restart
            //                         n (null)
            // 10 <- 20 <- 30 <- 40  Reverse Link (current.Next = previous;)
            //                   p
            // c = n (null)
            // While Exit
            // 
            // Tail = Head
            // Tail.Next = null (Still, It was pointing to 20)
            // Head = p (Now node p is 40 which have chain of Next nodes to 30 to 20 to 10)

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
        public T? GetKthNodeFromTheEnd(int k) // O(n)
        {
            // this algorithm works like this. Let assume we have 4 items in the list:
            // 10 -> 20 -> 30 -> 40
            // and we want 3rd item from end. (it mean 20) 
            //
            // 1st) we set both pointer to the Head node:
            // 10 -> 20 -> 30 -> 40
            // *
            // 2nd) We move second pointer to k-1 = 3 - 1 = 2 items away from Head:
            // 10 -> 20 -> 30 -> 40
            // *           *
            // 3rd) At while we start moving both pointers to the next node:
            // 10 -> 20 -> 30 -> 40
            //       *           *
            // While Exit (since second pointer is equal to Tail)
            // 4th) firstPointer.Value has our desire 3rd item. (20)

            if (IsEmpty())
                throw new InvalidOperationException("Empty LinkedList");

            if (k <= 0 || k > Count)
                throw new ArgumentOutOfRangeException( "",$"Your value must be between 1 and {Count}!");

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
    }
}
