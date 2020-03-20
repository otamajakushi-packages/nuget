using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Otamajakushi
{

    [DataContract]
    public class Translation
    {
        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "forms")]
        public List<string> Forms { get; set; } = new List<string>();
    }
}
