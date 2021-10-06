#nullable enable
namespace LinkedListDataStructure
{
    public class LinkedList<TType>
    {
        #region [STEP 1]
        public Node<TType>? Head { get; set; } // Head should be private, but for Unit Testing purpose we defined like this.
        public Node<TType>? Tail { get; set; } // Tail should be private, but for Unit Testing purpose we defined like this.
        public int Count { get; private set; }

        // Node class should defined as private since we do not need to access it from outside
        // But to be able to use Head/Tail properties in unit Tests, for now we defined public.
        // Also the reason that we are defining Node class inside of LinkedList class is that
        // we do not want to use/call it directly from outside of this class.
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
        public LinkedList<TType> AddLast(TType item)
        {
            var node = new Node<TType>(item);

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
