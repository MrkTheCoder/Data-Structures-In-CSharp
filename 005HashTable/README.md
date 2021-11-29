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

A hash table is a type of data structure that stores key-value pairs. In `Array`, `LinkedList`, `Stack` and `Queue`, we stored one item each time, while in `Dictionary`, we store two items at the same time.

As you saw in "[`HashTable1` in C#](#hashtable-in-c)" section, we have 3 different classes to represent HashTable in C# languages, But usualy we are using `Dictionary<TKey, TValue>` a lot. This class need two items:

- The **first item** (`TKey`) in `Dictionary` calls `Key`. The `Key` data type can be anything, but all `Keys` should be in the same data type. `Key` value must be unique. (no duplicate elements allowed)

- The **second item** (`TValue`) in `Dictionary` calls `Value`. The `Value` can be in any kind of data type, but again, all of them should have the same data type. The value of `Value`s can be duplicated.
