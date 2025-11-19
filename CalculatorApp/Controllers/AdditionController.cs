using CalculatorApp.Models;
using CalculatorApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorApp.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class AdditionController : ControllerBase
    {
        private readonly IAdditionService _service;

        public AdditionController(IAdditionService service)
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
    }
}