using Microsoft.AspNetCore.Mvc;

namespace CalculadoraRest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {

        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{operation}/{firstNumber}/{secondNumber}")]
        public IActionResult Get(string firstNumber, string secondNumber, string operation)
        {

            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                switch (operation)
                {
                    case "sum":
                        var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                        return Ok(sum.ToString());
                        break;

                    case "mult":
                        var mult = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                        return Ok(mult.ToString());
                        break;

                    case "div":
                        var div = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                        return Ok(div.ToString());
                        break;

                    case "med":
                        var med = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2;
                        return Ok(med.ToString());
                        break;

                        case "sub":
                        var sub = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                        return Ok(sub.ToString());
                        break;


                }
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("{square-root}/{firstNumber}")]
        public ActionResult SquareRoot(string firstNumber)
        {
            if (IsNumeric(firstNumber))
            {
                var squareRoot = Math.Sqrt((double)ConvertToDecimal(firstNumber));
                return Ok(squareRoot.ToString());
            }

            return BadRequest("Invalid Input");
        }

        private bool IsNumeric(string strNumber)
        {

            double number;

            bool isNumber = double.TryParse(
            strNumber,
            System.Globalization.NumberStyles.Any,
            System.Globalization.NumberFormatInfo.InvariantInfo,
             out number);

            return isNumber;

        }
        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;

            if (decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }

            return 0;
        }
    }
}