using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Otamajakushi
{
    public class OneToManyJson
    {
        [JsonPropertyName("words")]
        public List<Word> Words { get; set; } = new List<Word>();

        [JsonPropertyName("zpdic")]
        public Zpdic Zpdic { get; set; }
    }
}
