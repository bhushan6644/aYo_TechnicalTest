using aYo_TechnicalTest.Entites;
using aYo_TechnicalTest.Helper;
using aYo_TechnicalTest.Interface;
using aYo_TechnicalTest.ViewModel.MilimeterToInch;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace aYo_TechnicalTest.Features.ConvertOunceToMiligram
{
    public class GetOunceToMiligramConversionHandler : IRequestHandler<GetOunceToMiligramConversion, MilimiterToInchViewModel>
    {
        private readonly IAsyncRepository<ConversionDetailDto> _conversionRepository;
        public GetOunceToMiligramConversionHandler(IAsyncRepository<ConversionDetailDto> conversionRepository)
        {
            _conversionRepository = conversionRepository;
        }

        public async Task<MilimiterToInchViewModel> Handle(GetOunceToMiligramConversion request, CancellationToken cancellationToken)
        {
            var convertobj = await ConvertOunceToMiligram(request.OunceValue);
            return convertobj;
        }

        private async Task<MilimiterToInchViewModel> ConvertOunceToMiligram(decimal OunceValue)
        {
            var restrunObj = await _conversionRepository.GetByIdAsync(AppConstant.VolumeId).ConfigureAwait(false);
            var convertValue = OunceValue * restrunObj.ConversionRate;
            return new MilimiterToInchViewModel
            {
                ConvertFrom = restrunObj.MetricUnit,
                ConvertTo = restrunObj.ImperialUnit,
                ConvertValue = Math.Round(convertValue, 4)
            };
        }
    }
}
