# Otamajakushi

![GitHub](https://img.shields.io/github/license/skytomo221/Otamajakushi)
![Nuget](https://img.shields.io/nuget/v/Otamajakushi)
![Nuget](https://img.shields.io/nuget/dt/Otamajakushi)

Otamajakushiは、OTM-JSON（OneToMany-JSON）を解析するライブラリです。

## OTM-JSONファイルの読み込み

```cs
using System.IO;
using Otamajakushi;

namespace ConsoleApp
{
    public class ConsoleApp
    {
        public void Program()
        {
            var json = File.ReadAllText(@"input.json");
            var dictionary = OneToManyJsonSerializer.Deserialize(json);
        }
    }
}
```

## OTM-JSONファイルの書き込み

```cs
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using Otamajakushi;

namespace ConsoleApp
{
    public class ConsoleApp
    {
        public void Program()
        {
            var dictionary = new OneToManyJson();
            var options = new System.Text.Json.JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                WriteIndented = true,
            };
            var json = OneToManyJsonSerializer.Serialize(dictionary, options);
            File.WriteAllText(@"output.json", json);
        }
    }
}
```
