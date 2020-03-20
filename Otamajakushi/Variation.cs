using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Otamajakushi
{
    [DataContract]
    public class Variation
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("form")]
        public string Form { get; set; }
    }
}
