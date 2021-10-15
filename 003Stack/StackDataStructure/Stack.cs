#nullable enable
using System;

namespace StackDataStructure
{
    public class Stack<T> 
    {
        #region [STEP 1]
        private T?[] Items { get; set; }
        public int Count { get; private set; }

        public Stack()
        {
            Items = new T?[5];
        }
        #endregion

        #region [STEP 2]
        public Stack<T> Push(T? item) // O(1)
        {
            // Since we are using regular array under hood,
            // We need to expand its length when it needed.
            // Good thing is we learn this from first topic:
            // "Array Data Structure".
            ExpandArray();

            // We add new inserted Item to the end of our array.
            Items[Count++] = item;

            return this;
        }

        private void ExpandArray() // O(n)
        {
            if (Count == Items.Length)
            {
                var expandedArray = CopyArray(Count + 5, Count);

                Items = expandedArray;
            }
        }

        // We will use this method several times.
        private T[] CopyArray(int targetArrayLength, int sourceArrayItemCount)
        {
            var newItems = new T[targetArrayLength];
            Array.Copy(Items, newItems, sourceArrayItemCount);

            return newItems;
        }
        #endregion

        #region [STEP 3]
        public T? Peek() // O(1)
        {
            if (IsEmpty())
                throw new NullReferenceException();

            // We only return the last item in array. It is look like
            // that it is the top item of stack.
            return Items[Count - 1];
        }

        public bool IsEmpty()
        {
            return Count == 0;
        }
        #endregion

        #region [STEP 4]
        public T? Pop() // O(1)
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            // We are not only return the last item in the array,
            // but also by decreasing the Count variable we are
            // ignoring its value by removing its index. ( No need
            // to remove its value!)
            return Items[--Count];
        }
        #endregion


        #region [STEP 5]
        public override string ToString()
        {
            // First take out all Items.
            var newItems = CopyArray(Count, Count);

            return $"[{string.Join(',', newItems)}]";
        } 
        #endregion
    }
}