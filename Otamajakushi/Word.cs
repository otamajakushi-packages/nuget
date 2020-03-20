using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Otamajakushi
{
    [DataContract]
    public class Word
    {
        [DataMember(Name = "entry")]
        public Entry Entry { get; set; } = new Entry();

        [DataMember(Name = "translations")]
        public List<Translation> Translations { get; set; } = new List<Translation>();
        
        [DataMember(Name = "tags")]        
        public List<string> Tags { get; set; }

        [DataMember(Name = "contents")]
        public List<Content> Contents { get; set; } = new List<Content>();

        [DataMember(Name = "variations")]
        public List<Variation> Variations { get; set; } = new List<Variation>();

        [DataMember(Name = "relations")]
        public List<Relation> Relations { get; set; } = new List<Relation>();
    }
}
