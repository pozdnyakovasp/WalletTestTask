using Domain.Rates;
using Microsoft.AspNetCore.Mvc;
using Wallet.Api.Models.Converter;

namespace Wallet.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ConverterController : ControllerBase
    {
        private readonly ICurrencyRateService _currencyRateService;

        public ConverterController(ICurrencyRateService currencyRateService)
        {
            _currencyRateService = currencyRateService;
        }

        [HttpPost]
        public IActionResult Convert([FromBody] ConvertQueryModel queryModel)
        {
            try
            {
                _currencyRateService.Convert(queryModel.ToClaim());
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}
