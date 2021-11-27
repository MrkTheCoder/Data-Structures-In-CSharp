# Array
You can store multiple variables of the same type in an array data structure. Array's in C# have static length. It means, when we're instantiating an array, we should specify its length. After that, we cannot change it anymore! Also, an array can be  [single-dimensional](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/single-dimensional-arrays),  [multidimensional](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/multidimensional-arrays)  or  [jagged](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/jagged-arrays). (More Info: [Arrays - C# Programming Guide | Microsoft Docs](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/)
&nbsp;

&nbsp;

## Array in C#
Declare array in C# are like these:

    int[] nums = new int[10];
    var scores = new int[20];
    var points = new [] {10, 5, 1, 16, 5}; // 'int' array with fixed 'Length' of '5'
    var texts = new string[5];
    var names = new [] {"A", "B"}; // 'String' array with fixed 'Length' of '2'
    var letters = new[] { 'A', 'B', 'C', 'D' }; // 'Char' array with fixed 'Length' of '4'
    var students = new Student[50];

&nbsp;

&nbsp;
**What we will write here?**

We will write an `Array` class step by step with dynamic length. It can hold integer numbers, while It does not have the fixed length problem like array's in C#. It means, if we insert items more than its predefined length, It will automatically expand to have more rooms. But under the hood, we're still using the same `int[]` fixed length array!! So! Let's start this project and see the magic of it!

&nbsp;

&nbsp;
**Array Operations?**

We will add these operations into our `Array` class:
|Operation|Description|Time Complexity|
|--|--|:--:|
|Insert|Add an item to the array.|?|
|RemoveAt|remove an item from specific index.|?|
|IndexOf|Return index of an item in array, or -1 for not exists.|?|
|GetItems|Return all items in the array.|?|
|Reverse|Reverse all items in array.|?|
|InsertAt|Insert an item in specific index.|?|

![notice-icon-7](https://user-images.githubusercontent.com/25789969/135717888-486318b4-7b6b-41ee-af24-bbeb181bb032.png) If you are student and try to learn Data Structure, Please follow each step one by one. In each step, do not look at my code unless you solve it first. It is not important how long it takes to solve it. I put each step inside `#region` blocks, so you can easily collapse all then only expand the one you solved. I did this in both XyzDataStracture & XyzUnitTests projects.

![notice-icon-7](https://user-images.githubusercontent.com/25789969/135717888-486318b4-7b6b-41ee-af24-bbeb181bb032.png) Clean Code principles are advising to structure our Class members like this: 1st private fields/properties, 2nd public properties, 3rd public methods, 4th private methods. But Since I divided this class into some Steps in `region`'s, I put all public & private methods that are related to that step in the same `region`! In real-world programming, we should not do that!

For this exercise, please follow the below steps. 

## 1. Build `Array` class
![Gear_Config](https://user-images.githubusercontent.com/25789969/136387498-f7f72a2b-7516-4c1a-a6bf-f9985d331300.png) Create new `Array` class file with these Conditions:
- Class members:
  - A `private` field `_items` of type `int[]`. We will store inserted items in this array.
  - A `public` property `Count` of type `int` with private setter. It not only keep tracking of the last item index in array but also total of them.
- Class constructor: 1 parameter of type `int` to define array length.
  - Verify that length is valid. `throw` an exception if it is not.
  - Instantiate all properties.
 - A public method, `GetItem(int index)` :
   -  **1 Parameter**: of type int. It is the index of an item in our `_items` array. 
      - Make sure the inserted index is valid, if not, throw an `Exception`. (*HINT*: total of items in the `_items` array is important and not the length of it!)
   - **Return**: type is `int`, the value of `_items[index]`.

Then follow these steps:
- Then write a very simple first *UnitTests* to see if your class Initialization working properly.
- Write a test for `GetItem()` method.


## 2. Add `Insert` method:
![Gear_Config](https://user-images.githubusercontent.com/25789969/136387498-f7f72a2b-7516-4c1a-a6bf-f9985d331300.png) Add `Insert` method with this signature
   - **1 Parameter**: of type int. It will be added as an item to the array.
   - **Return**: void. (for now!)

Then follow these steps:
   1. Make this method ready to add new item into the array. (for now, do not worry about array when it becomes full.)
   2. Write *UnitTest* to make sure it is working properly.
   3. Add capability of automatically expanding the array when we are inserting a new item into a full array. We can expand it 50% of its initialed length. For instance, If we set array length to 10 at first place, then we should add 5 to it each time it needs to expanding its size. So it expands lengths should be 15, 20, 25, ...
   4. Write *UnitTests* against new method feature.
   5. Refactor your code to support **S**ingle **R**esponsibility **P**rinciple (SRP) on this method.
   6. Run all previous *UnitTests* to make sure everything is fine.
   7. We are done here! But for more exercise! Let us making this method and some future ones to support **Fluent Interface** design pattern. If you are not familiar with that, It is so easy to write. To learn how to write it, please check this link: [Fluent Interface Design Pattern](https://dotnettutorials.net/lesson/fluent-interface-design-pattern/).
      - If you make the above improvement, re-run all *UnitTests* again.
   8. What is each method Time Complexity?

## 3. Add `RemoveAt` method:
![Gear_Config](https://user-images.githubusercontent.com/25789969/136387498-f7f72a2b-7516-4c1a-a6bf-f9985d331300.png) Add `RemoveAt` method with this signature:
   - **1 Parameter**: of type `int`. Its value should point to of the inserted items index.
   - **Return**: `void` or if you like to make it **Fluent Interface** support.
     - *HINT*: check for inserted index to be a valid index based on total inserted items. `throw` an exception if it is not.

Then follow these steps:
   1. Make the method ready to use.
   2. Write *UnitTests* for it.
   3. What is this method Time Complexity?

## 4. Add `IndexOf` method:
![Gear_Config](https://user-images.githubusercontent.com/25789969/136387498-f7f72a2b-7516-4c1a-a6bf-f9985d331300.png) Add `IndexOf` method with this signature:
   - **1 Parameter**: of type `int`.  It is an item that we want to search for it in array.
   - **Return**: *int*. If an item found, its index should be return otherwise -1.

Then follow these steps:
 1. Make the method ready.
 2. Write *UnitTests* for it.
 3. What is this method Time Complexity?

## 5. Add `GetItems` method:
![Gear_Config](https://user-images.githubusercontent.com/25789969/136387498-f7f72a2b-7516-4c1a-a6bf-f9985d331300.png) Add `GetItems` method with this signature:
   - **No Parameter**.
   - **Return**: array of `int[]`. Only existing items in array should be return as new array.
     - *HINT*: if array was empty, `throw` an exception.

Then follow these steps:
   1. Make method ready.
   2. Write *UnitTests* for it.
   3. What is method Time Complexity?

## 6. Add `Reverse` method:
![Gear_Config](https://user-images.githubusercontent.com/25789969/136387498-f7f72a2b-7516-4c1a-a6bf-f9985d331300.png) Add `Reverse` method:
   - **No Parameter**.
   - **Return**: `void` or if you like to make it **Fluent Interface** support.
     - *HINT*: if array was empty or only have 1 item, Return without any exception throw.

Then follow these steps:
   1. Make method ready.
   2. Write *UnitTests* for it.
   3. What is method Time Complexity?

## 7. Add `InsertAt` method:
![Gear_Config](https://user-images.githubusercontent.com/25789969/136387498-f7f72a2b-7516-4c1a-a6bf-f9985d331300.png) Add `InsertAt` method with this signature:
   - **2 Parameters**: `item` type of `int` to pass new item, `index` type of `int`.
   - **Return**: `void` or if you like to make it **Fluent Interface** support.
     - *HINT*: `index` must be in range of existing items, otherwise throw exception.

Then follow these steps:
   1. Make method ready.
   2. Write *UnitTests* for it.
   3. What is method Time Complexity?

&nbsp;

&nbsp;
**Array Operations and Time Complexity?**

`Array` operations time complexity are:
|Operation|Description|Time Complexity|
|--|--|:--:|
|Insert|Add an item to the array.|O(1)|
|RemoveAt|remove an item from specific index.|O(n)|
|IndexOf|Return index of an item in array, or -1 for not exists.|O(n)|
|GetItems|Return all items in the array.|O(n)|
|Reverse|Reverse all items in array.|O(n)|
|InsertAt|Insert an item in specific index.|O(n)|

## 8. Extra practices:
We are done here for now! But you can continue to add extra features to it. I suggested a few at below:

 - `Contain(int item)` method: search for an item and return true if it found.
 - `Max()` method: find maximum number and return it.
 - `Intercept(Array other)` method: find intercept items between two arrays and return them as a new `Array` object.
 - `Sort()` method: use one of the sort algorithm to sort the array.
 - Build generic `Array<t>` array!
