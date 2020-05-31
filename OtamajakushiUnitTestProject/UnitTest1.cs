using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Otamajakushi;

namespace OtamajakushiUnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// 読み込みテスト
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            var dictionary = OneToManyJsonSerializer.Deserialize(File.ReadAllText(@".\..\..\test.json"));
            Assert.AreEqual(1, dictionary.Words.Count);
            Assert.AreEqual("lipalain", dictionary.Words[0].Entry.Form);
            Assert.AreEqual("【名詞】lipalainerfemo リパライン語化する\nlipalain chafi'ofes　リパラオネ共和国",
                dictionary.Words[0].Contents.Find(x => x.Title == "語法").Text);
        }

        /// <summary>
        /// 書き込みテスト
        /// </summary>
        [TestMethod]
        public void TestMethod2()
        {
            var dictionary = OneToManyJsonSerializer.Deserialize(File.ReadAllText(@".\..\..\test.json"));
            var options = new System.Text.Json.JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                WriteIndented = true,
            };
            var json = OneToManyJsonSerializer.Serialize(dictionary, options);
            File.WriteAllText(@".\..\..\output.json", json);
        }

        /// <summary>
        /// 書き込んだファイルの読み込みテスト
        /// </summary>
        [TestMethod]
        public void TestMethod3()
        {
            var dictionary = OneToManyJsonSerializer.Deserialize(File.ReadAllText(@".\..\..\output.json"));
            Assert.AreEqual(1, dictionary.Words.Count);
            Assert.AreEqual("lipalain", dictionary.Words[0].Entry.Form);
            Assert.AreEqual("【名詞】lipalainerfemo リパライン語化する\nlipalain chafi'ofes　リパラオネ共和国",
                dictionary.Words[0].Contents.Find(x => x.Title == "語法").Text);
        }

        /// <summary>
        /// AddWord のテスト
        /// </summary>
        [TestMethod]
        public void TestMethod4()
        {
            var dictionary = OneToManyJsonSerializer.Deserialize(File.ReadAllText(@".\..\..\output.json"));
            dictionary.AddWord(new Word
            {
                Entry = new Entry
                {
                    Form = "test",
                },
            });
            Assert.AreEqual(2, dictionary.Words.Count);
            Assert.AreEqual(2, dictionary.Words[1].Entry.Id);
        }

        /// <summary>
        /// RelationIdCompletion のテスト
        /// </summary>
        [TestMethod]
        public void TestMethod5()
        {
            var dictionary = new OneToManyJson();
            dictionary.AddWord(new Word
            {
                Entry = new Entry
                {
                    Form = "いろはにほへと",
                },
                Relations = new List<Relation>
                {
                    new Relation
                    {
                        Title = "同義語",
                        Entry = new Entry
                        {
                            Form = "散りぬるを",
                        },
                    },
                },
            });
            dictionary.AddWord(new Word
            {
                Entry = new Entry
                {
                    Form = "散りぬるを",
                },
                Relations = new List<Relation>
                {
                    new Relation
                    {
                        Title = "対義語",
                        Entry = new Entry
                        {
                            Form = "いろはにほへと",
                        },
                    }
                },
            });
            dictionary.RelationIdCompletion();
            Assert.AreEqual(2, dictionary.Words[0].Relations[0].Entry.Id);
            Assert.AreEqual(1, dictionary.Words[1].Relations[0].Entry.Id);
            var options = new System.Text.Json.JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                WriteIndented = true,
            };
            var json = OneToManyJsonSerializer.Serialize(dictionary, options);
            File.WriteAllText(@".\..\..\output5.json", json);
        }
    }
}
