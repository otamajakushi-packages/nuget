using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Otamajakushi
{
    public class Word
    {
        [JsonPropertyName("entry")]
        public Entry Entry { get; set; } = new Entry();

        [JsonPropertyName("translations")]
        public List<Translation> Translations { get; set; } = new List<Translation>();
        
        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; }

        [JsonPropertyName("contents")]
        public List<Content> Contents { get; set; } = new List<Content>();

        [JsonPropertyName("variations")]
        public List<Variation> Variations { get; set; } = new List<Variation>();

        [JsonPropertyName("relations")]
        public List<Relation> Relations { get; set; } = new List<Relation>();
    }
}
