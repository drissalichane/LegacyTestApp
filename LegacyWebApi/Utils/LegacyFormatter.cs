using System;
using System.IO;
using System.Text.Json;

namespace LegacyWebApi.Utils
{
    public class LegacyFormatter
    {
        public byte[] SerializeObject(object obj)
        {
            // BinaryFormatter is heavily deprecated and dangerous
            return JsonSerializer.SerializeToUtf8Bytes(obj);
        }
    }
}
