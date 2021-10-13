using System;
using StackDataStructure;
using Xunit;

namespace StackUnitTests
{
    public class StackTests
    {
        #region [Tests for STEP 1]
        [Fact]
        public void Push_EmptyStack_ItemPlacedAtFirstIndex()
        {
            // Arrange
            var totalItem = 1;
            var firstItemIndex = 0;
            var firstItem = 10;
            var stack = new Stack<int>();

            // Act
            stack.Push(firstItem);

            // Assert
            Assert.Equal(totalItem, stack.Count);
            Assert.Equal(firstItem, stack.Items[firstItemIndex]);
        }

        [Fact]
        public void Push_PushItemsMoreThanArrayLength_TenMoreRoomAddToArray()
        {
            // Arrange
            var totalItem = 6;
            var lastItemItemIndex = 5;
            var expectedNewArrayLength = 10;
            var sixthItem = 60;
            var fifthItem = 50;
            var stack = new Stack<int?>();

            // Act
            expectedNewArrayLength += stack.Items.Length;
            stack.Push(10).Push(20).Push(30).Push(40).Push(fifthItem).Push(sixthItem);

            // Assert
            Assert.Equal(totalItem, stack.Count);
            Assert.Equal(sixthItem, stack.Items[lastItemItemIndex]);
            Assert.Equal(fifthItem, stack.Items[lastItemItemIndex-1]);
            Assert.Null(stack.Items[lastItemItemIndex+1]);
            Assert.Equal(expectedNewArrayLength, stack.Items.Length);
        }

        [Fact]
        public void Push_SecondItem_ItemPlacedAtSecondIndex()
        {
            // Arrange
            var totalItem = 2;
            var firstItemIndex = 0;
            var secondItemIndex = 1;
            var firstItem = 10;
            var secondItem = 20;
            var stack = new Stack<int>();

            // Act
            stack.Push(firstItem).Push(secondItem);

            // Assert
            Assert.Equal(totalItem, stack.Count);
            Assert.Equal(firstItem, stack.Items[firstItemIndex]);
            Assert.Equal(secondItem, stack.Items[secondItemIndex]);
        }
        #endregion

        #region [Tests for STEP 2]
        [Fact]
        public void Peek_StackNotEmpty_ReturnLastInsertedButDoNotPopIt()
        {
            // Arrange
            var totalItems = 2;
            var lastItem = 20;
            var stack = new Stack<int>();

            // Act
            stack.Push(10).Push(lastItem);
            var item = stack.Peek();

            // Assert
            Assert.Equal(lastItem, item);
            Assert.Equal(lastItem, stack.Peek());
            Assert.Equal(totalItems, stack.Count);
        }

        [Fact]
        public void Peek_StackIsEmpty_ThrowNullReferenceException()
        {
            // Arrange
            var stack = new Stack<int>();

            // Act

            // Assert
            Assert.Throws<NullReferenceException>(() => stack.Peek());
        }
        #endregion
    }
}
