using aYo_TechnicalTest.Entites;
using aYo_TechnicalTest.Features.ConvertCelsiusToFahrenheit;
using aYo_TechnicalTest.Helper;
using aYo_TechnicalTest.Interface;
using aYo_TechnicalTest.ViewModel.MilimeterToInch;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace aYo_TechnicalTest.Features
{
    public class GetCelsiusToFahrenheitConversionHandler : IRequestHandler<GetCelsiusToFahrenheitConversion, MilimiterToInchViewModel>
    {
        private readonly IAsyncRepository<ConversionDetailDto> _conversionRepository;
        public GetCelsiusToFahrenheitConversionHandler(IAsyncRepository<ConversionDetailDto> conversionRepository)
        {
            _conversionRepository = conversionRepository;
        }

        public async Task<MilimiterToInchViewModel> Handle(GetCelsiusToFahrenheitConversion request, CancellationToken cancellationToken)
        {
            var convertobj = await ConvertCelsiusToFahrenheit(request.Celsius);
            return convertobj;
        }

        private async Task<MilimiterToInchViewModel> ConvertCelsiusToFahrenheit(decimal celsiusvalue)
        {
            var restrunObj = await _conversionRepository.GetByIdAsync(AppConstant.TempatureCtoFId).ConfigureAwait(false);
            var convertValue = celsiusvalue * restrunObj.ConversionRate;
            var finalResult = convertValue + AppConstant.TempratureSubValue;
            return new MilimiterToInchViewModel
            {
                ConvertFrom = restrunObj.MetricUnit,
                ConvertTo = restrunObj.ImperialUnit,
                ConvertValue = Math.Round(finalResult, 4)
            };
        }
    }
}
