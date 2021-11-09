# Queue\<T\>
We will write a generic `Queue<T>` class step by step. But before that, If you do not know what is a `Queue` is, please read my explanation. (Otherwise, feel free to jump to the 1st step) 

&nbsp;

&nbsp;
**What is a `Queue`?**

Think of a supermarket customer queue in one of the counters. First person came in and stand in the front of the line, then others join in to the back of the line and when counter become open, they start leaving from the front of the line. Queue's works like that. This action represents the **First In, First Out** concept or in short **FIFO**.

&nbsp;

&nbsp;
**Structure of `Queue`?**

`Queue` just like `Stack` internally use `Array` or `LinkedList` to store its objects. For this practice, We will use simple array in this practice to create our personal `Queue` class.

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
  - `private` field `_first` of type `int` to act as a pointer to store first item index in the `array`.  As you know, in Queue's, first members are the first one's that leave.
 - `private` field `_rear` of type `int` to act as a pointer to store last free index in the `array`.  As you know, in Queue's, new members go to the back of line, but they leave it from the front. So we need to know position of both side.
  - `public` property `Count` of type `int`, it keeps track of total items in `Queue`.
  - `override ToString()` method to show `Queue` items in this format. `[item1, item2, item3, item4, item5]`.

![notice-icon-7](https://user-images.githubusercontent.com/25789969/135717888-486318b4-7b6b-41ee-af24-bbeb181bb032.png) We will add another private field to this class in STEP 4, so if you go ahead and look at STEP 1 region, you may saw it. Please ignore it for now!

## 2. Add `Enqueue` method:
`Enqueue` method will add a new item to the `Queue`.
 
![Gear_Config](https://user-images.githubusercontent.com/25789969/136387498-f7f72a2b-7516-4c1a-a6bf-f9985d331300.png) 
Define `Enqueue` method with:
   - **1 Parameter**: of type T. It will be added to the `Queue`.
   - **Return**: `void` or make it **Fluent Interface** support.

![Light](https://user-images.githubusercontent.com/25789969/136387819-e8790a55-7543-421f-bc1d-dae492b2b0ec.png): Don't forget about `_rear` property. Why!? Think about it...

![Light](https://user-images.githubusercontent.com/25789969/136387819-e8790a55-7543-421f-bc1d-dae492b2b0ec.png): Don't forget about `Count` property.

![Light](https://user-images.githubusercontent.com/25789969/136387819-e8790a55-7543-421f-bc1d-dae492b2b0ec.png): Don't forget to check if Queue become full. Throw an exception if it was full. What property we should check to see if queue is full!?  (You will have to add `IsFull()` method too)

Then follow these steps:
   1. Make this method ready to add new item into the `Queue`.
   2. Write *UnitTest* to make sure it is working properly.
   3. What is the method Time Complexity?

![Light](https://user-images.githubusercontent.com/25789969/136387819-e8790a55-7543-421f-bc1d-dae492b2b0ec.png): Don't check my code yet! There is a logical problem with this method that we will discuss it in the STEP 4.

## 3. Add `Dequeue` method:
`Dequeue` method will return the first item in `Queue` and then remove it.
 
![Gear_Config](https://user-images.githubusercontent.com/25789969/136387498-f7f72a2b-7516-4c1a-a6bf-f9985d331300.png) 
Define `Dequeue` method with:
   - **No Parameter**.
   - **Return**: type of `T?`.

![Light](https://user-images.githubusercontent.com/25789969/136387819-e8790a55-7543-421f-bc1d-dae492b2b0ec.png): Watch for `Queue` to be not empty. If it was, throw an Exception. (You will have to add `IsEmpty()` method too)

![Light](https://user-images.githubusercontent.com/25789969/136387819-e8790a55-7543-421f-bc1d-dae492b2b0ec.png): Remember! Items must return from start of the `Queue`! So, do not forget about `_first` property! and to clear it, fill its place with `default` value of type T.

![Light](https://user-images.githubusercontent.com/25789969/136387819-e8790a55-7543-421f-bc1d-dae492b2b0ec.png): Don't forget about `Count` property.

Then follow these steps:
   1. Make this method ready.
   2. Write *UnitTest* to make sure it is working properly.
   3. What is the method Time Complexity? 

![Light](https://user-images.githubusercontent.com/25789969/136387819-e8790a55-7543-421f-bc1d-dae492b2b0ec.png): Don't check my code yet! There is a logical problem with this method that we will discuss it in the STEP 4.

## 4. Circular Array:
Okay! Let's examine our Queue class until now. Our codes in STEP 2 & 3 have these logics:

    #region [STEP 2]
    public Queue<T> Enqueue(T item)
    {
        if (IsFull())
            throw new InvalidOperationException("Queue is full!");
        
        _items[_rear++] = item; 

        Count++;
        return this;
    }
    
    public bool IsFull()
    {
        return _rear >= _items.Length;
    }
    
    #endregion
    
    #region [STEP 3]
    public T Dequeue()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Queue is empty!");
    
        var item = _items[_first++];
        _items[_first++] = default; 
    
        Count--;
        return item;
    } 
    
    public bool IsEmpty() 
        => Count <= 0;
    #endregion


Now, for example, we are inserting 3 integer number in our queue:

    var queue = new Queue<int>();
    queue.Enqueue(10).Enqueue(20).Enqueue(30);
    Console.WriteLine(queue); 
Output will be:
`[10, 20, 30, 0, 0]`
 
Okay! Let's assume we are getting 2 first numbers from our queue:

    Console.WriteLine(queue.Dequeue()); 
    Console.WriteLine(queue.Dequeue()); 
    Console.WriteLine(queue);

Output:
`10`
`20`
`[0, 0, 30, 0, 0]`

Now, both items in begging of or `queue` or better say in `array` are removed. Let's add two more new numbers:

    queue.Enqueue(40).Enqueue(50);
    Console.WriteLine(queue); 

Output will be:
`[0, 0, 30, 40, 50]`

Okay! What happens if we try to add `60` to the `queue`!? In `Enqueue()` method, We are checking `_rear` pointer to be less than,  `array.Length` otherwise we throw an exception. So if we try to add another number into the queue:

    queue.Enqueue(60);

We will get our custom exception. Right!?
But wait! We have **two empty room** at index 0 & 1! Wasn't it nice to be able to fill our Queue with 5 items!? 

At our `Enqueue(T item)` method, and this line `_items[_rear++] = item;` we increase `_rear` pointer by one, so when we want to add `50` to the queue, `_rear` was 4, and after we add `50`, it becomes 5, which it is outside of array index. (Remember our array have fixed length of 5)  So to add next number in index 0, our desire index for `_rear` is 0 and the next number (70) is index 1 & so on (if the rest were empty too!) Let's show above calculation in a table:

| item | _rear | Desire Index |
|--|:--:|:--:|
| 50 |4| 4 |
| 60 |5| 0 |
| 70 |6| 1 |
| 80 |7| 2 |
| 90 |8| 3 |
| 100 |9| 4 |
| 110 |10| 0 |

Check the relationship between each rows of `_rear` & `Desire Index` column! Do you see any relation here!? The `Desire Index` numbers are remainder of division by 5. So `_rear % array.Length` will give us the right answer.  In this new formula, it gives us numbers from 0 to 4 and repeat it again.

-------
So follow these steps:
   1. Add new formula to the 'Enqueue()' & 'Dequeue()' methods.
   2. Re-run previous *UnitTest* and write new ones against new formula. 

## 5. Add `Peek` method:
`Peek` method will return the first item in `Queue` **without** remove it.
 
![Gear_Config](https://user-images.githubusercontent.com/25789969/136387498-f7f72a2b-7516-4c1a-a6bf-f9985d331300.png) 
Define `Dequeue` method with:
   - **No Parameter**.
   - **Return**: type of `T?`.

![Light](https://user-images.githubusercontent.com/25789969/136387819-e8790a55-7543-421f-bc1d-dae492b2b0ec.png): Watch for `Queue` to be not empty. If it was, throw an Exception.

Then follow these steps:
   1. Make this method ready.
   2. Write *UnitTest* to make sure it is working properly.
   3. What is the method Time Complexity? 


&nbsp;

&nbsp;
**Queue Operations and Time Complexity?**

Time complexity of each `Queue<T>` operation are:
|Operation|Description|Time Complexity|
|--|--|:--:|
|Enqueue|Add an item to the queue.|O(1)|
|Dequeue|Return and remove first item in queue.|O(1)|
|Peek|Return first item in queue.|O(1)|
|IsEmpty|Return `true` if queue is empty.|O(1)|
|IsFull|Return `true` if queue is full|O(1)|

## Extra practices:

Here are some ideas:

-   **Reversing Queue**: At ConsoleApp write a  `void Reverse(Queue<int> queue)`  method to get an integer queue and reverse it. So if we give it a `queue` of `[10, 20, 30]` It must change `queue` to `[30, 20, 10]`. You're only allowing to use these 3 operations of our `Queue` class:
    - `Enqueue`.
    - `Dequeue`.
    - `IsEmpty`.
-   **StackQueue**: Create a new `Queue` class that will only use `Stack` to store and return `int` items.
    - **Hint**: Use two different `Stack` fields for `Enqueue` and `Dequeue` purposes.
-  **Priority Queues:** Create a `PriorityQueue` class that accept integer numbers and store them in Ascending sort. *Example*: We enqueues these numbers: `[4, 5, 3, 2]` at first `Dequeue`, we should get `2` if we `Enqueue(1)`, then `Dequeue`, we should get `1`. (*then: 3, 4, 5*)
-  **Queue with Linked List**: Create a `Queue` class and use `LinkedList` instead of `Array` and add all above operations to it.
- **ReverseK**:   At ConsoleApp write a `void ReverseK(Queue<int> queue, int k)` method and it should reverse `K`'th first members of `Queue`. *Example*: `[10, 20, 30, 40, 50]` and if `k = 3` then `[30, 20, 10, 40, 50]`.
   - **Hint**: Only use one `Stack` and no new `Queue` variable needed!
- **Stack with Queue**: Create a `Stack` class with two queues. Add all regular Stack operations to it.

Happy Codding!

M. Reza Kangani TheCoder
