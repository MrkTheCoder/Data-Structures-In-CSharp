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
 *      We will write an Array class that can hold integer numbers in a nullable array. It will expand automatically, if we insert more than its
 *      length. For this exercise, please follow my below steps. After each step, check your code with mine. 
 *
 *      Please follow each step sequentially:
 *          1) Build Array class with these conditions:
 *              *. Members:
 *                  public property "Items" of type int?[] with private setter. (We will store our numbers in this array)
 *                  public property "Count" of type int with private setter. (keep track of total inserted numbers and latest free array index)
 *              *. At instantiation, it should ask for array length.
 *              *. Verify that length is valid. throw an exception if it is not.
 *                      [T]. Write Unit Test.
 *
 *          2) Add public Insert method in these steps:
 *              1st) It has a parameter: Item of type int. It will add it to the array.
 *                      [T]. Write the first Unit Test to make sure it work properly.
 *              2nd) Expand array 50% of its initialed length, if it becomes full. We need to store value of first instantiated length.
 *                   (You can change this rule based on your desire.)
 *                      [T]. Write Unit Tests.
 *              3ed) Refactor your code to support Single Responsibility Principle (SRP) on this method. (Also it will cover Don't Repeat
 *                   Yourself [DRY] principle too)
 *                      [T]. Run all previous Unit Test to make sure everything go smoothly.
 *              4th) Support Fluent Interface design pattern. (What is Fluent Interface design patter is:
 *                   https://dotnettutorials.net/lesson/fluent-interface-design-pattern/)
 *                      [T]. Run all previous Unit Test to make sure everything go smoothly.
 *              5th) What is each method Time Complexity?
 *
 *          3) Add public RemoveAt method:
 *              *. It has a parameter: Index of type int. This is the index of one of the inserted items.
 *              *. HINT: check for index to be valid based on total inserted items. throw an exception if it is not.
 *                  [T]. Write Unit Test.
 *              *. What is method Time Complexity?
 */

using System;

namespace ArrayDataStructure
{
    public class Array
    {
        #region [STEP 1]
        private readonly int _initialLength; // [Step 2]

        public int?[] Items { get; private set; }
        public int Count { get; private set; }

        public Array(int length)
        {
            // length should not be less than +1.
            if (length < 1)
                throw new ArgumentException("length cannot be less than 1");

            _initialLength = length ; // [Step 2]
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
                // If _initialLength = 1 can make trouble! ;) Why!?
                var newLength = Count + (_initialLength == 1 ? 1 : _initialLength / 2);
                var expandedArray = new int?[newLength];

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
    }

}
