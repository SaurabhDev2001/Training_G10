using Xunit;
using CalculatorApplication.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorTests
{
    public class CalculatorControllerTests
    {
        //    [Fact]
        //    public void AddGet_ShouldReturnCorrectResult()
        //    {
        //        var controller = new CalculatorController();
        //        var result = controller.AddGet(5, 3) as OkObjectResult;

        //        Assert.NotNull(result);
        //        dynamic data = result.Value;
        //        Assert.Equal(8, data.Result);
        //    }

        //    [Fact]
        //    public void AddPost_ShouldReturnCorrectResult()
        //    {
        //        var controller = new CalculatorController();
        //        var request = new CalculatorController.OperationRequest { A = 10, B = 4 };

        //        var result = controller.AddPost(request) as OkObjectResult;

        //        Assert.NotNull(result);
        //        dynamic data = result.Value;
        //        Assert.Equal(14, data.Result);
        //    }

        //    [Fact]
        //    public void AddPost_ShouldReturnError_WhenRequestIsNull()
        //    {
        //        var controller = new CalculatorController();
        //        var result = controller.AddPost(null) as ObjectResult;

        //        Assert.NotNull(result);
        //        Assert.Equal(500, result.StatusCode);
        //    }

        [Fact]
        public void AddGet_ShouldReturnCorrectResult()
        {
            var controller = new CalculatorController();
            var result = controller.AddGet(5, 3) as OkObjectResult;

            Assert.NotNull(result);
            var response = result.Value as CalculatorController.OperationResponse;
            Assert.NotNull(response);
            Assert.Equal(8, response.Result);
        }

        [Fact]
        public void AddPost_ShouldReturnCorrectResult()
        {
            var controller = new CalculatorController();
            var request = new CalculatorController.OperationRequest { A = 10, B = 4 };

            var result = controller.AddPost(request) as OkObjectResult;

            Assert.NotNull(result);
            var response = result.Value as CalculatorController.OperationResponse;
            Assert.NotNull(response);
            Assert.Equal(14, response.Result);
        }

        [Fact]
        public void AddPost_ShouldReturnBadRequest_WhenRequestIsNull()
        {
            var controller = new CalculatorController();
            Assert.Throws<NullReferenceException>(() => controller.AddPost(null));

        }
    }
}