using System;
using System.Collections;
using StackDataStructure;
using Xunit;

namespace StackUnitTests
{
    public class StackTests
    {
        #region [Tests for STEP 2]
        [Fact]
        public void Push_AddFirstItem_CountChanged()
        {
            // Arrange
            var totalItem = 1;
            var firstItem = 10;
            var stack = new Stack<int>();

            // Act
            var preCount = stack.Count;
            stack.Push(firstItem);

            // Assert
            Assert.Equal(0, preCount);
            Assert.Equal(totalItem, stack.Count);
        }

        [Fact]
        public void Push_PushItemsMoreThanArrayLength_ArrayExpanded()
        {
            // Arrange
            var totalItem = 6;
            var sixthItem = 60;
            var stack = new Stack<int>();

            // Act
            stack.Push(10).Push(20).Push(30).Push(40).Push(50).Push(sixthItem);

            // Assert
            Assert.Equal(totalItem, stack.Count);
        }
        #endregion

        #region [Tests for STEP 3]
        [Fact]
        public void Peek_PeekingStack_LastItemReturnWithoutRemoveItFromStack()
        {
            // Arrange
            var lastItem = 20;
            var stack = new Stack<int>();

            // Act
            stack.Push(10).Push(lastItem);
            var countBeforePeek = stack.Count;
            var item = stack.Peek();

            // Assert
            Assert.Equal(lastItem, item);
            Assert.Equal(countBeforePeek, stack.Count);
            Assert.Equal(lastItem, stack.Peek());

        }

        [Fact]
        public void Peek_PeekingOnEmptyStack_ThrowNullReferenceException()
        {
            // Arrange
            var stack = new Stack<int>();

            // Act

            // Assert
            Assert.Throws<NullReferenceException>(() => stack.Peek());
        }
        #endregion

        #region [Tests for STEP 4]

        [Fact]
        public void Pop_PoppingLastItem_ReturnLastItemAndRemoveItFromStack()
        {
            // Arrange
            var lastItem = 30;
            var stack = new Stack<int>();
            stack.Push(10).Push(20).Push(lastItem);

            // Act
            var peakingLastItem = stack.Peek();
            var countBeforePop = stack.Count;
            var poppedItem = stack.Pop();

            // Assert
            Assert.Equal(peakingLastItem, poppedItem);
            Assert.Equal(lastItem, poppedItem);

            Assert.Equal(countBeforePop-1, stack.Count);
            Assert.NotEqual(lastItem, stack.Peek());
        }

        [Fact]
        public void Pop_AfterPopAnItem_PeekShowItemBeforeIt()
        {
            // Arrange
            var middleItem = 30;
            var stack = new Stack<int>();
            stack.Push(10).Push(middleItem).Push(30);

            // Act
            stack.Pop();
            var currentTopStackItemAfterAPop = stack.Peek();

            // Assert
            Assert.Equal(middleItem, currentTopStackItemAfterAPop);
        }

        [Fact]
        public void Pop_OnEmptyStack_ThrowInvalidOperationException()
        {
            // Arrange
            var stack = new Stack<int>();

            // Act

            // Assert
            Assert.Throws<InvalidOperationException>(() => stack.Pop());
        }
        #endregion
    }
}
