using aYo_TechnicalTest.ViewModel.MilimeterToInch;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace aYo_TechnicalTest.Features.ConvertMilimeterToInch
{
    public class GetMilimeterToInchConversion : IRequest<MilimiterToInchViewModel>
    {
        [Required]
        public decimal MilimeterValue { get; set; }
        public GetMilimeterToInchConversion(decimal milimeterValue)
        {
            MilimeterValue = milimeterValue;
           
        }
    }
}
