using System;
using QueueDataStructure;
using Xunit;

namespace QueueUnitTests
{
    public class QueueTests
    {
        #region [Tests for STEP 1]
        [Fact]
        public void Enqueue_AddItems_ToStringReturnCorrectFormation()
        {
            // Arrange
            var outputFormat = "[10, 20, 30, 0, 0]";
            var queue = new Queue<int>();

            // Act
            queue.Enqueue(10).Enqueue(20).Enqueue(30);

            // Assert
            Assert.Equal(3, queue.Count);
            Assert.Equal(outputFormat, queue.ToString());
        }

        [Fact]
        public void Enqueue_AddItemToFullQueue_ThrowInvalidOperationException()
        {
            // Arrange
            var exceptionMessage = "Queue is full!";
            var queue = new Queue<int>();

            // Act
            queue.Enqueue(10).Enqueue(20).Enqueue(30).Enqueue(40).Enqueue(50);

            // Assert
            Assert.Equal(5, queue.Count);

            var ex = Assert.Throws<InvalidOperationException>(() => queue.Enqueue(60));
            Assert.Equal(exceptionMessage, ex.Message);
        } 
        #endregion

        #region [Tests for STEP 2]
        [Fact]
        public void Dequeue_DoOnce_ReturnFirstItemInArrayAndRemoveIt()
        {
            // Arrange
            var outputFormat = "[0, 20, 30, 0, 0]";
            var queue = new Queue<int>();
            queue.Enqueue(10).Enqueue(20).Enqueue(30);

            // Act
            var item = queue.Dequeue();

            // Assert
            Assert.Equal(2, queue.Count);
            Assert.Equal(10, item);
            Assert.Equal(outputFormat, queue.ToString());
        }

        [Fact]
        public void Dequeue_DoTwice_ReturnSecondItemInArrayAndRemoveIt()
        {
            // Arrange
            var outputFormat = "[0, 0, 30, 0, 0]";
            var queue = new Queue<int>();
            queue.Enqueue(10).Enqueue(20).Enqueue(30);

            // Act
            queue.Dequeue();
            var item = queue.Dequeue();

            // Assert
            Assert.Equal(1, queue.Count);
            Assert.Equal(20, item);
            Assert.Equal(outputFormat, queue.ToString());
        }

        [Fact]
        public void Dequeue_OnEmptyQueue_ThrowInvalidOperationException()
        {
            // Arrange
            var exceptionMessage = "Queue is empty!";
            var queue = new Queue<int>();

            // Act

            // Assert
            Assert.Equal(0, queue.Count);

            var ex = Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
            Assert.Equal(exceptionMessage, ex.Message);
        }
        #endregion

        #region [Tests for STEP 4 - Tests for Circular Array Algorithm]
        [Fact]
        public void Enqueue_AddExtraItem_ItemAddedToBeginningOfArrayWithEmptySlot()
        {
            // Arrange
            var outputFormat = "[60, 20, 30, 40, 50]";
            var queue = new Queue<int>();
            queue.Enqueue(10).Enqueue(20).Enqueue(30).Enqueue(40).Enqueue(50);

            // Act
            var item = queue.Dequeue();
            queue.Enqueue(60); // Fill Index 0 of Array with an Item  (Circular Array Algorithm) 

            // Assert
            Assert.Equal(5, queue.Count);
            Assert.Equal(10, item);
            Assert.Equal(outputFormat, queue.ToString());
        }

        [Fact]
        public void Dequeue_ReachToEndOfArrayDequeuingOnce_OneItemAtArrayBeginningShouldReturn()
        {
            // Arrange
            var outputFormat = "[0, 0, 0, 0, 0]";
            var queue = new Queue<int>();
            queue.Enqueue(10).Enqueue(20).Enqueue(30).Enqueue(40).Enqueue(50);

            // Act
            queue.Dequeue();    // Empty Index 0 of array, Then
            queue.Enqueue(60);  // Fill it with an Item  (Circular Array Algorithm) 
            queue.Dequeue();    // Empty Index 1, Then
            queue.Dequeue();    // Empty Index 2, Then
            queue.Dequeue();    // Empty Index 3, Then
            queue.Dequeue();    // Empty Index 4, Last room of Array, Then
            var item = queue.Dequeue(); // It should return value of Index 0 of Array (Circular Array Algorithm) 

            // Assert
            Assert.Equal(0, queue.Count);
            Assert.Equal(60, item);
            Assert.Equal(outputFormat, queue.ToString());
        }

        [Fact]
        public void Dequeue_ReachToEndOfArrayDequeuingTwice_TwoItemsAtArrayBeginningShouldReturn()
        {
            // Arrange
            var outputFormat = "[0, 0, 0, 0, 0]";
            var queue = new Queue<int>();
            queue.Enqueue(10).Enqueue(20).Enqueue(30).Enqueue(40).Enqueue(50);

            // Act
            queue.Dequeue();    // Empty Index 0 of array, Then
            queue.Dequeue();    // Empty Index 1, Then
            queue.Enqueue(60);  // Add new Item, (Circular Array Algorithm) 
            queue.Enqueue(70);  // Add new Item, (Circular Array Algorithm) 
            queue.Dequeue();    // Empty Index 2, Then
            queue.Dequeue();    // Empty Index 3, Then
            queue.Dequeue();    // Empty Index 4, Last room of Array, Then
            var itemIndex0 = queue.Dequeue(); // It should return value of Index 0 of Array (Circular Array Algorithm) 
            var itemIndex1 = queue.Dequeue(); // It should return value of Index 1 of Array (Circular Array Algorithm) 

            // Assert
            Assert.Equal(0, queue.Count);
            Assert.Equal(60, itemIndex0);
            Assert.Equal(70, itemIndex1);
            Assert.Equal(outputFormat, queue.ToString());
        }
        #endregion

        #region [Tests for STEP 5]
        [Fact]
        public void Peek_ItemsExists_ReturnFirstItemOfQueueWithoutRemoveIt()
        {
            // Arrange
            var outputFormat = "[10, 20, 30, 0, 0]";
            var queue = new Queue<int>();
            queue.Enqueue(10).Enqueue(20).Enqueue(30);

            // Act
            var item = queue.Peek();

            // Assert
            Assert.Equal(3, queue.Count);
            Assert.Equal(10, item);
            Assert.Equal(10, queue.Peek());
            Assert.Equal(outputFormat, queue.ToString());
        }

        [Fact]
        public void Peek_EmptyQueue_ThrowInvalidOperationException()
        {
            // Arrange
            var exceptionMessage = "Queue is empty!";
            var queue = new Queue<int>();

            // Act

            // Assert
            Assert.Equal(0, queue.Count);

            var ex = Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
            Assert.Equal(exceptionMessage, ex.Message);
        }
        #endregion
    }
}
