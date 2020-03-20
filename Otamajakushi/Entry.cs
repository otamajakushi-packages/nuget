using System.Text.Json.Serialization;

namespace Otamajakushi
{
    public class Entry
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("form")]
        public string Form { get; set; }
    }
}
