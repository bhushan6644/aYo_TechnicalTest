using aYo_TechnicalTest.Features.ConvertCelsiusToFahrenheit;
using aYo_TechnicalTest.Features.ConvertFahrenheitToCelsius;
using aYo_TechnicalTest.Features.ConvertInchToMilimeter;
using aYo_TechnicalTest.Features.ConvertMiligramToOunce;
using aYo_TechnicalTest.Features.ConvertMilimeterToInch;
using aYo_TechnicalTest.Features.ConvertOunceToMiligram;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace aYo_TechnicalTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConversionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ConversionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/api/MilimeterToInch")]
        public async Task<IActionResult> Get(decimal MilimeterValue)
        {
            var result = await _mediator.Send(new GetMilimeterToInchConversion(MilimeterValue));
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("/api/InchToMilimeter")]
        public async Task<IActionResult> ConvertInchToMilimeter(decimal InchValue)
        {
            var result = await _mediator.Send(new GetInchToMilimeterConversion(InchValue));
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("/api/FahrenheitTocelsius")]
        public async Task<IActionResult> ConvertFahrenheitTocelsius(decimal Fahrenheit)
        {
            var result = await _mediator.Send(new GetFahrenheitToCelsiusConversion(Fahrenheit));
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        
        [HttpGet("/api/CelsiusToFahrenheit")]
        public async Task<IActionResult> ConvertCelsiusToFahrenheit(decimal Celsius)
        {
            var result = await _mediator.Send(new GetCelsiusToFahrenheitConversion(Celsius));
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        [HttpGet("/api/MiligramToOunce")]
        public async Task<IActionResult> ConvertMiligramToOunce(decimal MiliGram)
        {
            var result = await _mediator.Send(new GetMiliGramToOunceConversion(MiliGram));
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("/api/OunceToMiligram")]
        public async Task<IActionResult> ConvertOunceToMiligram(decimal Ounce)
        {
            var result = await _mediator.Send(new GetOunceToMiligramConversion(Ounce));
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

    }
    
}
