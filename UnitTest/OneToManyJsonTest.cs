using System.IO;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Otamajakushi;

namespace UnitTest
{
    [TestClass]
    public class OneToManyJsonTest
    {
        readonly OneToManyJson dictionary = OneToManyJsonSerializer.Deserialize(File.ReadAllText(@"../../../../samples/sample.otm.json"));

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
            Assert.AreEqual(3, dictionary.Words[0].Entry.Id);
            Assert.AreEqual(6, dictionary.Words[1].Entry.Id);
            Assert.AreEqual(4, dictionary.Words[2].Entry.Id);
            Assert.AreEqual(5, dictionary.Words[3].Entry.Id);
            Assert.AreEqual(2, dictionary.Words[4].Entry.Id);
            Assert.AreEqual(1, dictionary.Words[5].Entry.Id);
            Assert.AreEqual(7, dictionary.Words[6].Entry.Id);
            Assert.AreEqual(8, dictionary.Words[7].Entry.Id);
            Assert.AreEqual("+", dictionary.Words[0].Entry.Form);
            Assert.AreEqual(",", dictionary.Words[1].Entry.Form);
            Assert.AreEqual("-", dictionary.Words[2].Entry.Form);
            Assert.AreEqual(".", dictionary.Words[3].Entry.Form);
            Assert.AreEqual("<", dictionary.Words[4].Entry.Form);
            Assert.AreEqual(">", dictionary.Words[5].Entry.Form);
            Assert.AreEqual("[", dictionary.Words[6].Entry.Form);
            Assert.AreEqual("]", dictionary.Words[7].Entry.Form);
        }

        [TestMethod]
        public void TranslationsTest()
        {
            foreach (var word in dictionary.Words)
            {
                Assert.IsNotNull(word.Translations);
                Assert.AreEqual(1, word.Translations.Count);
                Assert.AreEqual("動詞", word.Translations[0].Title);
            }
            Assert.AreEqual("ポインタの値をインクリメントする", dictionary.Words[0].Translations[0].Forms[0]);
            Assert.AreEqual("入力から1バイト読み込んで", dictionary.Words[1].Translations[0].Forms[0]);
            Assert.AreEqual("ポインタが指す値に代入する", dictionary.Words[1].Translations[0].Forms[1]);
            Assert.AreEqual("ポインタの値をデクリメントする", dictionary.Words[2].Translations[0].Forms[0]);
            Assert.AreEqual("ポインタの値を出力する", dictionary.Words[3].Translations[0].Forms[0]);
            Assert.AreEqual("ポインタをデクリメントする", dictionary.Words[4].Translations[0].Forms[0]);
            Assert.AreEqual("ポインタをインクリメントする", dictionary.Words[5].Translations[0].Forms[0]);
            Assert.AreEqual("ポインタの値が0ならば", dictionary.Words[6].Translations[0].Forms[0]);
            Assert.AreEqual("対応する ] の直後にジャンプする", dictionary.Words[6].Translations[0].Forms[1]);
            Assert.AreEqual("ポインタが指す値が0でないなら", dictionary.Words[7].Translations[0].Forms[0]);
            Assert.AreEqual("対応する [ にジャンプする。", dictionary.Words[7].Translations[0].Forms[1]);
        }

        [TestMethod]
        public void TagsTest()
        {
            foreach (var word in dictionary.Words)
            {
                Assert.IsNotNull(word.Tags);
                Assert.AreEqual(1, word.Tags.Count);
                Assert.AreEqual("命令", word.Tags[0]);
            }
        }


        [TestMethod]
        public void ContentsTest()
        {
            foreach (var word in dictionary.Words)
            {
                Assert.IsNotNull(word.Contents);
                Assert.AreEqual("C言語", word.Contents[0].Title);
            }
            Assert.AreEqual("C言語で (*ptr)++; に相当する。", dictionary.Words[0].Contents[0].Text);
            Assert.AreEqual("C言語で *ptr=getchar(); に相当する。", dictionary.Words[1].Contents[0].Text);
            Assert.AreEqual("C言語で (*ptr)--; に相当する。", dictionary.Words[2].Contents[0].Text);
            Assert.AreEqual("C言語で putchar(*ptr); に相当する。", dictionary.Words[3].Contents[0].Text);
            Assert.AreEqual("C言語で ptr--; に相当する。", dictionary.Words[4].Contents[0].Text);
            Assert.AreEqual("C言語で ptr++; に相当する。", dictionary.Words[5].Contents[0].Text);
            Assert.AreEqual("C言語の while(*ptr){ に相当する。", dictionary.Words[6].Contents[0].Text);
            Assert.AreEqual("C言語で } に相当する。", dictionary.Words[7].Contents[0].Text);
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
                    Assert.AreEqual("対義語", relation.Title);
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
            var json = OneToManyJsonSerializer.Serialize(dictionary, options);
            var overwritten = OneToManyJsonSerializer.Deserialize(json);
            CollectionAssert.AreEqual(dictionary.Words, overwritten.Words);
        }

        [TestMethod]
        public void AddWordTest()
        {
            var dictionary = OneToManyJsonSerializer.Deserialize(File.ReadAllText(@"../../../../samples/sample.otm.json"));
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
            var same = OneToManyJsonSerializer.Deserialize(File.ReadAllText(@"../../../../samples/sample.otm.json"));
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
