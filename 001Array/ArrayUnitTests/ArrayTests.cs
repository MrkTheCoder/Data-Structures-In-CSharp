/*
 * MAKE SURE TO ADD xUnit FROM Nuget TO THIS PROJECT.
 *
 * As you know there are many "Method Naming Conventions" out there, I will using two "Method Naming Conventions" that I like and use more at
 * below tests. I will do that JUST for learning purpose, But in real world, we should we should only stick to one naming convention in our
 * project based on our desire or team.
 *
 */

using DataStructureArray;
using Xunit;

namespace ArrayUnitTests
{
    public class ArrayTests
    {
        #region [STEP 1 of Array class]
        [Fact]
        // For "Method Naming Conventions", I used this format: "ClassMethodName_StateUnderTest_ExpectedBehavior".
        public void Constructor_SetWithValidLength_ArrayCreatedWithProperLengthAndCount()
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
        #endregion

    }

    
}
