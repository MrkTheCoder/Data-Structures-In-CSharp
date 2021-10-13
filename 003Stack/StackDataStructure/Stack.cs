#nullable enable
using System;

namespace StackDataStructure
{
    public class Stack<T> 
    {
        #region [STEP 1]
        public T?[] Items { get; private set; }
        public int Count { get; private set; }

        public Stack()
        {
            Items = new T?[5];
        }
        #endregion

        #region [STEP 2]
        public Stack<T> Push(T? item) // O(1)
        {
            ExpandArray();

            Items[Count++] = item;

            return this;
        }

        private void ExpandArray() // O(n)
        {
            if (Count == Items.Length)
            {
                // Create new array with current length + 10 more room.
                // Cloning current array to new expanded array.
                var expandedArray = CopyArray(Count + 10, Count);

                Items = expandedArray;
            }
        }

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
                throw new NullReferenceException();

            return Items[--Count];
        }
        #endregion


        #region [STEP 5]
        public override string ToString()
        {
            var newItems = CopyArray(Count, Count);

            return $"[{String.Join(',', newItems)}]";
        } 
        #endregion
    }
}