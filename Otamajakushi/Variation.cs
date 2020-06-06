using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Otamajakushi
{
    [DataContract]
    public class Variation
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("form")]
        public string Form { get; set; }

        public static bool operator ==(Variation l, Variation r)
        {
            if (l is null && r is null)
            {
                return true;
            }
            if (l is null || r is null)
            {
                return false;
            }
            return l.Equals(r);
        }

        public static bool operator !=(Variation l, Variation r)
        {
            if (l is null && r is null)
            {
                return false;
            }
            if (l is null || r is null)
            {
                return true;
            }
            return !l.Equals(r);
        }

        public override bool Equals(object obj)
            => obj is Variation v &&
            Title == v.Title &&
            Form == v.Form;

        public override int GetHashCode()
          => Title.GetHashCode() ^ Form.GetHashCode();
    }
}
