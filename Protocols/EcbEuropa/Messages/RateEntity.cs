using System.Xml.Schema;
using System.Xml.Serialization;

namespace Protocols.EcbEuropa.Messages
{
    [XmlRoot(ElementName = "Cube", Namespace = "http://www.ecb.int/vocabulary/2002-08-01/eurofxref")]
    public class RateEntity : IEcbEuropeMessage
    {
        [XmlAttribute("currency", Form = XmlSchemaForm.Unqualified)]
        public string CurrencyName { get; set; }

        [XmlAttribute("rate", Form = XmlSchemaForm.Unqualified)]
        public decimal Rate { get; set; }
    }
}
