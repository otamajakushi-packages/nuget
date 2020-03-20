using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Otamajakushi
{
    [DataContract]
    public class Entry
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "form")]
        public string Form { get; set; }
    }
}
