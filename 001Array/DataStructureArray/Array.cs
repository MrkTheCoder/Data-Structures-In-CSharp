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
 *      Try to write Array class that can hold integer numbers in an array. Follow each step sequentially:
 *          1) Build Array class with these conditions:
 *              *. Two members:
 *                  A private field of type int[]. (We will store our numbers in this array)
 *                  A public property of type int with private setter. (keep track of total inserted numbers and latest free array index)
 *              *. At instantiation, it should ask for array length.
 *              *. Verify that length is valid.
 *          2) Add public Insert method in these 3 steps:
 *              *. 1) It accepts an Item of type int and add it to the array.
 *              *. 2) Expand array 50% of its initialed length, if it becomes full. (You can change this rule based on your desire.)
 *              *. 3) Apply Single Responsibility Principle (SRP) on this method. (Also it will cover Don't Repeat Yourself [DRY] principle too)
 *              *. 4) Support Fluent Interface design pattern. (What is Fluent Interface design patter is: https://dotnettutorials.net/lesson/fluent-interface-design-pattern/)
 */

using System;

namespace DataStructureArray
{
    public class Array
    {
        private int[] _array;
        private readonly int _initialLength;

        public int Length => _array.Length;
        public int Count { get; private set; }

        public Array(int length)
        {
            // length should not be less than +1.
            if (length < 1)
                throw new ArgumentException("length cannot be less than 1");
            
            _initialLength = length;
            _array = new int[length];
            Count = 0;
        }
        
        // We are returning the Array class to support "Fluent Interface" design pattern.
        public Array Insert(int number)
        {
            // Extract logic of expanding array out of this to support DRY and SRP principles.
            ExpandArray();

            _array[Count++] = number;

            // this line will support "Fluent Interface" design pattern. (chain of Methods)
            return this;
        }


        // Extracted logic of expanding array.
        private void ExpandArray()
        {
            if (Count == Length)
            {
                // Create new array with current length plus half of first length at instantiation of this class.
                var expandedArray = new int[Count+(_initialLength/2)];

                // Cloning current array to new expanded array.
                for (int i = 0; i < Length; i++)
                    expandedArray[i] = _array[i];

                // set current array to new expanded array with its extra rooms.
                _array = expandedArray;
            }
        }

    }

}
