using System.Xml.Serialization;

namespace Protocols.EcbEuropa.Messages
{

    [XmlRoot(ElementName = "Cube", Namespace = "http://www.ecb.int/vocabulary/2002-08-01/eurofxref")]
    public class CubeRoot
    {
        [XmlElement(ElementName = "Cube", Namespace = "http://www.ecb.int/vocabulary/2002-08-01/eurofxref")]
        public Cube Cube { get; set; }
    }
}
