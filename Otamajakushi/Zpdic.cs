using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Otamajakushi
{
    [DataContract]
    public class Zpdic
    {
        [DataMember(Name = "alphabetOrder")]
        public string AlphabetOrder { get; set; }

        [DataMember(Name = "wordOrderType")]
        public string WordOrderType { get; set; }
        
        [DataMember(Name = "punctuations")]
        public List<string> Punctuations { get; set; }
        
        [DataMember(Name = "ignoredTranslationRegex")]
        public string IgnoredTranslationRegex { get; set; }
        
        [DataMember(Name = "pronunciationTitle")]
        public string PronunciationTitle { get; set; }
        
        [DataMember(Name = "plainInformationTitles")]
        public List<string> PlainInformationTitles { get; set; } = new List<string>();
        
        [DataMember(Name = "informationTitleOrder")]
        public object InformationTitleOrder { get; set; }
        
        [DataMember(Name = "formFontFamily")]
        public object FormFontFamily { get; set; }
        
        [DataMember(Name = "defaultWord")]
        public Word DefaultWord { get; set; }
    }
}
