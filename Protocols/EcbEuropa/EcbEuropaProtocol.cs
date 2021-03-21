using Protocols.EcbEuropa.Messages;
using Protocols.EcbEuropa.Services;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Protocols.EcbEuropa
{
    public class EcbEuropaProtocol : IEcbEuropaProtocol
    {
        // todo settings
        const string RATE_URI = "https://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml";
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IEcbMessageConverter _converter;

        public EcbEuropaProtocol(IHttpClientFactory httpClientFactory, IEcbMessageConverter converter)
        {
            _httpClientFactory = httpClientFactory;
            _converter = converter;
        }

        public async Task<RatesList> GetRates()
        {
            var response = await TrySendGetRequest<RatesList>(RATE_URI);
            return response;
        }

        private async Task<T> TrySendGetRequest<T>(string uri) where T : IEcbEuropeMessage
        {
            var client = _httpClientFactory.CreateClient();
            try
            {
                var response = await client.GetAsync(uri);
                var responseBody = await response?.Content?.ReadAsStringAsync();

                if (responseBody == null)
                {
                    return default;
                }

                var result = _converter.Convert<T>(responseBody);

                return result;
            }
            catch (Exception ex)
            {
                // log ex;
                return default;
            }
        }
    }
}
