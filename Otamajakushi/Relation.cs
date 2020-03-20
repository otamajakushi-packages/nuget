using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Otamajakushi
{
    [DataContract]
    public class Relation
    {
        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "entry")]
        public Entry Entry { get; set; } = new Entry();
    }
}
