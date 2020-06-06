using System.Text.Json.Serialization;

namespace Otamajakushi
{
    public class Entry
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("form")]
        public string Form { get; set; }

        public static bool operator ==(Entry l, Entry r)
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

        public static bool operator !=(Entry l, Entry r)
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
            => obj is Entry entry &&
            Id == entry.Id &&
            Form == entry.Form;

        public override int GetHashCode()
            => Id.GetHashCode() ^ Form.GetHashCode();
    }
}
