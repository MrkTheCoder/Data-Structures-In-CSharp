# Array
We will write an Array class that can hold integer numbers in a nullable int[] array. It will expand automatically, if we insert more than its predefined length. For this exercise, please follow the below steps. 

Please follow each step sequentially:

## 1. Build Array class
Create new Array class file with these Conditions:
- Class members:
  - A `public` property of type `int?[]` with private setter. (We will store our numbers in this array)
  - A `public` property of type `int` with private setter. (keep tracking of the last item index in array)
- Class constructor: 1 parameter of type `int` to define array length.
  - Verify that length is valid. `throw` an exception if it is not.
  - Instantiate all properties.

Then write first *UnitTests* to see if your class Initialization working properly.

## 2. Add `Insert` method:
Add Insert method:
   - **1 Parameter**: of type int. It will be added as an item to the array.
   - **Return**: void. (for now!)

Then follow these steps:
   1. Make this method ready to add new item into the array. (for now, do not worry about array when it becomes full.)
   2. Write *UnitTest* to make sure it is working properly.
   3. Add automatically expanding array feature into this method when we are inserting a new item into a full array. Expand the array, 50% of its initialed length. For instance, If we set array length to 10 at first place, then we should add 5 to it each time the array become full again. So it should be 15, 20, 25, ...
   4. Write *UnitTests* against new method feature.
   5. Refactor your code to support **S**ingle **R**esponsibility **P**rinciple (SRP) on this method.
   6. Run all previous *UnitTests* to make sure everything is fine.
   7. We are done here! But for more exercise! Let us making this method and some future ones to support **Fluent Interface** design pattern. If you are not familiar with that, It is so easy to write. To learn how to write it, please check this link: [Fluent Interface Design Pattern](https://dotnettutorials.net/lesson/fluent-interface-design-pattern/).
      - If you make the above improvement, re-run all *UnitTests* again.
   8. What is each method Time Complexity?

3. Add `public` `RemoveAt` method:
   - **1 Parameter**: of type `int`. Its value should point to of the inserted items index.
   - **Return**: `void` or if you like to make it **Fluent Interface** support.
     - *HINT*: check for inserted index to be a valid index based on total inserted items. `throw` an exception if it is not.
   1. Write *UnitTests* for it.
   2. What is this method Time Complexity?

4. Add `public` `IndexOf` method:
   - **1 Parameter**: of type `int`.  It is an item that we want to search for it in array.
   - **Return**: *int*. If an item found, its index should be return otherwise -1.
   1. What is this method Time Complexity?

5. Add `public` `GetItems` method:
   - **No Parameter**.
   - **Return**: array of `int[]`. Only existing items in array should be return as new array.
     - *HINT*: if array was empty, `throw` an exception.
   1. What is method Time Complexity?
