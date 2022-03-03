using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Otamajakushi.OtmJson
{
    public class Zpdic
    {
        [JsonPropertyName("alphabetOrder")]
        public string AlphabetOrder { get; set; }

        [JsonPropertyName("wordOrderType")]
        public string WordOrderType { get; set; }
        
        [JsonPropertyName("punctuations")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2227: Collection properties should be read only")]
        public List<string> Punctuations { get; set; }
        
        [JsonPropertyName("ignoredTranslationRegex")]
        public string IgnoredTranslationRegex { get; set; }
        
        [JsonPropertyName("pronunciationTitle")]
        public string PronunciationTitle { get; set; }
        
        [JsonPropertyName("plainInformationTitles")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2227: Collection properties should be read only")]
        public List<string> PlainInformationTitles { get; set; } = new List<string>();
        
        [JsonPropertyName("informationTitleOrder")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2227: Collection properties should be read only")]
        public List<string> InformationTitleOrder { get; set; } = new List<string>();

        [JsonPropertyName("formFontFamily")]
        public string FormFontFamily { get; set; }
        
        [JsonPropertyName("defaultWord")]
        public Word DefaultWord { get; set; }
    }
}
