/*
 * MAKE SURE TO ADD xUnit FROM Nuget TO THIS PROJECT.
 *
 * As you know, there are many "Method Naming Conventions" out there. But usually I'm selecting one of these two naming conventions that I
 * used at first two test methods.
 *
 */

using System;
using Xunit;
using Array = ArrayDataStructure.Array;

namespace ArrayUnitTests
{
    public class ArrayTests
    {
        #region [Tests of STEP 1]
        [Fact]
        // "Method Naming Conventions" 1, "ClassMethodName_StateUnderTest_ExpectedBehavior".
        public void Constructor_SetValidLength_ArrayCreatedWithProperLengthAndCount()
        {
            // Arrange
            var noItem = 0;
 
            // Act
            var array = new Array(10);

            // Assert
            Assert.Equal(noItem, array.Count);
        }

        [Theory()]
        [InlineData(0)]
        [InlineData(-1)]
        // "Method Naming Conventions" 2, "Should_ExpectedBehavior_When_StateUnderTest".
        public void ShouldThrowArgumentExceptionAtInstantiating_WhenLengthIsInvalid(int invalidLength)
        {
            // Arrange
            Array array;
            var exceptionMessage = "length cannot be less than 1";

            // Act
            // Assert
            var ex = Assert.Throws<ArgumentException>(() => array = new Array(invalidLength));
            Assert.Equal(exceptionMessage, ex.Message);
        }

        [Fact]
        public void GetItem_InvalidIndex_ArgumentException()
        {
            // Arrange
            var exceptionMessage = "Index is out of range!";

            // Act
            var array = new Array(10);

            // Assert
            var ex = Assert.Throws<ArgumentException>(() => array.GetItem(0));
            Assert.Equal(exceptionMessage, ex.Message);
        }
        #endregion

        #region [Tests of STEP 2]
        [Fact]
        public void Insert_InsertOneItem_AddedToArrayAndCountShowIt()
        {
            // Arrange
            var item = 100;
            var expectedCount = 1;
            Array array = new Array(3);

            // Act
            array.Insert(item);

            //Assert
            Assert.Equal(item, array.GetItem(0));
            Assert.True(array.Count == expectedCount);
        }

        [Fact]
        public void Insert_InsertTwoItems_AddedToArrayAndCountShowIt()
        {
            // Arrange
            var items = new int[] { 100, 102 };
            Array array = new Array(3);

            // Act
            array.Insert(items[0]);
            array.Insert(items[1]);

            //Assert
            Assert.Equal(items[0], array.GetItem(0));
            Assert.Equal(items[1], array.GetItem(1));
            Assert.True(array.Count == items.Length);
        }

        [Fact]
        public void Insert_MakeArrayFull_NoArrayLengthChanges()
        {
            // Arrange
            var items = new int[] { 100, 102 };
            Array array = new Array(2);

            // Act
            // Using Fluent Interface
            array.Insert(100).Insert(102);

            //Assert
            Assert.Equal(items[0], array.GetItem(0));
            Assert.Equal(items[1], array.GetItem(1));
            Assert.True(array.Count == items.Length);
        }

        [Theory]
        [InlineData(1, new[] { 100, 102 })]
        [InlineData(2, new[] { 100, 102, 103 })]
        [InlineData(3, new[] { 100, 102, 103, 104 })]
        [InlineData(4, new[] { 100, 102, 103, 104, 105 })]
        public void Insert_ByPassArrayLength_ExpandArray(
            int arrayLength,
            int[] items)
        {
            // Arrange
            Array array = new Array(arrayLength);

            // Act
            foreach (var item in items)
                array.Insert(item);

            //Assert
            for (int i = 0; i < items.Length; i++)
                Assert.Equal(items[i], array.GetItem(i));
            Assert.True(array.Count == items.Length);
        }
        #endregion

        #region [Tests of STEP 3]
        [Fact]
        public void RemoveAt_IndexOfFirstItem_RemoveItemAndShiftOthersLeft()
        {
            // Arrange
            Array array = new Array(2);

            // Act
            array.Insert(100).Insert(102);
            array.RemoveAt(0);

            //Assert
            Assert.Equal(102, array.GetItem(0));
            Assert.True(array.Count == 1);
        }

