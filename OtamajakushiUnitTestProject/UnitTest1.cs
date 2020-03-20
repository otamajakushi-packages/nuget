using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Otamajakushi;

namespace OtamajakushiUnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var dictionary = OneToManyJsonSerializer.Deserialize(File.ReadAllText(@".\..\..\test.json"));
            File.WriteAllText(@".\..\..\output.json", OneToManyJsonSerializer.Serialize(dictionary));
            Assert.AreEqual(1, dictionary.Words.Count);
        }
    }
}
