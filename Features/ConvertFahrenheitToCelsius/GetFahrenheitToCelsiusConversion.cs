using aYo_TechnicalTest.ViewModel.MilimeterToInch;
using MediatR;

namespace aYo_TechnicalTest.Features.ConvertFahrenheitToCelsius
{
    public class GetFahrenheitToCelsiusConversion : IRequest<MilimiterToInchViewModel>
    {
        public decimal Fahrenheit { get; set; }
        public GetFahrenheitToCelsiusConversion(decimal fahrenheit)
        {
            Fahrenheit = fahrenheit;
        }
    }
}
