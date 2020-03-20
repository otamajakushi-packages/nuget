using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Otamajakushi
{
    public class Translation
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("forms")]
        public List<string> Forms { get; set; } = new List<string>();
    }
}
