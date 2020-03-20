using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text.Json;

namespace Otamajakushi
{
    [DataContract]
    public class OneToManyJson
    {
        [DataMember(Name = "words")]
        public List<Word> Words { get; set; } = new List<Word>();

        [DataMember(Name = "zpdic")]
        public Zpdic Zpdic { get; set; }
    }
}
