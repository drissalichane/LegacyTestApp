using System;
using System.IO;

namespace LegacyWebApi.Utils
{
    public class LegacyFormatter
    {
        public byte[] SerializeObject(object obj)
        {
            // BinaryFormatter is heavily deprecated and dangerous
            return System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(obj);
        }
    }
}
