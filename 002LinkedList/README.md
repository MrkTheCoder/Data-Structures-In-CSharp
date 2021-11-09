# LinkedList\<T\>
We will write a generic `LinkedList<T>` class step by step. But before that, If you do not know what is a linked list is, please read my explanation. (Otherwise, feel free to jump to the 1st step) 

&nbsp;

&nbsp;
**What is a `LinkedList`?**

We are using `LinkedList` to store a list of items in sequence. Unlike Arrays, `LinkedList`s can grow or shrink automatically.

&nbsp;

&nbsp;
**Structure of `LinkedList`?**

Linked Lists store each inserted item in a new object, and then it creates a link between these objects.  In this way, each object knows what object is next to it. We call these objects `Node`. Each `Node` at least own 2 pieces of data: 
- `Value` Property: our `item` will be store in this property. So `Value` type should be the same as our `item` type.
- `Next` Property: Its type is `Node` and Its job is to store address of the next `Node`.

&nbsp;

&nbsp;
**How Linked Lists works?**

When we are inserting first `item` into the list, a new `Node` object will store the `item` in its `Value` property and since it is the only node in the list, its `Next` property stay null. Let's use a practical example and insert integer 10 in our `LinkedList` as a first item. Our item will be stored like this in first `Node` of `LinkedList`:

|Nodes:|node1|
|--|--|
|Value|10|
|Next|Null|