        [Fact]
        public void RemoveAt_IndexOfLastItem_RemoveItemAndMakeItNull()
        {
            // Arrange
            Array array = new Array(2);

            // Act
            array.Insert(100).Insert(102);
            array.RemoveAt(1);

            //Assert
            Assert.Equal(100, array.GetItem(0));
            Assert.True(array.Count == 1);
        }

        [Fact]
        public void RemoveAt_RemoveAllItems_AllItemsShouldBeNull()
        {
            // Arrange
            Array array = new Array(2);

            // Act
            array.Insert(100).Insert(102);
            array.RemoveAt(0).RemoveAt(0);

            //Assert
            Assert.True(array.Count == 0);
        }

        [Fact]
        public void RemoveAt_RemoveItemFromEmptyArray_ThrowArgumentException()
        {
            // Arrange
            Array array = new Array(1);

            // Act

            //Assert
            var ex = Assert.Throws<ArgumentException>(() => array.RemoveAt(0));
            Assert.Equal("Index is out of range!", ex.Message);
            Assert.True(array.Count == 0);
        }

        [Fact]
        public void RemoveAt_InvalidIndexPointToEmptyRoom_ThrowArgumentException()
        {
            // Arrange
            Array array = new Array(2);

            // Act
            array.Insert(100);

            //Assert
            var ex = Assert.Throws<ArgumentException>(() => array.RemoveAt(1));
            Assert.Equal("Index is out of range!", ex.Message);
            Assert.True(array.Count == 1);
        }

        [Fact]
        public void RemoveAt_NegativeIndex_ThrowArgumentException()
        {
            // Arrange
            Array array = new Array(2);

            // Act
            array.Insert(100).Insert(102);

            //Assert
            var ex = Assert.Throws<ArgumentException>(() => array.RemoveAt(-1));
            Assert.Equal("Index is out of range!", ex.Message);
            Assert.True(array.Count == 2);
        }
        #endregion

        #region [Tests of STEP 4]
        [Fact]
        public void IndexOf_ExistingItemInArray_IndexOfItem()
        {
            // Arrange
            Array array = new Array(2);

            // Act
            array.Insert(100).Insert(102);
            var index = array.IndexOf(102);

            //Assert
            Assert.Equal(1, index);
        }

        [Fact]
        public void IndexOf_NotExistingItemInArray_ReturnMinesOne()
        {
            // Arrange
            var notExitingItem = -1;
            Array array = new Array(2);

            // Act
            array.Insert(100).Insert(102);
            var index = array.IndexOf(103);

            //Assert
            Assert.Equal(notExitingItem, index);
        }

        [Fact]
        public void IndexOf_SearchInEmptyArray_ReturnMinesOne()
        {
            // Arrange
            var notExitingItem = -1;
            Array array = new Array(2);

            // Act
            var index = array.IndexOf(100);

            //Assert
            Assert.Equal(notExitingItem, index);
            Assert.True(array.Count == 0);
        }
        #endregion

        #region [Tests of STEP 5]
        [Fact]
        public void GetItems_EmptyArray_ThrowException()
        {
            // Arrange
            Array array = new Array(2);

            // Act
            var ex = Assert.Throws<Exception>(() => array.GetItems());

            //Assert
            Assert.Equal("No item exist in array!", ex.Message);
        }

        [Fact]
        public void GetItems_NotFullArray_OnlyArrayOfExistingItems()
        {
            // Arrange
            var item = -10;
            var expectedItems = 1;
            Array array = new Array(2);

            // Act
            var items = array.Insert(item).GetItems();

            //Assert
            Assert.Equal(expectedItems, items.Length);
            Assert.Equal(item, items[0]);
        }

        [Fact]
        public void GetItems_FullArray_AllItems()
        {
            // Arrange
            var item1 = -10;
            var item2 = 0;
            var expectedItems = 2;
            Array array = new Array(2);

            // Act
            var items = array.Insert(item1).Insert(item2).GetItems();

            //Assert
            Assert.Equal(expectedItems, items.Length);
            Assert.Equal(item1, items[0]);
            Assert.Equal(item2, items[1]);
        }
        #endregion

