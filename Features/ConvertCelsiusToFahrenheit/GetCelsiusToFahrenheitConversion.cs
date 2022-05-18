using aYo_TechnicalTest.ViewModel.MilimeterToInch;
using MediatR;

namespace aYo_TechnicalTest.Features.ConvertCelsiusToFahrenheit
{
    public class GetCelsiusToFahrenheitConversion : IRequest<MilimiterToInchViewModel>
    {
        public decimal Celsius { get; set; }
        public GetCelsiusToFahrenheitConversion(decimal celsius)
        {
            Celsius = celsius;
        }
    }
}
