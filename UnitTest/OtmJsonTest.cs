using System.IO;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Otamajakushi.OtmJson;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class OtmJsonTest
    {
        readonly OtmJson dictionary = OtmJsonSerializer.Deserialize(File.ReadAllText(@"../../../../samples/sample.otm.json"));

        [TestMethod]
        public void WordTest()
        {
            Assert.AreEqual(8, dictionary.Words.Count);
            foreach (var word in dictionary.Words)
            {
                Assert.IsNotNull(word.Entry);
                Assert.IsNotNull(word.Translations);
                Assert.IsNotNull(word.Tags);
                Assert.IsNotNull(word.Contents);
                Assert.IsNotNull(word.Variations);
                Assert.IsNotNull(word.Relations);
            }
        }

        [TestMethod]
        public void EntryTest()
        {
            var ids = new List<int> { 3, 6, 4, 5, 2, 1, 7, 8 };
            var forms = new List<string> { "+", ",", "-", ".", "<", ">", "[", "]" };
            foreach (var (item, index) in dictionary.Words.Select((item, index) => (item, index)))
            {
                Assert.AreEqual(ids[index], item.Entry.Id);
                Assert.AreEqual(forms[index], item.Entry.Form);
            }
        }

        [TestMethod]
        public void TranslationsTest()
        {
            foreach (var word in dictionary.Words)
            {
                Assert.IsNotNull(word.Translations);
                Assert.AreEqual(1, word.Translations.Count);
                Assert.AreEqual("\u52d5\u8a5e", word.Translations[0].Title);
            }
            Assert.AreEqual("\u30dd\u30a4\u30f3\u30bf\u306e\u5024\u3092\u30a4\u30f3\u30af\u30ea\u30e1\u30f3\u30c8\u3059\u308b", dictionary.Words[0].Translations[0].Forms[0]);
            Assert.AreEqual("\u5165\u529b\u304b\u30891\u30d0\u30a4\u30c8\u8aad\u307f\u8fbc\u3093\u3067", dictionary.Words[1].Translations[0].Forms[0]);
            Assert.AreEqual("\u30dd\u30a4\u30f3\u30bf\u304c\u6307\u3059\u5024\u306b\u4ee3\u5165\u3059\u308b", dictionary.Words[1].Translations[0].Forms[1]);
            Assert.AreEqual("\u30dd\u30a4\u30f3\u30bf\u306e\u5024\u3092\u30c7\u30af\u30ea\u30e1\u30f3\u30c8\u3059\u308b", dictionary.Words[2].Translations[0].Forms[0]);
            Assert.AreEqual("\u30dd\u30a4\u30f3\u30bf\u306e\u5024\u3092\u51fa\u529b\u3059\u308b", dictionary.Words[3].Translations[0].Forms[0]);
            Assert.AreEqual("\u30dd\u30a4\u30f3\u30bf\u3092\u30c7\u30af\u30ea\u30e1\u30f3\u30c8\u3059\u308b", dictionary.Words[4].Translations[0].Forms[0]);
            Assert.AreEqual("\u30dd\u30a4\u30f3\u30bf\u3092\u30a4\u30f3\u30af\u30ea\u30e1\u30f3\u30c8\u3059\u308b", dictionary.Words[5].Translations[0].Forms[0]);
            Assert.AreEqual("\u30dd\u30a4\u30f3\u30bf\u306e\u5024\u304c0\u306a\u3089\u3070", dictionary.Words[6].Translations[0].Forms[0]);
            Assert.AreEqual("\u5bfe\u5fdc\u3059\u308b ] \u306e\u76f4\u5f8c\u306b\u30b8\u30e3\u30f3\u30d7\u3059\u308b", dictionary.Words[6].Translations[0].Forms[1]);
            Assert.AreEqual("\u30dd\u30a4\u30f3\u30bf\u304c\u6307\u3059\u5024\u304c0\u3067\u306a\u3044\u306a\u3089", dictionary.Words[7].Translations[0].Forms[0]);
            Assert.AreEqual("\u5bfe\u5fdc\u3059\u308b [ \u306b\u30b8\u30e3\u30f3\u30d7\u3059\u308b\u3002", dictionary.Words[7].Translations[0].Forms[1]);
        }

        [TestMethod]
        public void TagsTest()
        {
            foreach (var word in dictionary.Words)
            {
                Assert.IsNotNull(word.Tags);
                Assert.AreEqual(1, word.Tags.Count);
                Assert.AreEqual("\u547d\u4ee4", word.Tags[0]);
            }
        }

        [TestMethod]
        public void ContentsTest()
        {
            foreach (var word in dictionary.Words)
            {
                Assert.IsNotNull(word.Contents);
                Assert.AreEqual("C\u8a00\u8a9e", word.Contents[0].Title);
            }
            var texts = new List<string> {
                "C\u8a00\u8a9e\u3067 (*ptr)++; \u306b\u76f8\u5f53\u3059\u308b\u3002",
                "C\u8a00\u8a9e\u3067 *ptr=getchar(); \u306b\u76f8\u5f53\u3059\u308b\u3002",
                "C\u8a00\u8a9e\u3067 (*ptr)--; \u306b\u76f8\u5f53\u3059\u308b\u3002",
                "C\u8a00\u8a9e\u3067 putchar(*ptr); \u306b\u76f8\u5f53\u3059\u308b\u3002",
                "C\u8a00\u8a9e\u3067 ptr--; \u306b\u76f8\u5f53\u3059\u308b\u3002",
                "C\u8a00\u8a9e\u3067 ptr++; \u306b\u76f8\u5f53\u3059\u308b\u3002",
                "C\u8a00\u8a9e\u306e while(*ptr){ \u306b\u76f8\u5f53\u3059\u308b\u3002",
                "C\u8a00\u8a9e\u3067 } \u306b\u76f8\u5f53\u3059\u308b\u3002",
            };
            foreach (var (item, index) in dictionary.Words.Select((item, index) => (item, index)))
                Assert.AreEqual(texts[index], item.Contents[0].Text);
        }

        [TestMethod]
        public void VariationsTest()
        {
            foreach (var word in dictionary.Words)
            {
                Assert.IsNotNull(word.Variations);
                Assert.AreEqual(0, word.Variations.Count);
            }
        }

        [TestMethod]
        public void RelationsTest()
        {
            foreach (var word in dictionary.Words)
            {
                Assert.IsNotNull(word.Relations);
                Assert.AreEqual(1, word.Relations.Count);
                foreach (var relation in word.Relations)
                {
                    var excepted = dictionary.Words.Find(word2 => word2.Entry.Id == relation.Entry.Id);
                    Assert.AreEqual(excepted.Entry, relation.Entry);
                    Assert.AreEqual("\u5bfe\u7fa9\u8a9e", relation.Title);
                }
            }
        }

        [TestMethod]
        public void SerializeAndDeserializeTest()
        {
            var options = new System.Text.Json.JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                WriteIndented = true,
            };
            var json = OtmJsonSerializer.Serialize(dictionary, options);
            var overwritten = OtmJsonSerializer.Deserialize(json);
            CollectionAssert.AreEqual(dictionary.Words, overwritten.Words);
        }

        [TestMethod]
        public void AddWordTest()
        {
            var dictionary = OtmJsonSerializer.Deserialize(File.ReadAllText(@"../../../../samples/sample.otm.json"));
            dictionary.AddWord(new Word
            {
                Entry = new Entry
                {
                    Form = "test",
                },
            });
            Assert.AreEqual(9, dictionary.Words.Count);
            Assert.AreEqual(9, dictionary.Words[8].Entry.Id);
        }

        [TestMethod]
        public void EqualTest()
        {
            var same = OtmJsonSerializer.Deserialize(File.ReadAllText(@"../../../../samples/sample.otm.json"));
            foreach (var (excepted, actual) in dictionary.Words.Zip(same.Words, (excepted, acutual) => (excepted, acutual)))
            {
                Assert.AreEqual(excepted.Entry, actual.Entry);
                Assert.AreEqual(excepted.Translations[0], actual.Translations[0]);
                Assert.AreEqual(excepted.Tags[0], actual.Tags[0]);
                Assert.AreEqual(excepted.Contents[0], actual.Contents[0]);
                Assert.AreEqual(excepted, actual);
            }
        }
    }
}
