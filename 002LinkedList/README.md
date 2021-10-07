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
`AddLast(T item)` method will add a new item to the end of  `LinkedList`. 
Define `AddLast` method with:
   - **1 Parameter**: of type T. It will be added to the end of `LinkedList`.
   - **Return**: `void` or, if you like to make it **Fluent Interface**, set return type as `LinkedList<T>`.

![Light](https://user-images.githubusercontent.com/25789969/136387819-e8790a55-7543-421f-bc1d-dae492b2b0ec.png): Don't forget about `Count` property.

Then follow these steps:
   1. Make this method ready to add new item into the `LinkedList`.
   2. Write *UnitTest* to make sure it is working properly.
   3. What is the method Time Complexity?

I add many comments not only at this method but also at Unit Tests class in region "[Tests for STEP 2]". Please check them after you wrote above method by your own.-run all *UnitTests* again.

## 3. Add `AddFirst` method:
`AddFirst(T item)` method will add a new item to the beginning of  `LinkedList`. 
Define `AddFirst` method with:
   - **1 Parameter**: of type T. It will be added to the beginning of `LinkedList`.
   - **Return**: `void` or if you like to make it **Fluent Interface**, set return type as `LinkedList<T>`.

Then follow these steps:
   1. Make this method ready to add new item into the `LinkedList`.
   2. Write *UnitTest* to make sure it is working properly.
   3. What is the method Time Complexity?

## 4. Add `IndexOf` method:
`IndexOf(T item)` method will compare each `Node.Value` property of `LinkedList` with inserted `item`, and if it found a match, then it will return the index of that node. Otherwise -1. As you know, `LinkedList` does not work with index like Array's do. So! Find a way! 😁

![Gear_Config](https://user-images.githubusercontent.com/25789969/136387498-f7f72a2b-7516-4c1a-a6bf-f9985d331300.png) Define `IndexOf` method with:
   - **1 Parameter**: of type T. It will be compared with each `Node.Value` in the `LinkedList`.
   - **Return**: `int` type. Index of node based on its distance from Head.(Zero Based) or -1, for not exist items.

Then follow these steps:
   1. Write this method.
   2. Write *UnitTest* to make sure it is working properly.
   3. What is the method Time Complexity?

**NOTE:** Please, check my comments at this method.

## 5. Add `Contain` method:
Add `Contain(T item)` method to check the `LinkedList` to see if inserted `item` exits or not. 

![Gear_Config](https://user-images.githubusercontent.com/25789969/136387498-f7f72a2b-7516-4c1a-a6bf-f9985d331300.png) Define `Contain` method with:
   - **1 Parameter**: of type T. It will be compared with each `Node.Value` in the `LinkedList`.
   - **Return**: `boolean` type.

Then follow these steps:
   1. Write this method.
   2. Write *UnitTest* to make sure it is working properly.
   3. What is the method Time Complexity?

![Light](https://user-images.githubusercontent.com/25789969/136387819-e8790a55-7543-421f-bc1d-dae492b2b0ec.png) Respect DRY principle! 😉 (Don't Repeat Yourself)

## 6. Add `RemoveFirst` method:
Add `RemoveFirst()` method to remove first node from the `LinkedList`. 

![Gear_Config_v2](https://user-images.githubusercontent.com/25789969/136388347-9a594912-d0c5-47a7-8e78-d99e990bdf03.png)  Define `Contain` method with:
   - **No Parameter**.
   - **Return**: `void` or if you like to make it **Fluent Interface**, set return type as `LinkedList<T>`.

Then follow these steps:
   1. Write this method.
   2. Write *UnitTest* to make sure it is working properly.
   3. What is the method Time Complexity?

## 7. Add `RemoveLast` method:
Add `RemoveLast()` method to remove last node from the `LinkedList`.  This practice really take your time. 
![Light](https://user-images.githubusercontent.com/25789969/136387819-e8790a55-7543-421f-bc1d-dae492b2b0ec.png) Just a small hint: We should loop from first to the last node and while we do this, remember the previous node so when we hit the `Tail`, we have its previous node.

![Gear_Config_v2](https://user-images.githubusercontent.com/25789969/136388347-9a594912-d0c5-47a7-8e78-d99e990bdf03.png)  Define `RemoveLast` method with:
   - **No Parameter**.
   - **Return**: `void` or if you like to make it **Fluent Interface**, set return type as `LinkedList<T>`.

Then follow these steps:
   1. Write this method.
   2. Write *UnitTest* to make sure it is working properly.
   3. What is the method Time Complexity?

**Note**: Please check my comments.

## 8. Add `ToArray` method:
Add `ToArray()` method to return `T[]` array of the `LinkedList`. 

![Gear_Config_v2](https://user-images.githubusercontent.com/25789969/136388347-9a594912-d0c5-47a7-8e78-d99e990bdf03.png)  Define `ToArray` method with:
   - **No Parameter**.
   - **Return**: `T[]`  array type.

Then follow these steps:
   1. Write this method.
   2. Write *UnitTest* to make sure it is working properly.
   3. What is the method Time Complexity?

## 9. Add `Reverse` method:
Add `Reverse()` method to reverse the `LinkedList`.  This one can take more time than step 7 took.

![Gear_Config_v2](https://user-images.githubusercontent.com/25789969/136388347-9a594912-d0c5-47a7-8e78-d99e990bdf03.png)  Define `Reverse` method with:
   - **No Parameter**.
   - **Return**: `void` or if you like to make it **Fluent Interface**, set return type as `LinkedList<T>`.

Then follow these steps:
   1. Write this method.
   2. Write *UnitTest* to make sure it is working properly.
   3. What is the method Time Complexity?

![Light](https://user-images.githubusercontent.com/25789969/136387819-e8790a55-7543-421f-bc1d-dae492b2b0ec.png) [*Do not read my tip If you wanna do it yourself without any tips*] Let assume we have this `LinkedList` Items:
10 -> 20 -> 30 -> 40
What we like to do at start is changing 2nd `node.Next` direction from 3rd node to the first node. Right!? Like this:
10 <- 20&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;30 -> 40
But if we do that, we will lose the link to the 3rd node! Therefore, We have to first save that link in a variable (Let us call it `next`), then act on reversing the direction on 2nd `Node.Next`. After we're done with 2nd Node, we have 3rd Node address in that `next` variable.  
Try to do solve this problem yourself, even if it takes days to solve! I wrote full comments in this method about how my algorithm works.

## 10. Add `GetKthNodeFromTheEnd` method:
`GetKthNodeFromTheEnd(int k)` method get k of type integer and return Kth node from the end of the `LinkedList`.  This one also is a great exercise for your brain.

![Gear_Config_v2](https://user-images.githubusercontent.com/25789969/136388347-9a594912-d0c5-47a7-8e78-d99e990bdf03.png)  Define `Reverse` method with:
   - **No Parameter**.
   - **Return**: `void` or if you like to make it **Fluent Interface**, set return type as `LinkedList<T>`.

Then follow these steps:
   1. Write this method.
   2. Write *UnitTest* to make sure it is working properly.
   3. What is the method Time Complexity?

![Light](https://user-images.githubusercontent.com/25789969/136387819-e8790a55-7543-421f-bc1d-dae492b2b0ec.png) [*Do not read my tip If you wanna do it yourself without any tips*] Let assume we have this `LinkedList` Items:
10 -> 20 -> 30 -> 40
We want 3rd node from the end. (which it is 20) To solve this we can use 2 pointers, one get away 2 nodes from the first one (3rd - 1 = 2) :
10 -> 20 -> 30 -> 40
\*&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;\*
Then we move both to the `Next` nodes:
10 -> 20 -> 30 -> 40
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;\*&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;\*
If the last node reach to the `Tail`, then the first node will be at the right position.