        #region [Tests for STEP 6]
        [Fact]
        public void Reverse_EmptyArray_NothingHappen()
        {
            // Arrange
            Array array = new Array(2);

            // Act
            array.Reverse();

            //Assert
        }

        [Fact]
        public void Reverse_FewItemsInArray_ReverseItemsAndSaveArrayLength()
        {
            // Arrange
            var totalItems = 2;
            Array array = new Array(3);

            // Act
            array.Insert(10).Insert(20).Reverse();

            //Assert
            Assert.Equal(totalItems, array.Count);
            Assert.Equal(0, array.IndexOf(20));
            Assert.Equal(1, array.IndexOf(10));
        }

        [Fact]
        public void Reverse_FullArray_ReverseItemsAndSaveArrayLength()
        {
            // Arrange
            var totalItems = 2;
            Array array = new Array(2);

            // Act
            array.Insert(10).Insert(20).Reverse();

            //Assert
            Assert.Equal(totalItems, array.Count);
            Assert.Equal(0, array.IndexOf(20));
            Assert.Equal(1, array.IndexOf(10));
        }

        [Fact]
        public void Reverse_ExpandedArray_ReverseItemsAndSaveNewArrayLength()
        {
            // Arrange
            var totalItems = 4;
            Array array = new Array(3);

            // Act
            array.Insert(10).Insert(20).Insert(30).Insert(40).Reverse();

            //Assert
            Assert.Equal(totalItems, array.Count);
            Assert.Equal(0, array.IndexOf(40));
            Assert.Equal(1, array.IndexOf(30));
            Assert.Equal(2, array.IndexOf(20));
            Assert.Equal(3, array.IndexOf(10));
        }
        #endregion

        #region [Tests for STEP 7]
        [Fact]
        public void InsertAt_OnFirstItem_ShiftRightOtherItems()
        {
            // Arrange
            var arrayLength = 3;
            var array = new Array(arrayLength);
            array.Insert(1).Insert(2);

            // Act
            array.InsertAt(3, 0);

            //Assert
            Assert.Equal(3, array.GetItem(0));
            Assert.Equal(1, array.GetItem(1));
            Assert.Equal(2, array.GetItem(2));
            Assert.Equal(arrayLength, array.Count);
        }

        [Fact]
        public void InsertAt_OnLastItem_ShiftItRight()
        {
            // Arrange
            var arrayLength = 3;
            var array = new Array(arrayLength);
            array.Insert(1).Insert(2);

            // Act
            array.InsertAt(3, array.Count - 1);

            //Assert
            Assert.Equal(1, array.GetItem(0));
            Assert.Equal(3, array.GetItem(1));
            Assert.Equal(2, array.GetItem(2));
            Assert.Equal(arrayLength, array.Count);
        }

        [Fact]
        public void InsertAt_FullArray_ExpandAndShiftOtherItemsRight()
        {
            // Arrange
            var arrayLength = 3;
            var array = new Array(arrayLength);
            array.Insert(1).Insert(2).Insert(3);

            // Act
            array.InsertAt(4, 0);

            //Assert
            Assert.Equal(4, array.GetItem(0));
            Assert.Equal(1, array.GetItem(1));
            Assert.Equal(2, array.GetItem(2));
            Assert.Equal(3, array.GetItem(3));
            Assert.Equal(arrayLength+1, array.Count);
        }

        [Fact]
        public void InsertAt_InvalidIndex_ThrowArgumentException()
        {
            // Arrange
            var array = new Array(2);
            array.Insert(1);

            // Act
            var ex = Assert.Throws<ArgumentException>(() => array.InsertAt(2, 1));

            //Assert
            Assert.Equal("Index is out of range!", ex.Message);
            Assert.Throws<ArgumentException>(() => array.InsertAt(2, -1));
        }

        [Fact]
        public void InsertAt_EmptyArray_ThrowArgumentException()
        {
            // Arrange
            var array = new Array(2);

            // Act
            var ex = Assert.Throws<ArgumentException>(() => array.InsertAt(1, 0));

            //Assert
            Assert.Equal("Index is out of range!", ex.Message);
        }
        #endregion
    }


}
