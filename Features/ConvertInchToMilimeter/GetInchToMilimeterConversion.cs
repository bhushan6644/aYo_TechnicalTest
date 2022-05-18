using aYo_TechnicalTest.ViewModel.MilimeterToInch;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace aYo_TechnicalTest.Features.ConvertInchToMilimeter
{
    public class GetInchToMilimeterConversion : IRequest<MilimiterToInchViewModel>
    {
        [Required]
        public decimal InchValue { get; set; }
      
        public GetInchToMilimeterConversion(decimal inchValue)
        {
            InchValue = inchValue;
        }
    }
}
