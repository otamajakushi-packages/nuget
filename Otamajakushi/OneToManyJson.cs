using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Otamajakushi
{
    public class OneToManyJson
    {
        [JsonPropertyName("words")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2227: Collection properties should be read only")]
        public List<Word> Words { get; set; } = new List<Word>();

        [JsonPropertyName("zpdic")]
        public Zpdic Zpdic { get; set; }

        public void RelationIdCompletion()
        {
            foreach (var word in Words)
            {
                foreach (var relation in word.Relations)
                {
                    if (Words.Exists(w => w.Entry == relation.Entry)) { continue; }
                    if (Words.FindAll(w => w.Entry.Form == relation.Entry.Form).Count == 1)
                    {
                        relation.Entry.Id = Words.Find(w => w.Entry.Form == relation.Entry.Form).Entry.Id;
                    }
                }
            }
        }

        public void AddWord(Word word)
        {
            if (word == null) throw new ArgumentNullException(nameof(word));
            if (Words.Count == 0)
            {
                word.Entry.Id = 1;
            }
            else
            {
                if (!Words.Exists(w => w.Entry.Id == word.Entry.Id))
                {
                    word.Entry.Id = Words.Max(w => w.Entry.Id) + 1;
                }
            }
            word.Translations = word.Translations.Distinct().ToList();
            word.Tags = word.Tags.Distinct().ToList();
            word.Contents = word.Contents.Distinct().ToList();
            word.Variations = word.Variations.Distinct().ToList();
            word.Relations = word.Relations.Distinct().ToList();
            Words.Add(word);
        }
    }
}
