# LinkedList<T>
We will write a generic LinkedList class step by step.

![notice-icon-7](https://user-images.githubusercontent.com/25789969/135717888-486318b4-7b6b-41ee-af24-bbeb181bb032.png) If you are student and try to learn Data Structure, Please follow each step one by one. In each step, do not look at my code unless you solve it first. It is not important how long it takes to solve it. I put each step inside `#region` blocks, so you can easily collapse all then only expand the one you solved. I did this in both XyzDataStracture & XyzUnitTests projects.

For this exercise, please follow the below steps. 

## 1. Build `LinkedList<T>` & `Node<T>` classes
Create new `LinkedList<T>` class file with these Conditions:
- Class members:
  - `public` class Node<T> inside it with these members:
    - A `public` property of type `T` to store value.
    - A `public` property of type `Node<T>` to store next node address.
    - A Constructor with 1 Parameter: of type T to set on Node value property.
  - A `public` property of type `Node<T>` to store head of list address.
  - A `public` property of type `Node<T>` to store tail of list address.
  - A `public` property of type `int` to count list items.

![notice-icon-7](https://user-images.githubusercontent.com/25789969/135717888-486318b4-7b6b-41ee-af24-bbeb181bb032.png) We shouldn't define Head/Tail and Node Class as public members of `LinkedList`, but just for unit test's purpose I did that.

## 2. Add `AddLast` method:
`AddLast(T item)` method will add a new item to the end of  `LinkedList`. Define `AddLast` method with:
   - **1 Parameter**: of type T. It will be added to the end of `LinkedList`.
   - **Return**: `void` or, if you like to make it **Fluent Interface**, set return type as `LinkedList<T>`.

Then follow these steps:
   1. Make this method ready to add new item into the `LinkedList`.
   2. Write *UnitTest* to make sure it is working properly.
   3. What is the method Time Complexity?

I add many comments not only at this method but also at Unit Tests class in region "[Tests for STEP 2]". Please check them after you wrote above method by your own.-run all *UnitTests* again.

## 3. Add `AddFirst` method:
`AddFirst(T item)` method will add a new item to the beginning of  `LinkedList`. Define `AddFirst` method with:
   - **1 Parameter**: of type T. It will be added to the beginning of `LinkedList`.
   - **Return**: `void` or if you like to make it **Fluent Interface**, set return type as `LinkedList<T>`.

Then follow these steps:
   1. Make this method ready to add new item into the `LinkedList`.
   2. Write *UnitTest* to make sure it is working properly.
   3. What is the method Time Complexity?

## 4. Add `IndexOf` method:
`IndexOf(T item)` method will compare each `Node.Value` property of `LinkedList` with inserted `item`, and if it found a match, then it will return the index of that node. Otherwise -1. As you know, `LinkedList` does not work with index like Array's do. So! Find a way! Define `IndexOf` method with:
   - **1 Parameter**: of type T. It will be compared with each `Node.Value` in the `LinkedList`.
   - **Return**: `int` type. Index of node based on its distance from Head.(Zero Based) or -1, for not exist items.

Then follow these steps:
   1. Write this method.
   2. Write *UnitTest* to make sure it is working properly.
   3. What is the method Time Complexity?

NOTE: Please, check my comments at this method.

## 5. Add `Contain` method:
`IndexOf(T item)` method will compare each `Node.Value` property of `LinkedList` with inserted `item`, and if it found a match, then it will return the index of that node. Otherwise -1. As you know, `LinkedList` does not work with index like Array's do. So! Find a way! Define `IndexOf` method with:
   - **1 Parameter**: of type T. It will be compared with each `Node.Value` in the `LinkedList`.
   - **Return**: `int` type. Index of node based on its distance from Head.(Zero Based) or -1, for not exist items.

Then follow these steps:
   1. Write this method.
   2. Write *UnitTest* to make sure it is working properly.
   3. What is the method Time Complexity?

NOTE: Please, check my comments at this method.

*~~To Be Continue ...~~*
