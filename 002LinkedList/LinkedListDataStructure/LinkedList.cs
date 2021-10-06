#nullable enable
namespace LinkedArrayDataStructure
{
    public class LinkedList<TType>
    {
        #region [STEP 1]
        private Node<TType>? Head { get; set; } // Head should be private, but for Unit Testing purpose we defined like this.
        private Node<TType>? Tail { get; set; } // Tail should be private, but for Unit Testing purpose we defined like this.
        public int Count { get; private set; }

        // Node class should defined as private since we do not need to access it from outside
        // But to be able to use Head/Tail properties in unit Tests, for now we defined public.
        // Define Node class inside of LinkedList, is another reason that we do not want to use
        // it from outside.
        public class Node<TType>
        {
            public TType Value { get; set; }
            public Node<TType>? Next { get; set; }
        }

        public Node<TType> GetHead() => Head;
        #endregion


        #region [STEP 2]
        public LinkedList<TType> AddLast(TType item)
        {
            var node = new Node<TType> { Value = item };

            // Check to see if is it first node?
            if (IsEmpty())
                // If you want to know how LinkedList works, these three next line are the most important lines,
                // that you should understand them very well.
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


        // AddLast
        // DeleteFirst
        // DeleteLast
        // IndexOf
        // Contains
        // AddAfter
        // RemoveBefore
        // Reverse
        // FindKthNodeFromEnd
    }
}
