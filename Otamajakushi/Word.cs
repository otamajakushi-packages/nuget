using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Otamajakushi
{
    public class Word
    {
        [JsonPropertyName("entry")]
        public Entry Entry { get; set; } = new Entry();

        [JsonPropertyName("translations")]
        public List<Translation> Translations { get; set; } = new List<Translation>();

        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; }

        [JsonPropertyName("contents")]
        public List<Content> Contents { get; set; } = new List<Content>();

        [JsonPropertyName("variations")]
        public List<Variation> Variations { get; set; } = new List<Variation>();

        [JsonPropertyName("relations")]
        public List<Relation> Relations { get; set; } = new List<Relation>();

        public static bool operator ==(Word l, Word r)
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

        public static bool operator !=(Word l, Word r)
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
            => obj is Word w &&
            Entry == w.Entry &&
            Translations.Count == Translations.Union(w.Translations).Distinct().Count() &&
            Tags.Count == Tags.Union(w.Tags).Distinct().Count() &&
            Contents.Count == Contents.Union(w.Contents).Distinct().Count() &&
            Relations.Count == Relations.Union(w.Relations).Distinct().Count();

        public override int GetHashCode()
            => Entry.GetHashCode() ^
            Translations.Select(x => x.GetHashCode()).Aggregate((now, next) => now ^ next) ^
            Tags.Select(x => x.GetHashCode()).Aggregate((now, next) => now ^ next) ^
            Contents.Select(x => x.GetHashCode()).Aggregate((now, next) => now ^ next) ^
            Relations.Select(x => x.GetHashCode()).Aggregate((now, next) => now ^ next);
    }
}
