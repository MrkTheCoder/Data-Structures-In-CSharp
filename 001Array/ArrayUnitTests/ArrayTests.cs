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
            var arrayLength = 10;
            var noItem = 0;
            Array array;

            // Act
            array = new Array(arrayLength);

            // Assert
            Assert.Equal(arrayLength, array.Items.Length);
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
        #endregion

        #region [Tests of STEP 2]
        [Fact]
        public void Insert_InsertOneItem_AddedToArrayAndCountShowIt()
        {
            // Arrange
            var arrayLength = 3;
            var item = 100;
            var expectedCount = 1;
            Array array = new Array(arrayLength);

            // Act
            array.Insert(item);

            //Assert
            Assert.Equal(item, array.Items[0]);
            Assert.Null(array.Items[1]);
            Assert.True(array.Count == expectedCount);
            Assert.True(array.Items.Length == arrayLength);
        }

        [Fact]
        public void Insert_InsertTwoItems_AddedToArrayAndCountShowIt()
        {
            // Arrange
            var arrayLength = 3;
            var items = new int[] { 100, 102 };
            Array array = new Array(arrayLength);

            // Act
            array.Insert(items[0]);
            array.Insert(items[1]);

            //Assert
            Assert.Equal(items[0], array.Items[0]);
            Assert.Equal(items[1], array.Items[1]);
            Assert.Null(array.Items[2]);
            Assert.True(array.Count == items.Length);
            Assert.True(array.Items.Length == arrayLength);
        }

        [Fact]
        public void Insert_MakeArrayFull_NoArrayLengthChanges()
        {
            // Arrange
            var arrayLength = 2;
            var items = new int[] { 100, 102 };
            Array array = new Array(arrayLength);

            // Act
            // Using Fluent Interface
            array.Insert(100).Insert(102);

            //Assert
            Assert.Equal(items[0], array.Items[0]);
            Assert.Equal(items[1], array.Items[1]);
            Assert.True(array.Count == items.Length);
            Assert.True(array.Items.Length == arrayLength);
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
            var newLength = arrayLength + (arrayLength / 2 + arrayLength % 2);
            Array array = new Array(arrayLength);

            // Act
            foreach (var item in items)
                array.Insert(item);

            //Assert
            for (int i = 0; i < items.Length; i++)
                Assert.Equal(items[i], array.Items[i]);
            Assert.True(array.Count == items.Length);
            Assert.True(array.Items.Length == newLength);
            // If there are extra free rooms they must be null
            for (int i = items.Length; i < newLength; i++)
                Assert.Null(array.Items[i]);
        }
        #endregion

        #region [Tests of STEP 3]
        [Fact]
        public void RemoveAt_IndexOfFirstItem_RemoveItemAndShiftOthersLeft()
        {
            // Arrange
            var arrayLength = 2;
            Array array = new Array(arrayLength);

            // Act
            array.Insert(100).Insert(102);
            array.RemoveAt(0);

            //Assert
            Assert.Equal(102, array.Items[0]);
            Assert.Null(array.Items[1]);
            Assert.True(array.Count == 1);
            Assert.True(array.Items.Length == arrayLength);
        }

        [Fact]
        public void RemoveAt_IndexOfLastItem_RemoveItemAndMakeItNull()
        {
            // Arrange
            var arrayLength = 2;
            Array array = new Array(arrayLength);

            // Act
            array.Insert(100).Insert(102);
            array.RemoveAt(1);

            //Assert
            Assert.Equal(100, array.Items[0]);
            Assert.Null(array.Items[1]);
            Assert.True(array.Count == 1);
            Assert.True(array.Items.Length == arrayLength);
        }

        [Fact]
        public void RemoveAt_RemoveAllItems_AllItemsShouldBeNull()
        {
            // Arrange
            var arrayLength = 2;
            Array array = new Array(arrayLength);

            // Act
            array.Insert(100).Insert(102);
            array.RemoveAt(0).RemoveAt(0);

            //Assert
            Assert.Null(array.Items[0]);
            Assert.Null(array.Items[1]);
            Assert.True(array.Count == 0);
            Assert.True(array.Items.Length == arrayLength);
        }

        [Fact]
        public void RemoveAt_RemoveItemFromEmptyArray_ThrowArgumentException()
        {
            // Arrange
            var arrayLength = 2;
            Array array = new Array(arrayLength);

            // Act

            //Assert
            var ex = Assert.Throws<ArgumentException>(() => array.RemoveAt(0));
            Assert.Equal("Index is out of range!", ex.Message);
            Assert.True(array.Count == 0);
            Assert.True(array.Items.Length == arrayLength);
        }

        [Fact]
        public void RemoveAt_InvalidIndexPointToEmptyRoom_ThrowArgumentException()
        {
            // Arrange
            var arrayLength = 2;
            Array array = new Array(arrayLength);

            // Act
            array.Insert(100);

            //Assert
            var ex = Assert.Throws<ArgumentException>(() => array.RemoveAt(1));
            Assert.Equal("Index is out of range!", ex.Message);
            Assert.True(array.Count == 1);
            Assert.True(array.Items.Length == arrayLength);
        }

        [Fact]
        public void RemoveAt_NegativeIndex_ThrowArgumentException()
        {
            // Arrange
            var arrayLength = 2;
            Array array = new Array(arrayLength);

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
            var arrayLength = 2;
            Array array = new Array(arrayLength);

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
            var arrayLength = 2;
            var notExitingItem = -1;
            Array array = new Array(arrayLength);

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
            var arrayLength = 2;
            var notExitingItem = -1;
            Array array = new Array(arrayLength);

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
            var arrayLength = 2;
            Array array = new Array(arrayLength);

            // Act
            var ex = Assert.Throws<Exception>(() => array.GetItems());

            //Assert
            Assert.Equal("No item exist in array!", ex.Message);
        }

        [Fact]
        public void GetItems_NotFullArray_OnlyArrayOfExistingItems()
        {
            // Arrange
            var arrayLength = 2;
            var item = -10;
            var expectedItems = 1;
            Array array = new Array(arrayLength);

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
            var arrayLength = 2;
            var item1 = -10;
            var item2 = 0;
            var expectedItems = 2;
            Array array = new Array(arrayLength);

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
            var arrayLength = 2;
            Array array = new Array(arrayLength);

            // Act
            array.Reverse();

            //Assert
        }

        [Fact]
        public void Reverse_FewItemsInArray_ReverseItemsAndSaveArrayLength()
        {
            // Arrange
            var arrayLength = 3;
            var totalItems = 2;
            Array array = new Array(arrayLength);

            // Act
            array.Insert(10).Insert(20).Reverse();

            //Assert
            Assert.Equal(arrayLength, array.Items.Length);
            Assert.Equal(totalItems, array.Count);
            Assert.Equal(0, array.IndexOf(20));
            Assert.Equal(1, array.IndexOf(10));
            Assert.Null(array.Items[arrayLength - 1]);
        }

        [Fact]
        public void Reverse_FullArray_ReverseItemsAndSaveArrayLength()
        {
            // Arrange
            var arrayLength = 2;
            var totalItems = 2;
            Array array = new Array(arrayLength);

            // Act
            array.Insert(10).Insert(20).Reverse();

            //Assert
            Assert.Equal(arrayLength, array.Items.Length);
            Assert.Equal(totalItems, array.Count);
            Assert.Equal(0, array.IndexOf(20));
            Assert.Equal(1, array.IndexOf(10));
        }

        [Fact]
        public void Reverse_ExpandedArray_ReverseItemsAndSaveNewArrayLength()
        {
            // Arrange
            var arrayLength = 3;
            var totalItems = 4;
            var newLength = arrayLength + (arrayLength / 2 + arrayLength % 2);
            Array array = new Array(arrayLength);

            // Act
            array.Insert(10).Insert(20).Insert(30).Insert(40).Reverse();

            //Assert
            Assert.Equal(newLength, array.Items.Length);
            Assert.Equal(totalItems, array.Count);
            Assert.Equal(0, array.IndexOf(40));
            Assert.Equal(1, array.IndexOf(30));
            Assert.Equal(2, array.IndexOf(20));
            Assert.Equal(3, array.IndexOf(10));
            for (int i = 4; i < newLength; i++)
                Assert.Null(array.Items[i]);
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
            Assert.Equal(3, array.Items[0]);
            Assert.Equal(1, array.Items[1]);
            Assert.Equal(2, array.Items[2]);
            Assert.Equal(arrayLength, array.Items.Length);
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
            Assert.Equal(1, array.Items[0]);
            Assert.Equal(3, array.Items[1]);
            Assert.Equal(2, array.Items[2]);
            Assert.Equal(arrayLength, array.Items.Length);
            Assert.Equal(arrayLength, array.Count);
        }

        [Fact]
        public void InsertAt_FullArray_ExpandAndShiftOtherItemsRight()
        {
            // Arrange
            var arrayLength = 3;
            var newLength = arrayLength + (arrayLength / 2 + arrayLength % 2);
            var array = new Array(arrayLength);
            array.Insert(1).Insert(2).Insert(3);

            // Act
            array.InsertAt(4, 0);

            //Assert
            Assert.Equal(4, array.Items[0]);
            Assert.Equal(1, array.Items[1]);
            Assert.Equal(2, array.Items[2]);
            Assert.Equal(3, array.Items[3]);
            Assert.Equal(newLength, array.Items.Length);
            Assert.Equal(4, array.Count);
        }

        [Fact]
        public void InsertAt_InvalidIndex_ThrowArgumentException()
        {
            // Arrange
            var arrayLength = 2;
            var array = new Array(arrayLength);
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
            var arrayLength = 2;
            var array = new Array(arrayLength);

            // Act
            var ex = Assert.Throws<ArgumentException>(() => array.InsertAt(1, 0));

            //Assert
            Assert.Equal("Index is out of range!", ex.Message);
        }
        #endregion
    }


}
