using System;
using System.Xml;
using System.Xml.Schema;

namespace LegacyWebApi.Utils
{
    public class LegacyXml
    {
        [Obsolete("XmlValidatingReader is obsolete.")]
        public void ReadXml()
        {
            // XmlValidatingReader is obsolete
#pragma warning disable CS0618
            using (var stringReader = new System.IO.StringReader("<test></test>"))
            {
                var xmlTextReader = new XmlTextReader(stringReader);
                var validatingReader = new XmlValidatingReader(xmlTextReader);
                validatingReader.ValidationType = ValidationType.None;
                while (validatingReader.Read())
                {
                    // read
                }
            }
#pragma warning restore CS0618
        }
    }
}
