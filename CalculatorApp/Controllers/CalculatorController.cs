using CalculatorApp.Models;
using CalculatorApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorApp.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ICalculatorService _service;

        public CalculatorController(ICalculatorService service)
        {
            _service = service;
        }

        // GET: api/Calculator/add?number1=10&number2=20
        [HttpGet("add")]
        public IActionResult Add(double number1, double number2)
        {
            try
            {
                var result = _service.Add(number1, number2);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        // POST: api/Calculator/add
        [HttpPost("add")]
        public IActionResult AddPost([FromBody] CalculationRequest request)
        {
            try
            {
                if (request == null)
                    throw new Exception("Request body cannot be null");

                var result = _service.Add(request.Number1, request.Number2);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        // GET: api/Calculator/subtract?number1=10&number2=5
        [HttpGet("subtract")]
        public IActionResult Subtract(double number1, double number2)
        {
            try
            {
                var result = _service.Subtract(number1, number2);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        // POST: api/Calculator/subtract
        [HttpPost("subtract")]
        public IActionResult SubtractPost([FromBody] CalculationRequest request)
        {
            try
            {
                if (request == null)
                    throw new Exception("Request body cannot be null");

                var result = _service.Subtract(request.Number1, request.Number2);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("Multiply")]
        public IActionResult Multiply(double number1, double number2)
        {
            try
            {
                var result = _service.Multiply(number1, number2);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
