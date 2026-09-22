using System;
using System.Text.Json;

namespace LegacyWebApi.Utils
{
    public class LegacyFormatter
    {
        public byte[] SerializeObject(object obj)
        {
            // BinaryFormatter removed in .NET 9; use System.Text.Json UTF-8 serializer
#pragma warning disable SYSLIB0020
            return JsonSerializer.SerializeToUtf8Bytes(obj, obj.GetType());
#pragma warning restore SYSLIB0020
        }
    }
}
