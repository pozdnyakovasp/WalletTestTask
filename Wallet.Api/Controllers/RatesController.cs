using Domain.Rates;
using Microsoft.AspNetCore.Mvc;

namespace Wallet.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RatesController : ControllerBase
    {
        private ICurrencyRateService _currencyRateService;

        public RatesController(ICurrencyRateService currencyRateService)
        {
            _currencyRateService = currencyRateService;
        }

        [HttpGet]
        public IActionResult GetRate()
        {
            var rates = _currencyRateService.GetRates();

            return Ok(rates);
        }
    }
}
