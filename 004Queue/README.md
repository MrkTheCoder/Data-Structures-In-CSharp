# Queue\<T\>
We will write a generic `Queue<T>` class step by step. But before that, If you do not know what is a `Queue` is, please read my explanation. (Otherwise, feel free to jump to the 1st step) 

&nbsp;

&nbsp;
**What is a `Queue`?**

Think of a supermarket customer queue in one of the counters. First person came in and stand in the front of the line, then others join in to the back of the line and when counter become open, they start leaving from the front of the line. Queue's works like that. This action represents the **First In, First Out** concept or in short **FIFO**.

&nbsp;

&nbsp;
**Structure of `Queue`?**

`Queue` just like `Stack` internally use `Array` or `LinkedList` to store its objects. For this practice, We will use simple array in this practice to create our personal Stack class.

&nbsp;

&nbsp;
**Usage of `Queue`?**

 - Printers : They put all received printing jobs in a Queue, then start printing each job one by one.
 - Operating System: They put processes in a Queue, then start each process.
 - Web Servers: They get many requests, so they put each request in a Queue and then start processing from the first received request and ....

&nbsp;

&nbsp;
**Queue Operations?**

We will add these operations into our Custom `Queue<T>`
|Operation|Description|Time Complexity|
|--|--|:--:|
|Enqueue|Add an item to the queue.|?|
|Dequeue|Return and remove first item in queue.|?|
|Peek|Return first item in queue.|?|
|IsEmpty|Return `true` if queue is empty.|?|
|IsFull|Return `true` if queue is full|?|

![notice-icon-7](https://user-images.githubusercontent.com/25789969/135717888-486318b4-7b6b-41ee-af24-bbeb181bb032.png) If you are student and try to learn Data Structure, Please follow each step one by one. In each step, do not look at my code unless you solve it first. It is not important how long it takes to solve it. I put each step inside `#region` blocks, so you can easily collapse all then only expand the one you solved. I did this in both XyzDataStracture & XyzUnitTests projects.

For this exercise, please follow the below steps. 

## 1. Build `Queue<T>` class
![Gear_Config](https://user-images.githubusercontent.com/25789969/136387498-f7f72a2b-7516-4c1a-a6bf-f9985d331300.png) Create new `Queue<T>` class file with these Conditions:
- Class members:
  - `private` field `Items` of type `T[5]` array to store `Queue` items in it. To make it easy, array length is set to 5.
  - `private` field `_first` of type `int` to act as a pointer to store first item index in the `Queue`.  As you know, in Queue's, first members are the first one's that leave.
  - `public` property `Count` of type `int`, it keeps track of total items in `Queue`.
  - `override ToString()` method to show `Queue` items in this format. `[item1, item2, item3, item4, item5]`.

![notice-icon-7](https://user-images.githubusercontent.com/25789969/135717888-486318b4-7b6b-41ee-af24-bbeb181bb032.png) We will add another private field to this class in STEP 4, so if you go ahead and look at STEP 1 region, you may saw it. Please ignore it for now!

## 2. Add `Enqueue` method:
`Enqueue` method will add a new item to the `Queue`.
 
![Gear_Config](https://user-images.githubusercontent.com/25789969/136387498-f7f72a2b-7516-4c1a-a6bf-f9985d331300.png) 
Define `Enqueue` method with:
   - **1 Parameter**: of type T. It will be added to the `Queue`.
   - **Return**: `void` or make it **Fluent Interface** support.

![Light](https://user-images.githubusercontent.com/25789969/136387819-e8790a55-7543-421f-bc1d-dae492b2b0ec.png): Don't forget about `Count` property.

![Light](https://user-images.githubusercontent.com/25789969/136387819-e8790a55-7543-421f-bc1d-dae492b2b0ec.png): Don't forget to check if Queue become full. Throw an exception if it was full.

Then follow these steps:
   1. Make this method ready to add new item into the `Queue`.
   2. Write *UnitTest* to make sure it is working properly.
   3. What is the method Time Complexity?


## 3. Add `Dequeue` method:
`Dequeue` method will return the first item in `Queue` and then remove it.
 
![Gear_Config](https://user-images.githubusercontent.com/25789969/136387498-f7f72a2b-7516-4c1a-a6bf-f9985d331300.png) 
Define `Dequeue` method with:
   - **No Parameter**..
   - **Return**: type of `T?`.

![Light](https://user-images.githubusercontent.com/25789969/136387819-e8790a55-7543-421f-bc1d-dae492b2b0ec.png): Watch for `Stack` to be not empty. It was Throw an Exception.

![Light](https://user-images.githubusercontent.com/25789969/136387819-e8790a55-7543-421f-bc1d-dae492b2b0ec.png): Remember! Items must return from start of the `Queue`! (The first Item inserted)

Then follow these steps:
   1. Make this method ready.
   2. Write *UnitTest* to make sure it is working properly.
   3. What is the method Time Complexity? 
