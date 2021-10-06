using System;
using LinkedListDataStructure;

namespace ConsoleAppLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new LinkedList<int>();
            list.AddLast(10);
            var first = list.Head;
            first = new LinkedList<int>.Node<int>();
            Console.WriteLine(list.Head);

        }
    }
}
