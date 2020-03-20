using System.Text.Json.Serialization;

namespace Otamajakushi
{
    public class Content
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }
    }
}
