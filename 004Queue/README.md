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
 - Web Servers: They get many requests, so they put each request in a Queue and then start processing from the first received request and ... .

&nbsp;

&nbsp;
**Queue Operations?**
We will add these operations into our Custom `Queue<T>`
|Operation|Time Complexity|
|--|:--:|
|Enqueue|?|
|Dequeue|?|
|Peek|?|
|IsEmpty|?|
|IsFull|?|

![notice-icon-7](https://user-images.githubusercontent.com/25789969/135717888-486318b4-7b6b-41ee-af24-bbeb181bb032.png) If you are student and try to learn Data Structure, Please follow each step one by one. In each step, do not look at my code unless you solve it first. It is not important how long it takes to solve it. I put each step inside `#region` blocks, so you can easily collapse all then only expand the one you solved. I did this in both XyzDataStracture & XyzUnitTests projects.

For this exercise, please follow the below steps. 
