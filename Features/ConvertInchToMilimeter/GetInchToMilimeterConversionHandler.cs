using aYo_TechnicalTest.Entites;
using aYo_TechnicalTest.Helper;
using aYo_TechnicalTest.Interface;
using aYo_TechnicalTest.ViewModel.MilimeterToInch;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace aYo_TechnicalTest.Features.ConvertInchToMilimeter
{
    public class GetInchToMilimeterConversionHandler : IRequestHandler<GetInchToMilimeterConversion, MilimiterToInchViewModel>
    {
        private readonly IAsyncRepository<ConversionDetailDto> _conversionRepository;
        public GetInchToMilimeterConversionHandler(IAsyncRepository<ConversionDetailDto> conversionRepository)
        {
            _conversionRepository = conversionRepository;
        }

        public async Task<MilimiterToInchViewModel> Handle(GetInchToMilimeterConversion request, CancellationToken cancellationToken)
        {
            var convertobj = await ConvertMilimeterToInch(request.InchValue);
            return convertobj;
        }

        private async Task<MilimiterToInchViewModel> ConvertMilimeterToInch(decimal inchvalue)
        {
            var restrunObj = await _conversionRepository.GetByIdAsync(AppConstant.LenghtId).ConfigureAwait(false);
            var convertValue = inchvalue * restrunObj.ConversionRate;
            return new MilimiterToInchViewModel
            {
                ConvertFrom = restrunObj.ImperialUnit,
                ConvertTo = restrunObj.MetricUnit,
                ConvertValue = Math.Round(convertValue, 4)
            };
        }
    }
}
