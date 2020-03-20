using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Otamajakushi
{
    [DataContract]
    public class Content
    {
        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "text")]
        public string Text { get; set; }
    }
}
