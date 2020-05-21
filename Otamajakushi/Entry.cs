using System.Text.Json.Serialization;

namespace Otamajakushi
{
    public class Entry
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("form")]
        public string Form { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Entry entry &&
                   Id == entry.Id &&
                   Form == entry.Form;
        }

        public static bool operator ==(Entry l, Entry r)
        {
            return l.Equals(r);
        }

        public static bool operator !=(Entry l, Entry r)
        {
            return !l.Equals(r);
        }
    }
}
