using System;

namespace QueueDataStructure
{
    public class Queue<T>
    {
        #region [STEP 1]
        private readonly T[] _items; 
        private int _first;
        private int _rear;  

        public int Count { get; private set; }

        public Queue()
        {
            _items = new T[5];
        }

        public override string ToString()
        {
            return $"[{string.Join(", ", _items)}]";
        }
        #endregion


        #region [STEP 2]
        public Queue<T> Enqueue(T item)
        {
            if (IsFull())
                throw new InvalidOperationException("Queue is full!");
            
            _items[_rear++] = item; // Added in STEP 2 
            _rear %= _items.Length; // Added in Step 4 - To support "Circular Array"

            Count++;
            return this;
        }

        public bool IsFull()
        {
            // return _rear >= _items.Length; // Added in STEP 2 | Commented in STEP 4
            return Count >= _items.Length; // Added in STEP 4
        }

        #endregion

        #region [STEP 3]
        public T Dequeue()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Queue is empty!");

            var item = _items[_first]; // Added in Step 3 
            _items[_first++] = default;  // Added in Step 3 

            _first %= _items.Length; // Added in Step 4 - to support "Circular Array"

            Count--;
            return item;
        } 

        public bool IsEmpty() 
            => Count <= 0;
        #endregion

        #region [Step 4]
            // Add Circular Array logic into both:
            //      Enqueue (STEP 2) method.
            //      Dequeue (STEP 3) method.
        #endregion

        #region [Step 5]
        public T Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Queue is full!");

            return _items[_first];
        }
        #endregion
    }
}
