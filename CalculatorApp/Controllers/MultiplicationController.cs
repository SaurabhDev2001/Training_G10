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
            var result = _multiplicationService.Multiply(request.A, request.B);
            return Ok(result);
        }
    }
}