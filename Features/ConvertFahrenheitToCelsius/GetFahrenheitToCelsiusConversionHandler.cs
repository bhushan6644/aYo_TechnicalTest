using aYo_TechnicalTest.Entites;
using aYo_TechnicalTest.Helper;
using aYo_TechnicalTest.Interface;
using aYo_TechnicalTest.ViewModel.MilimeterToInch;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace aYo_TechnicalTest.Features.ConvertFahrenheitToCelsius
{
    public class GetFahrenheitToCelsiusConversionHandler : IRequestHandler<GetFahrenheitToCelsiusConversion, MilimiterToInchViewModel>
    {
        private readonly IAsyncRepository<ConversionDetailDto> _conversionRepository;
        public GetFahrenheitToCelsiusConversionHandler(IAsyncRepository<ConversionDetailDto> conversionRepository)
        {
            _conversionRepository = conversionRepository;
        }

        public async Task<MilimiterToInchViewModel> Handle(GetFahrenheitToCelsiusConversion request, CancellationToken cancellationToken)
        {
            var convertobj = await ConvertFahrenheitTocelsius(request.Fahrenheit);
            return convertobj;
        }

        private async Task<MilimiterToInchViewModel> ConvertFahrenheitTocelsius(decimal Fahrenheitvalue)
        {
            var restrunObj = await _conversionRepository.GetByIdAsync(AppConstant.TempatureFtoCId).ConfigureAwait(false);
            var convertValue = Fahrenheitvalue - AppConstant.TempratureSubValue;
            var finalResult = convertValue * restrunObj.ConversionRate;
            return new MilimiterToInchViewModel
            {
                ConvertFrom = restrunObj.ImperialUnit,
                ConvertTo = restrunObj.MetricUnit,
                ConvertValue = Math.Round(finalResult, 4)
            };
        }
    }
}
