using Microsoft.AspNetCore.Mvc;
using CalculatorApplication.Services;

namespace CalculatorApplication.Controllers
{
    //[ApiController]
    //[Route("api/[controller]")]
    //public class CalculatorController : ControllerBase
    //{
    //    private readonly CalculatorServices _calculator = new CalculatorServices();

    //    public class OperationRequest
    //    {
    //        public int A { get; set; }
    //        public int B { get; set; }
    //    }

    //    [HttpGet("add")]
    //    public IActionResult AddGet([FromQuery] int a, [FromQuery] int b)
    //    {
    //        try
    //        {
    //            var result = _calculator.Add(a, b);
    //            return Ok(new { Result = result });
    //        }
    //        catch (Exception ex)
    //        {
    //            return BadRequest(ex.Message);
    //        }
    //    }

    //    [HttpPost("add")]
    //    public IActionResult AddPost([FromBody] OperationRequest request)
    //    {
    //        try
    //        {
    //            var result = _calculator.Add(request.A, request.B);
    //            return Ok(new { Result = result });
    //        }
    //        catch (Exception ex)
    //        {
    //            return BadRequest(ex.Message);
    //        }
    //    }
    //}



    [ApiController]
    [Route("api/[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly CalculatorServices _calculator = new CalculatorServices();

        public class OperationRequest
        {
            public int A { get; set; }
            public int B { get; set; }
        }

        public class OperationResponse
        {
            public int Result { get; set; }
        }

        [HttpGet("add")]
        public IActionResult AddGet([FromQuery] int a, [FromQuery] int b)
        {
            try
            {
                var result = _calculator.Add(a, b);
                return Ok(new OperationResponse { Result = result });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        [HttpPost("add")]
        public IActionResult AddPost([FromBody] OperationRequest request)
        {
            try
            {
                var result = _calculator.Add(request.A, request.B);
                return Ok(new OperationResponse { Result = result });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }
    }

}