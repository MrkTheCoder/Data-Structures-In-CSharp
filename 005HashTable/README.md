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

A hash table is a type of data structure that stores key-value pairs. In `Array`, `LinkedList`, `Stack` and `Queue`, we stored one item each time, while in `Dictionary`, we store two items at the same time. Unlike `Array`, And just like `LinkedList`, `HashTable` also can grow or shrink automatically, when we are adding/removing items. But they are so fast to find a `Value` based on the related `Key` for that `Value` which we defined. `Key` in `Dictionary` almost works just look like the `Index` in `Array`.

As you saw in "[`HashTable1` in C#](#hashtable-in-c)" section, we have 3 different classes to represent HashTable in C# languages, But usualy we are using `Dictionary<TKey, TValue>` a lot. This class need two items:

- The **first item** (`TKey`) in `Dictionary` calls `Key`. The `Key` data type can be anything, but all `Keys` should be in the same data type. `Key` value must be unique. (no duplicate elements allowed)

- The **second item** (`TValue`) in `Dictionary` calls `Value`. The `Value` can be in any kind of data type, but again, all of them should have the same data type. The value of `Value`s can be duplicated.

&nbsp;
### Knowing `HashTable` With a Simple Example:
For instance, let's assume we want to store a `Student` object list in a collection then find any student based on its unique `ID` number. `Student` object can have multiple members like, `StudentId`,  `FirstName`, `LastName`, `Grade` & .... But Since we are only interesting to find a `Student` object with its unique `StudentId` Number, The best suitable collection for this job is a `Dictionary` collection. For each element in our `Dictionary` collection, We can use each `StudentId` number as it `Key` and the whole `Student` object as it `Value`. But how `HashTable` use and store the Key and Value for each element!? Please check the following topic.

&nbsp;
### Structure of `HashTable`?
`HashTable` use a **Hash function** to produce a `HashCode` for each `Key` it received. Since all `Key`s are unique, then their `HashCode`'s will be unique too. Then `HashTable` will store the `HashCode` and its related `Value` into the same row at a table. 

Now! You should have a pretty good idea where these **Hash** and **Table** words came from in `HashTable` name! Let's go back to the `Student` collection example and create a **Table** to represent a `HashTable` data structure. Let's store some `Student` objects:

    var student1 = new Student { Id = 10001, FirstName = "John", LastName = "Smith", Grade = "A-" };
    var student2 = new Student { Id = 10002, FirstName = "Arwin", LastName = "Young", Grade = "A+" };
    var student3 = new Student { Id = 10003, FirstName = "Tom", LastName = "Timoty", Grade = "C+" };
    
    // Declare a new Dictionary object with Key type of 'int' and Value type of 'Student'.
    var students = new Dictionary<int, Student>();
    
    // students.Add(TKey, TValue). If the same Key exists, An exception will throw.
    students.Add(student1.Id, student1);
    // Another way to add new Key/Valye, But if the Key exists in Dictionary, no exception will throw.
    students.TryAdd(student2.Id, student2);
    // Another way to add new Key/Value to a Dictionary. If the same Key exists, An exception will throw.
    students[student3.Id] = student3;


We set `Student.ID` as `Key` for each `Student` object as a `Value`. But under the hood, `Dictionary` use **Hash Function** to convert `Student.ID` to a `HashCode` then store `HashCode` as a `Key` for related a `Value`. Check following table:

|<pre>Key<br>(HashCode)<br>Created by Hash Function based on StudentId</pre>|<pre>Value<br>(Student Object)|
|:--:|:--:|
| 12512 | student1 |
| 98542 | student2|
| 57457 | student3 |
