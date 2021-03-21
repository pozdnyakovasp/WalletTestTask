using Protocols.EcbEuropa.Messages;
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Protocols.EcbEuropa.Services
{
    public class EcbMessageConverter : IEcbMessageConverter
    {
        public T Convert<T>(string messageText) where T : IEcbEuropeMessage
        {
            var messageType = typeof(T);
            if (messageType == typeof(RatesList))
            {
                using var textReader = new StringReader(messageText);
                using XmlReader xmlReader = XmlReader.Create(textReader);
                var serializer = new XmlSerializer(typeof(T));

                var proxyMessage = (T)serializer.Deserialize(xmlReader);
                return proxyMessage;
            }

            throw new InvalidOperationException("Type {}");
        }
    }
}
