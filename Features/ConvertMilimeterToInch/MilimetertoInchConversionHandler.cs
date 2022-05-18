using aYo_TechnicalTest.Entites;
using aYo_TechnicalTest.Helper;
using aYo_TechnicalTest.Interface;
using aYo_TechnicalTest.ViewModel.MilimeterToInch;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace aYo_TechnicalTest.Features.ConvertMilimeterToInch
{
    public class MilimetertoInchConversionHandler : IRequestHandler<GetMilimeterToInchConversion, MilimiterToInchViewModel>
    {
        private readonly IAsyncRepository<ConversionDetailDto> _conversionRepository;

        public MilimetertoInchConversionHandler(IAsyncRepository<ConversionDetailDto> conversionRepository)
        {
            _conversionRepository = conversionRepository;
        }

        public async Task<MilimiterToInchViewModel>Handle(GetMilimeterToInchConversion request, CancellationToken cancellationToken)
        {
            var convertobj = await ConvertMilimeterToInch(request.MilimeterValue);
            return convertobj;
        }

        private async Task<MilimiterToInchViewModel> ConvertMilimeterToInch(decimal mililetervalue)
        {
            var restrunObj = await _conversionRepository.GetByIdAsync(AppConstant.LenghtId).ConfigureAwait(false);
            var convertValue = mililetervalue / restrunObj.ConversionRate;
            return new MilimiterToInchViewModel
            {
                ConvertFrom = restrunObj.MetricUnit,
                ConvertTo = restrunObj.ImperialUnit,
                ConvertValue = Math.Round(convertValue,4)
            };
        }
    }
}
