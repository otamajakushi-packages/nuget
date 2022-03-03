using System.Text.Json.Serialization;

namespace Otamajakushi.OtmJson
{
    public class Content
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }

        public static bool operator ==(Content l, Content r)
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

        public static bool operator !=(Content l, Content r)
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
            => obj is Content content &&
            Title == content.Title &&
            Text == content.Text;

        public override int GetHashCode()
            => Title.GetHashCode() ^ Text.GetHashCode();
    }
}
