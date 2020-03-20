using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Otamajakushi
{
    [DataContract]
    public class Variation
    {
        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "form")]
        public string Form { get; set; }
    }
}
