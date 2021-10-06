using LinkedListDataStructure;
using Xunit;

namespace LinkedListUnitTests
{
    public class LinkedListTests
    {
        #region [Tests for STEP 2]
        [Fact]
        public void AddLast_AddFirstNodeAtEndOfList_HeadAndTailWillPointToSameNodeAndSizeSetToOne()
        {
            // Arrange
            var totalItems = 1;
            var item = 10;
            var list = new LinkedList<int>();

            // Act
            list.AddLast(item);

            // Assert
            Assert.NotNull(list.Head);
            Assert.NotNull(list.Tail);
            Assert.Equal(totalItems, list.Count);
            
            Assert.Null(list.Head.Next);
            Assert.Equal(item, list.Head.Value);
            
            Assert.Null(list.Tail.Next);
            Assert.Equal(item, list.Tail.Value);
            
            // After first node inserted, Both Head & Tail nodes are referencing the same node.
            Assert.Equal(list.Head, list.Tail);
        } 

        [Fact]
        public void AddLast_AddSecondNodeAtEndOfList_HeadNextSetToNewNodeTailSetToLastNodeAndSizeSetToTwo()
        {
            // ========= Arrange
            var totalItems = 2;
            var item1 = 10;
            var item2 = 20;
            var list = new LinkedList<int>();

            // ========= Act
            list.AddLast(item1);
            // Remember: After first node inserted, Both Head & Tail nodes are referencing the same "node".
            //          So any modification to that "node" via any of them will be reflecting on the other 
            //          one too, Since both are referencing the same node.
            Assert.Equal(list.Head, list.Tail);
            
            // After we insert second item, second part of if condition in AddLast() method will executed.
            //      1st) It will set "Tail.Next" to the new "node". but since Head and Tail are referencing
            //           the first "node", then "Head.Next" also will be set automatically to point to the
            //           new "node" too.
            //      2nd) At the next line, we will set "Tail" to new "node". Now "Tail" and "Head" do not 
            //           point to the same "node" anymore, but "Head.Next" and "Tail" both are pointing to 
            //           the same new "node".
            list.AddLast(item2);
            // 
            // This chain of events go on when third item inserting. A third node will be created and
            // "Head.Next.Next" will set to third node via "Tail.Next". In fact the full relations
            // between "Tail" and "Head.Next from" second item to n are like this:
            // 2nd Item ===> Tail = Head.Next
            // 3nd Item ===> Tail = Head.Next.Next
            // 4nd Item ===> Tail = Head.Next.Next.Next
            // 5nd Item ===> Tail = Head.Next.Next.Next.Next
            // 6nd Item ===> Tail = Head.Next.Next.Next.Next.Next
            // ...

            // ========= Assert
            Assert.NotNull(list.Head);
            Assert.NotNull(list.Tail);
            Assert.Equal(totalItems, list.Count);
            // Now Head.Next is pointing to the new node which contain item2 in its Value property.
            Assert.NotNull(list.Head.Next);
            Assert.Equal(item1, list.Head.Value);
            Assert.Equal(item2, list.Head.Next.Value);
            // Tail now point to second node which contain item2 in its Value property.
            Assert.Null(list.Tail.Next);
            Assert.Equal(item2, list.Tail.Value);
            // ******** Important **********
            // After second item inserted, Head and Tail are not pointing to the same node anymore.
            Assert.NotEqual(list.Head, list.Tail);
            // But, Head.Next and Tail are pointing to the same node.
            Assert.Equal(list.Head.Next, list.Tail);
        } 
        #endregion

         #region [Tests for STEP 3]
        [Fact]
        public void AddFirst_AddFirstNodeAtStartOfList_HeadAndTailWillPointToSameNodeAndSizeSetToOne()
        {
            // Arrange
            var totalItems = 1;
            var item = 10;
            var list = new LinkedList<int>();

            // Act
            list.AddFirst(item);

            // Assert
            Assert.NotNull(list.Head);
            Assert.NotNull(list.Tail);
            Assert.Equal(totalItems, list.Count);
            
            Assert.Null(list.Head.Next);
            Assert.Equal(item, list.Head.Value);
            
            Assert.Null(list.Tail.Next);
            Assert.Equal(item, list.Tail.Value);
            
            // After first node inserted, Both Head & Tail nodes are referencing the same node.
            Assert.Equal(list.Head, list.Tail);
        } 

        [Fact]
        public void AddFirst_AddSecondNodeToStartOfList_HeadSetToNewNodeAndTailHavePreviousNodeAndSizeSetToTwo()
        {
            // ========= Arrange
            var totalItems = 2;
            var item1 = 10;
            var item2 = 20;
            var list = new LinkedList<int>();

            // ========= Act
            list.AddFirst(item1).AddFirst(item2);

            // ========= Assert
            Assert.Equal(totalItems, list.Count);
            
            Assert.Equal(item2, list.Head.Value);
            Assert.Equal(item1, list.Head.Next.Value);
            Assert.Equal(item1, list.Tail.Value);
            
            Assert.NotEqual(list.Head, list.Tail);
            Assert.Equal(list.Head.Next, list.Tail);
        } 
        #endregion

        #region [Tests for STEP 3]
        [Fact]
        public void IndexOf_ItemExists_ReturnItemIndex()
        {
            // Arrange
            var item1 = 10;
            var item2 = 20;
            var item3 = 30;
            var list = new LinkedList<int>();

            // Act
            list.AddLast(item1).AddLast(item2).AddLast(item3);
            var index = list.IndexOf(30);

            // Assert
            Assert.Equal(2, index);
        } 

        [Fact]
        public void IndexOf_ItemNotExists_ReturnMinesOne()
        {
            // Arrange
            var item1 = 10;
            var item2 = 20;
            var list = new LinkedList<int>();

            // Act
            list.AddLast(item1).AddLast(item2);
            var index = list.IndexOf(30);

            // Assert
            Assert.Equal(-1, index);
        } 

        [Fact]
        public void IndexOf_EmptyLinkedList_ReturnMinesOne()
        {
            // Arrange
            var list = new LinkedList<int>();

            // Act
            var index = list.IndexOf(50);

            // Assert
            Assert.Equal(-1, index);
        } 
        #endregion

        #region [Tests for STEP 3]
        [Fact]
        public void Contain_ItemExists_ReturnTrue()
        {
            // Arrange
            var item1 = 10;
            var item2 = 20;
            var item3 = 30;
            var list = new LinkedList<int>();

            // Act
            list.AddLast(item1).AddLast(item2).AddLast(item3);
            var isItemExist = list.Contain(30);

            // Assert
            Assert.True(isItemExist);
        } 

        [Fact]
        public void Contain_ItemNotExists_ReturnFalse()
        {
            // Arrange
            var item1 = 10;
            var item2 = 20;
            var list = new LinkedList<int>();

            // Act
            list.AddLast(item1).AddLast(item2);
            var isItemExist = list.Contain(30);

            // Assert
            Assert.False(isItemExist);
        } 
        #endregion
    }
}
