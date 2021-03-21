using Protocols.EcbEuropa.Messages;
using System.Threading.Tasks;

namespace Protocols.EcbEuropa
{
    public interface IEcbEuropaProtocol
    {
        Task<RatesList> GetRates();
    }
}
