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
 *      We will write an Array class that can hold integer numbers in an array and it will expand automatically if we insert more than its
 *      first length that we set at class instantiation. (then we will change this class to support generic array).
 *
 *      Please follow each step sequentially:
 *          1) Build Array class with these conditions:
 *              *. Members (You will add more fields and properties based on new requirements, when you go to next steps):
 *                  A public property of type int[] with private setter. (We will store our numbers in this array)
 *                  A public property of type int with private setter. (keep track of total inserted numbers and latest free array index)
 *              *. At instantiation, it should ask for array length.
 *              *. Verify that length is valid.
 *
 *          2) Add public Insert method in these steps:
 *              *.  1st) It accepts an Item of type int and add it to the array.
 *                      *. Write the first Unit Test to make sure it work properly.
 *              *.  2nd) Expand array 50% of its initialed length, if it becomes full. We need to store value of first instantiated length.
 *                      (You can change this rule based on your desire.)
 *                      *. Write Unit Test.
 *              *.  3) Refactor your code to support Single Responsibility Principle (SRP) on this method. (Also it will cover Don't Repeat
 *                  Yourself [DRY] principle too)
 *                      *. Run all previous Unit Test to make sure everything go smoothly.
 *              *.  4) Support Fluent Interface design pattern. (What is Fluent Interface design patter is:
 *                  https://dotnettutorials.net/lesson/fluent-interface-design-pattern/)
 *                      *. Run all previous Unit Test to make sure everything go smoothly.
 */

using System;

namespace DataStructureArray
{
    public class Array
    {
        #region [Step 1]
        private readonly int _initialLength; // [Step 2]
        
        public int[] Items { get; private set; }
        public int Count { get; private set; }

        public Array(int length)
        {
            // length should not be less than +1.
            if (length < 1)
                throw new ArgumentException("length cannot be less than 1");
            
            _initialLength = length; // [Step 2]
            Items = new int[length];
            Count = 0;
        }
        #endregion


        #region [Step 2]
        // We are returning the Array class to support "Fluent Interface" design pattern.
        public Array Insert(int number)
        {
            // Extract logic of expanding array out of this to support DRY and SRP principles.
            ExpandArray();

            Items[Count++] = number;

            // this line will support "Fluent Interface" design pattern. (chain of Methods)
            return this;
        }


        // Extracted logic of expanding array.
        private void ExpandArray()
        {
            if (Count == Items.Length)
            {
                // Create new array with current length plus half of first length at instantiation of this class.
                var expandedArray = new int[Count+(_initialLength/2)];

                // Cloning current array to new expanded array.
                for (int i = 0; i < Count; i++)
                    expandedArray[i] = Items[i];

                // set current array to new expanded array with its extra rooms.
                Items = expandedArray;
            }
        }
        #endregion

    }

}
