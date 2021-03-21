using NSubstitute;
using NUnit.Framework;
using Protocols.EcbEuropa;
using Protocols.EcbEuropa.Messages;
using Protocols.EcbEuropa.Services;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Protocols.Tests
{
    public class EcbEuropaProtocolTests
    {
        private IHttpClientFactory _httpClientFactory;
        private EcbMessageConverter _converter;
        private EcbEuropaProtocol _target;

        [SetUp]
        public void Setup()
        {
            _httpClientFactory = Substitute.For<IHttpClientFactory>();
            var _httpClient = new HttpClient(new HttpClientHandler
            {

                MaxConnectionsPerServer = 1,
                AllowAutoRedirect = true
            });
            _httpClientFactory.CreateClient(Arg.Any<string>()).Returns(_httpClient);
            _converter = new EcbMessageConverter();
            _target = new EcbEuropaProtocol(_httpClientFactory, _converter);
        }

        [Test]
        [Ignore("you can enable this test.")]
        public async Task CanGetRatesAsync()
        {
            var rates = await _target.GetRates();
            Assert.NotNull(rates);
            Assert.NotNull(rates.Cube.Cube.Rates);
            Assert.Greater(rates.Cube.Cube.Rates.Count(), 0);
            Assert.Pass();
        }


        [Test]
        public void CanConvertTextToMessage()
        {
            var res = _converter.Convert<RatesList>(EcbMessages.RateResponse);
            Assert.NotNull(res);
        }
    }
}