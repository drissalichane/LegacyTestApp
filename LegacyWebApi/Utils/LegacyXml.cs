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
            var settings = new XmlReaderSettings { ValidationType = ValidationType.None, DtdProcessing = DtdProcessing.Prohibit };
            using (var reader = XmlReader.Create(new System.IO.StringReader("<test></test>"), settings))
            {
                while (reader.Read())
                {
                    // read
                }
            }
        }
    }
}
