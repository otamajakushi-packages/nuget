using System.Text.Json.Serialization;

namespace Otamajakushi.OtmJson
{
    public class Relation
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("entry")]
        public Entry Entry { get; set; } = new Entry();

        public static bool operator ==(Relation l, Relation r)
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

        public static bool operator !=(Relation l, Relation r)
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
            => obj is Relation relation &&
            Title == relation.Title &&
            Entry == relation.Entry;

        public override int GetHashCode()
            => Title.GetHashCode() ^ Entry.GetHashCode();
    }
}
