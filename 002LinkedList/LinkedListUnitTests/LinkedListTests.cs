using LinkedArrayDataStructure;
using Xunit;

namespace LinkedListUnitTests
{
    public class LinkedListTests
    {
        #region [Tests for STEP 2]
        [Fact]
        public void AddLast_AddFirstNode_HeadAndTailAndSizeInitialProperly()
        {
            // Arrange
            var item = 10;
            var list = new LinkedList<int>();

            // Just for fun!
            Assert.Null(list.Head);
            Assert.Null(list.Tail);
            Assert.Equal(0, list.Count);
            
            // Act
            list.AddLast(item);

            // Assert
            Assert.NotNull(list.Head);
            Assert.NotNull(list.Tail);
            Assert.Equal(1, list.Count);
            Assert.Null(list.Head.Next);
            Assert.Equal(item, list.Head.Value);
            Assert.Null(list.Tail.Next);
            Assert.Equal(item, list.Tail.Value);

            Assert.Equal(list.Head, list.Tail);
        } 
        #endregion
    }
}
