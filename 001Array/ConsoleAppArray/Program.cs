using System;
using Array = ArrayDataStructure.Array;

namespace ConsoleAppArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new Array(5);
            numbers.Insert(100).Insert(22).Insert(65).Insert(2).Insert(58);
            
            PrintNumbers(numbers);

            Console.WriteLine();
            Console.WriteLine("Insert number 77 at index 1.");
            numbers.InsertAt(77, 1);
            
            PrintNumbers(numbers);

            Console.WriteLine();
            Console.WriteLine($"Find index of 65: {numbers.IndexOf(65)}");
            Console.WriteLine($"Find index of 57: {numbers.IndexOf(57)}");

            Console.WriteLine();
            Console.WriteLine("Reversing the array.");
            numbers.Reverse();
            PrintNumbers(numbers);

            Console.WriteLine();
            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();
        }

        private static void PrintNumbers(Array numbers)
        {
            Console.WriteLine($"Total Numbers in the list is {numbers.Count}:");
            foreach (var item in numbers.GetItems())
                Console.WriteLine(item);
        }
    }
}
