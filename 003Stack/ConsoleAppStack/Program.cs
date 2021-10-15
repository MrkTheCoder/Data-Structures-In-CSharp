using System;
using StackDataStructure;

namespace ConsoleAppStack
{
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack<int>();
            stack.Push(10).Push(20).Push(30);
            Console.WriteLine("Stack items:");
            Console.WriteLine(stack);
            Console.WriteLine();
            Console.WriteLine($"Pop last item in stack: {stack.Pop()}");
            Console.WriteLine("Stack items:");
            Console.WriteLine(stack);
            Console.WriteLine();
            Console.WriteLine($"Peek last item in stack: {stack.Peek()}");
            Console.WriteLine($"Total Items in stack: {stack.Count}");
            Console.WriteLine();
            Console.WriteLine("Pop stack twice...");
            stack.Pop();
            stack.Pop();
            Console.WriteLine($"Is stack empty: {stack.IsEmpty()}");
        }
    }
}
