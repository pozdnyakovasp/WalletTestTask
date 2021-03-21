using Protocols.EcbEuropa.Messages;

namespace Protocols.EcbEuropa.Services
{
    public interface IEcbMessageConverter
    {
        T Convert<T>(string xml) where T : IEcbEuropeMessage;
    }
}
