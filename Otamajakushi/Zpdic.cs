using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Otamajakushi
{
    public class Zpdic
    {
        [JsonPropertyName("alphabetOrder")]
        public string AlphabetOrder { get; set; }

        [JsonPropertyName("wordOrderType")]
        public string WordOrderType { get; set; }
        
        [JsonPropertyName("punctuations")]
        public List<string> Punctuations { get; set; }
        
        [JsonPropertyName("ignoredTranslationRegex")]
        public string IgnoredTranslationRegex { get; set; }
        
        [JsonPropertyName("pronunciationTitle")]
        public string PronunciationTitle { get; set; }
        
        [JsonPropertyName("plainInformationTitles")]
        public List<string> PlainInformationTitles { get; set; } = new List<string>();
        
        [JsonPropertyName("informationTitleOrder")]
        public object InformationTitleOrder { get; set; }
        
        [JsonPropertyName("formFontFamily")]
        public object FormFontFamily { get; set; }
        
        [JsonPropertyName("defaultWord")]
        public Word DefaultWord { get; set; }
    }
}
