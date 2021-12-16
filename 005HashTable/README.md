# HashTable
We will write a non-generic `HashTable` class from scratch. We will use `int` data type for its `Key` element and `string` data type for its `Value` element. But before that, If you do not know what is a `HashTable`, please read my explanation. (Otherwise, feel free to jump to the 1st step) 

&nbsp;
### `HashTable` in C#:
In C#, We have 3 classes to represent `HashTable`:

 - `HashTable()` class: It is a non-generic collection that stores **key-value** pairs, similar to generic `Dictionary<TKey, TValue>` collection. (more info at [Microsoft Doc](https://docs.microsoft.com/en-us/dotnet/api/system.collections.hashtable))
 - `Dictionary<TKey, TValue>` class: It is a generic collection that stores **key-value** pairs in no particular order. (more info at [Microsoft Doc](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2))
 - `HashSet<TKey>` class: It provides high-performance set operations. A set is a collection that contains no duplicate elements, and whose elements are in no particular order. It only has `Key` element instead of both `Key` & `Value`, like we have in `HashTable` or `Dictionary`. (more info at [Microsoft Doc](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.hashset-1))

&nbsp;
## What is a `HashTable`?

A hash table is a type of data structure that stores key-value pairs. In `Array`, `LinkedList`, `Stack` and `Queue`, we stored one item each time, while in `HashTable`, we are storing two items at the same time. Unlike `Array`, And just like `LinkedList`, `HashTable` also can grow or shrink automatically by adding/removing items. `HashTable` is so fast to find a `Value` based on the related `Key`. `Key` in `Dictionary` almost works just look like the `Index` in `Array`.

As you saw in "[`HashTable1` in C#](#hashtable-in-c)" section, we have 3 different classes to represent HashTable in C# languages, But usualy we are using `Dictionary<TKey, TValue>` a lot. This class need two items:

- The **first item** in `Dictionary` is `Key`. The `Key` data type can be anything, but all `Keys` should be in the same data type. `Key` value must be unique. (no duplicate elements allowed)

- The **second item** in `Dictionary` is `Value`. The `Value` can be in any kind of data type, but again, all of them should have the same data type. We can have duplicated values here.

&nbsp;
### How `HashTable` Store Elements?
For instance, let’s assume we want to store a list of `Student` objects. Each `Student` has a unique `ID` number. We can use the `Dictionary` collection for this perpose. We will set `TKey` type as Student ID type and for `TValue` we will set its type as `Student` type.

Under the hood, when a `HashTable` receives a pair of Key/Value, It will store the `Value` in a regular `Array`. But under which Index!? For sure it cannot use the `Key` directly! Because the `Key` data type can be anything, **int**, **string**, or a custom type. `HashTable` uses a function called `HashFunction` to get a Key as input and map it into a different value which we called a `HashCode`. (other names for it are: *Hash*, *Digest*, *HashValue*) Then `HashTable` will use that `HashCode` as an index for `Array` to stote related `Value`. 

Now! You should have a pretty good idea where these **Hash** and **Table** words came from! Let's go back to the `Student` collection example and see how we use `Dictionary` in action:

    // Instantiate 3 new Student objects
    var student1 = new Student { Id = 10001, FirstName = "John", LastName = "Smith", Grade = "A-" };
    var student2 = new Student { Id = 10002, FirstName = "Arwin", LastName = "Young", Grade = "A+" };
    var student3 = new Student { Id = 10003, FirstName = "Tom", LastName = "Timoty", Grade = "C+" };
    
    // Declare a new Dictionary object with Key type of 'int' and Value type of 'Student'.
    var students = new Dictionary<int, Student>();
    
    // Now Let's add 3 Student objects with 3 different ways to the 'students' dictionary object:
    
    // students.Add(TKey, TValue). If the same Key exists, An exception will throw.
    students.Add(student1.Id, student1);
    
    // Another way to add a new Key/Value, But if the Key exists in Dictionary, no exception will throw and no changes will be done either.
    students.TryAdd(student2.Id, student2);
    
    // Another way to add new Key/Value to a Dictionary. If the same Key exists, An exception will throw.
    students[student3.Id] = student3;


For each element in `Dictionary` we set `Student.ID`/ `Student` object as a Key/Value pair. But under the hood, `Dictionary` use **Hash Function** to map `Student.ID` to a `HashCode` then use it as an index in array to store related `Value`. Check following table:

|<pre>Key<br>(HashCode)<br>Created by Hash Function based on StudentId</pre>|<pre>Value<br>(Student Object)|
|:--:|:--:|
| 10001 ==> *HashCode1* | student1 |
| 10002 ==> *HashCode2* | student2|
| 10003 ==> *HashCode3* | student3 |

To retrieve any data from a `Dictionary` object, we just need to call our dictionary object with pair of `[]` just like we do in an `Array`. For `index` we should use any of the existing `Key`s and again under the hood, it will be mapped into a HashCode and used to retrieve the Value from Array. 
Note: *if the `Key` does not exist in a collection, we will get an exception*.

    var studentTwo = students[10002];
    Console.WriteLine(studentTwo.FirstName); // Arwin
    

