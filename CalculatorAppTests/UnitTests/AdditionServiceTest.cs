using CalculatorApp.Services;
using Xunit;

namespace CalculatorAppTests.UnitTests
{
    public class AdditionServiceTest
    {
        private readonly AdditionService _service;

        public AdditionServiceTest()
        {
            _service = new AdditionService();
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
    }
}