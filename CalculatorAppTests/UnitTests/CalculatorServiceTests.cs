using CalculatorApp.Services;
using Xunit;

namespace CalculatorAppTests.UnitTests
{
    public class CalculatorServiceTests
    {
        private readonly CalculatorService _service;

        public CalculatorServiceTests()
        {
            _service = new CalculatorService();
        }

        // Positive Test for Add
        [Fact]
        public void Add_ShouldReturnCorrectSum_WhenInputsAreValid()
        {
            // Act
            double result = _service.Add(10, 20);

            // Assert
            Assert.Equal(30, result);
        }

        // Negative Test for Add (Expected Wrong Value)
        [Fact]
        public void Add_ShouldNotReturnIncorrectValue()
        {
            // Act
            double result = _service.Add(10, 20);

            // Assert
            Assert.NotEqual(50, result);
        }

        // Positive Test for Subtract
        [Fact]
        public void Subtract_ShouldReturnCorrectDifference_WhenInputsAreValid()
        {
            double result = _service.Subtract(20, 10);

            Assert.Equal(10, result);
        }

        // Negative Test for Subtract (Expected Wrong Value)
        [Fact]
        public void Subtract_ShouldNotReturnIncorrectValue()
        {
            double result = _service.Subtract(20, 10);

            Assert.NotEqual(100, result);
        }
    }
}
