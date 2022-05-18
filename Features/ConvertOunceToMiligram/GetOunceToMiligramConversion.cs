using aYo_TechnicalTest.ViewModel.MilimeterToInch;
using MediatR;

namespace aYo_TechnicalTest.Features.ConvertOunceToMiligram
{
    public class GetOunceToMiligramConversion : IRequest<MilimiterToInchViewModel>
    {
        public decimal OunceValue { get; set; }
        public GetOunceToMiligramConversion(decimal ounceValue)
        {
            OunceValue = ounceValue;
        }
    }
}
