using aYo_TechnicalTest.Entites;
using aYo_TechnicalTest.Helper;
using aYo_TechnicalTest.Interface;
using aYo_TechnicalTest.ViewModel.MilimeterToInch;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace aYo_TechnicalTest.Features.ConvertMiligramToOunce
{
    public class GetMiliGramToOunceConversionHandler : IRequestHandler<GetMiliGramToOunceConversion, MilimiterToInchViewModel>
    {
        private readonly IAsyncRepository<ConversionDetailDto> _conversionRepository;
        public GetMiliGramToOunceConversionHandler(IAsyncRepository<ConversionDetailDto> conversionRepository)
        {
            _conversionRepository = conversionRepository;
        }

        public async Task<MilimiterToInchViewModel> Handle(GetMiliGramToOunceConversion request, CancellationToken cancellationToken)
        {
            var convertobj = await ConvertMiligramToOunce(request.MiliGramValue);
            return convertobj;
        }

        private async Task<MilimiterToInchViewModel> ConvertMiligramToOunce(decimal MiliGramValue)
        {
            var restrunObj = await _conversionRepository.GetByIdAsync(AppConstant.VolumeId).ConfigureAwait(false);
            var convertValue = MiliGramValue / restrunObj.ConversionRate;
            return new MilimiterToInchViewModel
            {
                ConvertFrom = restrunObj.ImperialUnit,
                ConvertTo = restrunObj.MetricUnit,
                ConvertValue = Math.Round(convertValue, 8)
            };
        }
    }
}
