using Xunit;
using CalculatorApplication.Services;
using System;

namespace CalculatorTests
{
    public class CalculatorServicesTests
    {
        private readonly CalculatorServices _calculator = new CalculatorServices();

        [Fact]
        public void Add_ShouldReturnCorrectSum()
        {
            int result = _calculator.Add(5, 3);
            Assert.Equal(8, result);
        }

        [Fact]
        public void Add_ShouldThrowException_WhenOverflowOccurs()
        {
            Assert.Throws<InvalidOperationException>(() => _calculator.Add(int.MaxValue, 1));
        }
    }
}