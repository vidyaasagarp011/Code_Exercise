using System;
using Xunit;

namespace DeveloperSample.Algorithms
{
    public class AlgorithmTest
    {
        [Fact]
        public void CanGetFactorial_ValidInput()
        {
            Assert.Equal(24, Algorithms.GetFactorial(4));
            Assert.Equal(1, Algorithms.GetFactorial(0));
            Assert.Equal(1, Algorithms.GetFactorial(1));
            Assert.Equal(120, Algorithms.GetFactorial(5));
            Assert.Equal(3628800, Algorithms.GetFactorial(10));
        }

        [Fact]
        public void FormatSeparators_EmptyInput_ReturnsEmptyMessage()
        {
            Assert.Equal(MessageConstants.Empty, Algorithms.FormatSeparators());
            Assert.Equal(MessageConstants.Empty, Algorithms.FormatSeparators(null));
        }

        [Fact]
        public void FormatSeparators_OneItem_ReturnsItem()
        {
            Assert.Equal("single", Algorithms.FormatSeparators("single"));
        }

    }
}