![notice-icon-7](https://user-images.githubusercontent.com/25789969/135717888-486318b4-7b6b-41ee-af24-bbeb181bb032.png) I put index for first node (node1), I shouldn't do that. I just did it, so for next examples you know which node will store in the `Next` row. In code - which soon we will write - we will only store next `Node` address inside the `Next` property of previous `Node`. (Which in above example, I mean `node1.Next`)

Now, when the next `item` inserted, Another new `Node` will be created and above process will be repeated except a new thing happen. The previous `Node` will store the new `Node` address inside its `Next` property. (`node1.Next = node2`) This is the way that each `Node` know about its next `Node`.  Let's continue our previous example. Now we will insert integer 20 in our `LinkedList` as second item:

|Nodes:|node1|node2|
|--|--|--|
|Value|10|20|
|Next|**node2**|null|

Now, `node1.Next` have address of `node2`. Then for the 3rd item, integer 30, `LinkedList` will be look like this:
|Nodes:|node1|node2|node3|
|--|--|--|--|
|Value|10|20|30|
|Next|**node2**|**node3**|null|

So we will have equations like these:

    node1.Next = node2;

    node2.Next = node3;

We can simplify above 2 equations to become:

    node1.Next.Next = node3;

Therefore, we can get any of nodes via `node1`, by moving forward and step by step through each `node.Next` until we reach to the last node. (`node3`)

We can simplify above tables and write something like this too:

10 -> 20 -> 30

There are 2 special nodes in each `LinkedList`:
- Head: We call the first node `Head`.
- Tail: the last node called `Tail`. 

So with these new names, the last table should be look like this:
|Nodes:|Head|node2|Tail|
|--|--|--|--|
|Value|10|20|30|
|Next|**node2**|**Tail**|null|


Also, We have 2 kinds of `LinkedList`:
-  **Singly**: each node only know about its next node address.
- **Doubly**: each node knows both next and previous nodes addresses.

We will create **Singly** type of `LinkedList` at the start and when you become familiar with it and know how it works then you can change it to support **Doubly** type too. 



&nbsp;

&nbsp;
**LinkedList Operations?**

We will add these operations into our `LinkedList<T>`
|Operation|Description|Time Complexity|
|--|--|:--:|
|AddLast|Add an item to the end of `LinkedList`.|?|
|AddFirst|Add an item to the first position of `LinkedList`.|?|
|IndexOf|Return index of an item in `LinkedList`, or -1 for not exists.|?|
|Contain|Return `true` if an item exists, otherwise `false`.|?|
|RemoveFirst|Remove first item of `LinkedList`.|?|
|RemoveLast|Remove last item of `LinkedList`.|?|
|ToArray|Convert `LinkedList` to an `Array`.|?|
|Reverse|Reverse all items in `LinkedList`.|?|
|GetKthNodeFromTheEnd|Return `K`'th item from the end of `LinkedList`.|?|


![notice-icon-7](https://user-images.githubusercontent.com/25789969/135717888-486318b4-7b6b-41ee-af24-bbeb181bb032.png) If you are student and try to learn Data Structure, Please follow each step one by one. In each step, do not look at my code unless you solve it first. It is not important how long it takes to solve it. I put each step inside `#region` blocks, so you can easily collapse all then only expand the one you solved. I did this in both XyzDataStracture & XyzUnitTests projects.

For this exercise, please follow the below steps. 

## 1. Build `LinkedList<T>` & `Node<T>` classes
![Gear_Config](https://user-images.githubusercontent.com/25789969/136387498-f7f72a2b-7516-4c1a-a6bf-f9985d331300.png) Create new `LinkedList<T>` class file with these Conditions:
- Class members:
  - `public` class `Node<T>` inside it with these members:
    - A `public` property of type `T` to store value.
    - A `public` property of type `Node<T>` to store next node address.
    - A Constructor with 1 Parameter: of type T to set on Node value property.
  - `public` property `Head` of type `Node<T>` to store head of list address.
  - `public` property `Tail` of type `Node<T>` to store tail of list address.
  - A `public` property of type `int` to count list items.

![Stop_Wrong_Attention](https://user-images.githubusercontent.com/25789969/137124180-e3654261-1fe6-487c-8dd8-de1970c41ae4.png) 
We shouldn't define `Head`/`Tail` and `Node` class as public members of `LinkedList`![Stop_Wrong_Attention](https://user-images.githubusercontent.com/25789969/137124180-e3654261-1fe6-487c-8dd8-de1970c41ae4.png), because they are implementations details of `LinkedList` class, and they should not accessible from outside of this class. But just for unit test's purpose and examine them in more details, I did that. 

![notice-icon-7](https://user-images.githubusercontent.com/25789969/135717888-486318b4-7b6b-41ee-af24-bbeb181bb032.png) In real-world coding,  we should not change a `private` member to a `public`, so we can write some Unit tests against them. It is wrong! Instead, We should test them indirect via class behavior.

## 2. Add `AddLast` method:
`AddLast(T item)` method will add a new item to the end of  `LinkedList`.
 
![Gear_Config](https://user-images.githubusercontent.com/25789969/136387498-f7f72a2b-7516-4c1a-a6bf-f9985d331300.png) 
Define `AddLast` method with:
   - **1 Parameter**: of type T. It will be added to the end of `LinkedList`.
   - **Return**: `void` or, if you like to make it **Fluent Interface**, set return type as `LinkedList<T>`.

![Light](https://user-images.githubusercontent.com/25789969/136387819-e8790a55-7543-421f-bc1d-dae492b2b0ec.png): Don't forget about `Count` property.

Then follow these steps:
   1. Make this method ready to add new item into the `LinkedList`.
   2. Write *UnitTest* to make sure it is working properly.
   3. What is the method Time Complexity?

I add some comments in unit test methods related to this method to explain how `LinkedList` works. Check `LinkedListUnitTests` class, region "[Tests for STEP 2]", after you wrote it yourself.

## 3. Add `AddFirst` method:
`AddFirst(T item)` method will add a new item to the beginning of  `LinkedList`. 

  ![Gear_Config](https://user-images.githubusercontent.com/25789969/136387498-f7f72a2b-7516-4c1a-a6bf-f9985d331300.png) Define `AddFirst` method with:
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

![Gear_Config_v2](https://user-images.githubusercontent.com/25789969/136388347-9a594912-d0c5-47a7-8e78-d99e990bdf03.png)  Define `RemoveLast` method with:
   - **No Parameter**.
   - **Return**: `void` or if you like to make it **Fluent Interface**, set return type as `LinkedList<T>`.

Then follow these steps:
   1. Write this method.
   2. Write *UnitTest* to make sure it is working properly.
   3. What is the method Time Complexity?

**Note**: Please check my comments.

  ![Light](https://user-images.githubusercontent.com/25789969/136387819-e8790a55-7543-421f-bc1d-dae492b2b0ec.png) [*Do not read my tip If you wanna do it yourself without any help*] Just a small hint: We should loop from first to the last node and while we do this, remember the previous node so when we hit the `Tail`, we have its previous node.

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

![Light](https://user-images.githubusercontent.com/25789969/136387819-e8790a55-7543-421f-bc1d-dae492b2b0ec.png) [*Do not read my tip If you wanna do it yourself without any help*] Let assume we have this `LinkedList` Items:

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

![Light](https://user-images.githubusercontent.com/25789969/136387819-e8790a55-7543-421f-bc1d-dae492b2b0ec.png) [*Do not read my tip If you wanna do it yourself without any help*] Let assume we have this `LinkedList` Items:

10 -> 20 -> 30 -> 40

We want 3rd node from the end. (which it is 20) To solve this we can use 2 pointers, one get away 2 nodes from the first one (3rd - 1 = 2) :

10 -> 20 -> 30 -> 40

\*&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;\*

Then we move both to the `Next` nodes:

10 -> 20 -> 30 -> 40

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;\*&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;\*

If the last node reach to the `Tail`, then the first node will be at the right position.

&nbsp;

&nbsp;
**LinkedList Operations and Time Complexity?**

`LinkedList` operations have these time complexies:
|Operation|Description|Time Complexity|
|--|--|:--:|
|AddLast|Add an item to the end of `LinkedList`.|O(1)|
|AddFirst|Add an item to the first position of `LinkedList`.|O(1)|
|IndexOf|Return index of an item in `LinkedList`, or -1 for not exists.|O(n)|
|Contain|Return `true` if an item exists, otherwise `false`.|O(n)|
|RemoveFirst|Remove first item of `LinkedList`.|O(1)|
|RemoveLast|Remove last item of `LinkedList`.|O(n)|
|ToArray|Convert `LinkedList` to an `Array`.|O(n)|
|Reverse|Reverse all items in `LinkedList`.|O(n)|
|GetKthNodeFromTheEnd|Return `K`'th item from the end of `LinkedList`.|O(n)|


## Extra practices:

We are done here! But you can continue to add extra features to it. Here are some ideas:

- Write `AddAfter(T item, T newItem)` method: `newItem` of type `T` will be added after `item`, if it found in the list.
- Write `AddBefore(T item, T newItem)` method: `newItem` of type `T` will be added after `item`, if it found in the list.
- Add `Before` property of type `Node` to the `Node` class members and store address of both `Next` and `Before` nodes of each item in the `LinkedList`.
  - Now, try to see which methods can use this new `Before` property to make their logic easier.
