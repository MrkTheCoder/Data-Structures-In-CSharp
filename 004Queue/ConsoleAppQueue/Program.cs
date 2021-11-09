using System;
using QueueDataStructure;

namespace ConsoleAppQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new Queue<int>();
            Console.WriteLine("Adding 10, 20, 30 to the queue:");
            queue.Enqueue(10).Enqueue(20).Enqueue(30);
            Console.WriteLine(queue); // [10, 20, 30, 0, 0]

            Console.WriteLine("Dequeuing 2 item from queue:");
            Console.WriteLine(queue.Dequeue()); // 10
            Console.WriteLine(queue.Dequeue()); // 20
            Console.WriteLine(queue); // [0, 0, 30, 0, 0]

            Console.WriteLine("Adding 2 more item to the queue:");
            queue.Enqueue(40).Enqueue(50);
            Console.WriteLine(queue); // [0, 0, 30, 40, 50]

            Console.WriteLine("Adding 2 more items to the queue (Circular Array Algorithm is working):");
            queue.Enqueue(60); // Adding 60
            queue.Enqueue(70); // Adding 80
            Console.WriteLine(queue); // [60, 70, 30, 40, 50]

            Console.WriteLine("Queue is full, lets try to add another item (80):");
            try
            {
                queue.Enqueue(80); // Adding 80
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception throw in our Queue.Enqueue() method with our custom message: '{ex.Message}'");
            }

            Console.WriteLine("Current Queue:");
            Console.WriteLine(queue); // [60, 70, 30, 40, 50]

            Console.WriteLine("Dequeuing 5 times:");
            Console.WriteLine(queue.Dequeue()); // 30
            Console.WriteLine(queue.Dequeue()); // 40
            Console.WriteLine(queue.Dequeue()); // 50
            Console.WriteLine(queue.Dequeue()); // 60
            Console.WriteLine(queue.Dequeue()); // 70
            Console.WriteLine(queue); // [0, 0, 0, 0, 0]

        }
    }
}
