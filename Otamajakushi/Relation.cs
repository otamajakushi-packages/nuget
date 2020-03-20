using System.Text.Json.Serialization;

namespace Otamajakushi
{
    public class Relation
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("entry")]
        public Entry Entry { get; set; } = new Entry();
    }
}
