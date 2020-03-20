using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Otamajakushi
{
    public static class OneToManyJsonSerializer
    {
        public static OneToManyJson Deserialize(string json, JsonSerializerOptions options = null)
        {
            return JsonSerializer.Deserialize<OneToManyJson>(json, options);
        }

        public static string Serialize(OneToManyJson value, JsonSerializerOptions options = null)
        {
            return JsonSerializer.Serialize(value, options);
        }
    }
}
