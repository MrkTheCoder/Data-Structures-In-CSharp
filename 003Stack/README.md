# Stack\<T\>
We will write a generic `Stack<T>` class step by step. But before that, If you do not know what is a `Stackt` is, please read my explanation. (Otherwise, feel free to jump to the 1st step) 

&nbsp;

&nbsp;
**What is a `Stack`?**

The best way to explain what is stack are and how it works, is to use "Stack of Books" example.  Let's think of a stack of books, with each book kept on top of each other. You can view or remove the top most book, but you cannot do the same for the rest of books, unless you reach to them by removing top most book then do the same thing for next top most and ... until you reach to the desire book. 

Also, this example teach us a new concept too. In a stack, the last object that came in, is the first one that can go out. Think about stack of books again. The last book you put at top, it is the first book that you can remove. This action represent the Last In, First Out concept or in short LIFO concept.

&nbsp;

&nbsp;
**Structure of `Stack`?**

`Stack` internally use `Array` or `LinkedList` to store its objects. In fact `Stack` is like a wrapper for `Array` or `LinkedList` to change the way they store or return objects. 
We will use simple array in this practice to create our personal Stack class.

&nbsp;

&nbsp;
**Usage of `Stack`?**

- Implement the undo feature.
- Build compilers (eg Syntax checking)
- Evaluate expressions (eg 1 + 2 * 3)
- Build navigation (eg forward/back)

Personally, I used the last item in the above list in my apps a lot. Like when I am building "Wizard Pages". Do you remember them when installing an app!? Each page came in, and you can use `Next >` or `< Back` button to navigate between them.


![notice-icon-7](https://user-images.githubusercontent.com/25789969/135717888-486318b4-7b6b-41ee-af24-bbeb181bb032.png) If you are student and try to learn Data Structure, Please follow each step one by one. In each step, do not look at my code unless you solve it first. It is not important how long it takes to solve it. I put each step inside `#region` blocks, so you can easily collapse all then only expand the one you solved. I did this in both XyzDataStracture & XyzUnitTests projects.

For this exercise, please follow the below steps. 

## 1. Build `Stack<T>` class
![Gear_Config](https://user-images.githubusercontent.com/25789969/136387498-f7f72a2b-7516-4c1a-a6bf-f9985d331300.png) Create new `Stack<T>` class file with these Conditions:
- Class members:
  - `private` field `Items` of type `T?[]` to store `Stack` items in it.
  - `public` property `Count` of type `int`, it keeps track of total items in `Stack`.

![notice-icon-7](https://user-images.githubusercontent.com/25789969/135717888-486318b4-7b6b-41ee-af24-bbeb181bb032.png) Since in this practice we are using `int[]` array for `Stack` class and there are no confusing algorithms exist like `LinkedList`, I defined `int[]` array as private. Which it should be! Therefore, instead of checking our internal class array directly, we will be checking class behavior after actions. This is right way to write Unite Tests for any class.

## 2. Add `Push` method:
`Push` method will add a new item to the top of our `Stack`.
 
![Gear_Config](https://user-images.githubusercontent.com/25789969/136387498-f7f72a2b-7516-4c1a-a6bf-f9985d331300.png) 
Define `Push` method with:
   - **1 Parameter**: of type T?. It will be added to the top of `Stack`.
   - **Return**: `void` or make it **Fluent Interface** support.

![Light](https://user-images.githubusercontent.com/25789969/136387819-e8790a55-7543-421f-bc1d-dae492b2b0ec.png): Don't forget about `Count` property.

![Light](https://user-images.githubusercontent.com/25789969/136387819-e8790a55-7543-421f-bc1d-dae492b2b0ec.png): Don't forget to expand array when it needed.

Then follow these steps:
   1. Make this method ready to add new item into the `Stack`.
   2. Write *UnitTest* to make sure it is working properly.
   3. What is the method Time Complexity?


## 3. Add `Peek` method:
`Peek` method will return the top item in `Stack` **without** remove it.
 
![Gear_Config](https://user-images.githubusercontent.com/25789969/136387498-f7f72a2b-7516-4c1a-a6bf-f9985d331300.png) 
Define `Peek` method with:
   - **No Parameter**..
   - **Return**: type of `T?`.

![Light](https://user-images.githubusercontent.com/25789969/136387819-e8790a55-7543-421f-bc1d-dae492b2b0ec.png): Watch for `Stack` to be not empty.

Then follow these steps:
   1. Make this method ready.
   2. Write *UnitTest* to make sure it is working properly.
   3. What is the method Time Complexity? 


## 4. Add `Pop` method:
`Pop` method will return the top item in `Stack` and **remove** it too.
 
![Gear_Config](https://user-images.githubusercontent.com/25789969/136387498-f7f72a2b-7516-4c1a-a6bf-f9985d331300.png) 
Define `Pop` method with:
   - **No Parameter**..
   - **Return**: type of `T?`.

![Light](https://user-images.githubusercontent.com/25789969/136387819-e8790a55-7543-421f-bc1d-dae492b2b0ec.png): Watch for `Stack` to be not empty.

![Light](https://user-images.githubusercontent.com/25789969/136387819-e8790a55-7543-421f-bc1d-dae492b2b0ec.png): Watch for total items in `Stack`.

Then follow these steps:
   1. Make this method ready.
   2. Write *UnitTest* to make sure it is working properly.
   3. What is the method Time Complexity? 

## 5. Override `ToString` method:
Override `ToString` method to return stack in this format: `[x, y, z]`.
 
Then follow these steps:
   1. Make this method ready.
   2. Write *UnitTest* to make sure it is working properly.

