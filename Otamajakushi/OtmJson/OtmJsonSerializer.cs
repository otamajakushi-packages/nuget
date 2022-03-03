using System.Text.Json;

namespace Otamajakushi.OtmJson
{
    public static class OtmJsonSerializer
    {
        public static OtmJson Deserialize(string json, JsonSerializerOptions options = null)
        {
            return JsonSerializer.Deserialize<OtmJson>(json, options);
        }

        public static string Serialize(OtmJson value, JsonSerializerOptions options = null)
        {
            return JsonSerializer.Serialize(value, options);
        }
    }
}
