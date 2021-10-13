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
 *      We will write an Array class step by step. It can hold integer numbers in a nullable int[] array. Also, It does not have fixed
 *      length problem like regular arrays have. I mean, if we insert items more than its predefined length, It will automatically expand
 *      the array to have more rooms. 
 *
 *      Please follow each step sequentially:
 *          (Please check "README.MD" file in the root of "001Array" folder.)
 *           https://github.com/MrkTheCoder/Data-Structures-In-CSharp/tree/master/001Array#readme
 */

using System;

namespace ArrayDataStructure
{
    public class Array
    {
        #region [STEP 1]
        private readonly int _additionalLength; // [Step 2]

        private int[] _items;
        public int Count { get; private set; }

        public Array(int length)
        {
            // length should not be less than +1.
            if (length < 1)
                throw new ArgumentException("length cannot be less than 1");

            // Half of length plus one will be our extra rooms when Array need to expand.
            _additionalLength = length / 2 + 1; // [Step 2]
            _items = new int[length];
            Count = 0;
        }

        public int GetItem(int index)
        {
            // It is better to make a simple method with meaningful name instead of just writing "index < 0 || index >= Count".
            // Beside that we will use this logic again.
            if (IsIndexOutOfRange(index))
                throw new ArgumentException("Index is out of range!");
            
            return _items[index];
        }

        private bool IsIndexOutOfRange(int index) => index < 0 || index >= Count;
        #endregion

        #region [STEP 2]
        // We are returning the Array class to support "Fluent Interface" design pattern.
        public Array Insert(int number) // O(1) no expanding --- O(n) Expanding
        {
            // Extract logic of expanding array out of this to support DRY and SRP principles.
            ExpandArray();

            _items[Count++] = number;

            // this line will support "Fluent Interface" design pattern. (chain of Methods)
            return this;
        }

        // Extracted logic of expanding array.
        private void ExpandArray() // O(n)
        {
            if (Count == _items.Length)
            {
                // Create new array with current length plus half of first length at instantiation of this class.
                var expandedArray = new int[Count + _additionalLength];

                // Cloning current array to new expanded array.
                for (int i = 0; i < Count; i++)
                    expandedArray[i] = _items[i];

                _items = expandedArray;
            }
        }
        #endregion

        #region [STEP 3]
        public Array RemoveAt(int index) // O(n)
        {
            if (IsIndexOutOfRange(index)) // We create this logic in STEP 1
                throw new ArgumentException("Index is out of range!");

            for (int i = index; i < Count; i++)
                _items[i] = i + 1 < Count ? _items[i + 1] : 0;
            
            Count--;
            return this;
        }
        #endregion

        #region [STEP 4]
        public int IndexOf(int item) // O(n)
        {
            for (var i = 0; i < _items.Length; i++)
                if (_items[i] == item)
                    return i;
            return -1;
        }
        #endregion

        #region [STEP 5]
        public int[] GetItems() // O(n)
        {
            // It is better to make a simple method with meaningful name instead of just writing "Count == 0".
            // Beside that we will use this logic again.
            if (IsEmpty())
                throw new Exception("No item exist in array!");

            // We should only return a new array with Count size and not the whole "Items" length.
            var list = new int[Count];
            for (var i = 0; i < Count; i++)
                list[i] = _items[i];

            return list;
        }

        private bool IsEmpty() => Count == 0;
        #endregion

        #region [STEP 6]
        public Array Reverse() // O(n)
        {
            // We create a logic like this at step 5!
            if (!IsReversible())
                return this; // No need to be aggressive and throw exception!
            
            // We are creating a new array to store reversed items.
            // We give it the same "length" as main array. Note: "Count" can be smaller than "Items.Length"
            var array = new int[_items.Length];

            // Then we will fill the new array with reversed items. Note: We are using "Count" in the loop.
            for (int i = 0; i < Count; i++)
                array[i] = _items[Count-1-i];

            _items = array;

            return this;
        }

        private bool IsReversible() => !(IsEmpty() || Count == 1);
        #endregion

        #region [STEP 7]
        public Array InsertAt(int item, int index)
        {
            if (IsIndexOutOfRange(index))  // We create this logic in STEP 1
                throw new ArgumentException("Index is out of range!");
        
            ExpandArray();

            for (int i = Count-1; i >= index; i--)
            {
                _items[i + 1] = _items[i];
            }
            _items[index] = item;
            Count++;

            return this;
        }
        #endregion
    }

}
