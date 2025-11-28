using CalculatorApp.Models;
using CalculatorApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MultiplicationController : ControllerBase
    {
        private readonly IMultiplicationService _multiplicationService;

        public MultiplicationController(IMultiplicationService multiplicationService)
        {
            _multiplicationService = multiplicationService;
        }

        [HttpPost]
        public ActionResult<double> Multiply([FromBody] CalculationRequest request)
        {
            var result = _multiplicationService.Multiply(request.Number1, request.Number2);
            return Ok(result);
        }
    }
}