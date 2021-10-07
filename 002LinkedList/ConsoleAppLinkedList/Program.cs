using System;
using LinkedListDataStructure;

namespace ConsoleAppLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new LinkedList<int>();

            numbers.AddLast(2).AddLast(3).AddFirst(1);

            Console.WriteLine("Items in the list:");
            PrintLinkedList(numbers);

            Console.WriteLine();
            Console.WriteLine("Make the list reverse:");
            numbers.Reverse();
            PrintLinkedList(numbers);

            Console.WriteLine();
            Console.WriteLine("Remove first and last item:");
            PrintLinkedList(numbers.RemoveFirst().RemoveLast());

            Console.WriteLine();
            var students = new LinkedList<Student>();
            students
                .AddFirst(new Student{Id = 1, Name = "Tom"})
                .AddLast(new Student{Id = 2, Name = "John"})
                .AddLast(new Student{Id = 3, Name = "Reza"});

            Console.WriteLine("Students are:");
            PrintLinkedList(students);

            Console.WriteLine();
            Console.WriteLine("Find 'Reza' index in student list:");
            Console.WriteLine(students.IndexOf(new Student{Id = 3, Name = "Reza"}));

            Console.WriteLine();
            Console.WriteLine("Find 'Jack' index in student list:");
            Console.WriteLine(students.IndexOf(new Student{Id = 1, Name = "Jack"}));

        }

        private static void PrintLinkedList(LinkedList<int> numbers)
        {
            foreach (var i in numbers.ToArray())
                Console.WriteLine(i);
        }

        private static void PrintLinkedList(LinkedList<Student> numbers)
        {
            foreach (var student in numbers.ToArray())
                Console.WriteLine($"ID:{student.Id}, {student.Name}");
        }
    }

    // We should add IEquatable<T> interface to support Equal() method at our LinkedList<T>.IndexOf() method.
    public class Student : IEquatable<Student>
    {
        public int Id { get; set; }
        public string Name { get; set; }



        public bool Equals(Student other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id == other.Id && Name == other.Name;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Student)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name);
        }
    }
}
