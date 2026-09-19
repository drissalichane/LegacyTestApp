using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace LegacyWebApi.Utils
{
    public class LegacyFormatter
    {
        public byte[] SerializeObject(object obj)
        {
            // BinaryFormatter is heavily deprecated and dangerous
#pragma warning disable SYSLIB0011
            var formatter = new BinaryFormatter();
            using (var stream = new MemoryStream())
            {
                formatter.Serialize(stream, obj);
                return stream.ToArray();
            }
#pragma warning restore SYSLIB0011
        }
    }
}
