using aYo_TechnicalTest.ViewModel.MilimeterToInch;
using MediatR;

namespace aYo_TechnicalTest.Features.ConvertMiligramToOunce
{
    public class GetMiliGramToOunceConversion : IRequest<MilimiterToInchViewModel>
    {
        public decimal MiliGramValue { get; set; }
        public GetMiliGramToOunceConversion(decimal miligramValue)
        {
            MiliGramValue = miligramValue;
        }
    }
}
