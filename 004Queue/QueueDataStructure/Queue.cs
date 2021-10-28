using System;

namespace QueueDataStructure
{
    public class Queue<T>
    {
        #region [STEP 1]
        private readonly T[] _items; 
        private int _first;
        private int _last;  // Added in Step 4 - Circular Array

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
            
            // _items[Count] = item; // Added in STEP 2 - But commented in STEP 4 to add new logic.

            _items[_last++] = item; 
            _last %= _items.Length; // Added in Step 4 - Circular Array

            Count++;
            return this;
        }

        public bool IsFull()
            => Count >= _items.Length;
        #endregion

        #region [STEP 3]
        public T Dequeue()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Queue is empty!");

            //var item = _items[_first++]; // Added in Step 3 - But commented in STEP 4 to add new logic.
            //_items[_first++] = default; // Added in Step 3 - But commented in STEP 4 to add new logic.

            var item = _items[_first];
            _items[_first++] = default;

            _first %= _items.Length; // Added in Step 4 - Circular Array

            Count--;
            return item;
        } 

        public bool IsEmpty() 
            => Count <= 0;
        #endregion

        #region [Step 4]
            // We Added two private pointer fields to class to support Circular Array:
            //      private int _first; 
            //      private int _last;  
            // Then we changed our Enqueue & Dequeue methods accordingly.
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
