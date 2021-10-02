/*
 * Author:
 *      Mohammad Reza Kangani
 *
 * Data Structure:
 *      Array
 *
 * Time Complexity:
 *      Lookup by Index	    O(1)
 *      Lookup by Value	    O(n)
 *      Insert	            O(n)
 *      Delete	            O(n)
 *
 * Practice One:
 *      We will write an Array class that can hold integer numbers in a nullable int[] array. It will expand automatically,
 *      if we insert more than its predefined length. For this exercise, please follow the below steps.
 *
 *      Please follow each step sequentially:
 *          (Please check "README.MD" file in the root of "001Array" folder.)
 */

using System;
using System.Collections.Generic;

namespace ArrayDataStructure
{
    public class Array
    {
        #region [STEP 1]
        private readonly int _additionalLength; // [Step 2]

        public int?[] Items { get; private set; }
        public int Count { get; private set; }

        public Array(int length)
        {
            // length should not be less than +1.
            if (length < 1)
                throw new ArgumentException("length cannot be less than 1");

            // Do you know why I added "length % 2" in this equation!? :D
            _additionalLength = length / 2 + length % 2; // [Step 2]
            Items = new int?[length];
            Count = 0;
        }
        #endregion

        #region [STEP 2]
        // We are returning the Array class to support "Fluent Interface" design pattern.
        public Array Insert(int number) // O(1) no expanding --- O(n) Expanding
        {
            // Extract logic of expanding array out of this to support DRY and SRP principles.
            ExpandArray();

            Items[Count++] = number;

            // this line will support "Fluent Interface" design pattern. (chain of Methods)
            return this;
        }

        // Extracted logic of expanding array.
        private void ExpandArray() // O(n)
        {
            if (Count == Items.Length)
            {
                // Create new array with current length plus half of first length at instantiation of this class.
                var expandedArray = new int?[Count + _additionalLength];

                // Cloning current array to new expanded array.
                for (int i = 0; i < Count; i++)
                    expandedArray[i] = Items[i];

                Items = expandedArray;
            }
        }
        #endregion

        #region [STEP 3]
        public Array RemoveAt(int index) // O(n)
        {
            if (index < 0 || index >= Count)
                throw new ArgumentException("Index is out of range!");

            for (int i = index; i < Count; i++)
                Items[i] = i + 1 < Count ? Items[i + 1] : null;
            
            Count--;
            return this;
        }
        #endregion

        #region [STEP4]
        public int IndexOf(int item) // O(n)
        {
            for (var i = 0; i < Items.Length; i++)
                if (Items[i] == item)
                    return i;
            return -1;
        }
        #endregion

        #region [STEP 5]
        public int[] GetItems() // O(n)
        {
            if (IsEmpty())
                throw new Exception("No item exist in array!");

            var list = new int[Count];
            for (var i = 0; i < Count; i++)
                list[i] = Items[i].Value;

            return list;
        }

        private bool IsEmpty() => Count == 0;
        #endregion

        #region [STEP 6]
        public Array Reverse() // O(n)
        {
            if (IsEmpty() || Count == 1)
                return this; // No need to be aggressive and throw exception!
            
            // We are creating new array to store reversed items.
            // We give it the same "length" as main array. Note: "Count" can be smaller than "Items.Length"
            var array = new int?[Items.Length];

            // Then we will fill new array with reversed items. Note: We are using "Count" in the loop.
            for (int i = 0; i < Count; i++)
                array[i] = Items[Count-1-i];

            Items = array;

            return this;
        }
        #endregion
    }

}
