using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Otamajakushi.OtmJson
{
    public class Translation
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("forms")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2227: Collection properties should be read only")]
        public List<string> Forms { get; set; } = new List<string>();

        public static bool operator ==(Translation l, Translation r)
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

        public static bool operator !=(Translation l, Translation r)
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
            => obj is Translation t &&
            Title == t.Title &&
            Forms.Count == Forms.Union(t.Forms).Distinct().Count();

        public override int GetHashCode()
            => Title.GetHashCode() ^ Forms.Select(f => f.GetHashCode()).Aggregate((now, next) => now ^ next);
    }
}
