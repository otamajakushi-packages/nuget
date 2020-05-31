# Otamajakushi

![GitHub](https://img.shields.io/github/license/skytomo221/Otamajakushi)
![Nuget](https://img.shields.io/nuget/v/Otamajakushi)
![Nuget](https://img.shields.io/nuget/dt/Otamajakushi)

Otamajakushiは、OTM-JSON（OneToMany-JSON）を解析するライブラリです。

## サンプルプログラム

### OTM-JSONファイルの読み込み

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

### OTM-JSONファイルの書き込み

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

### 単語の追加

```cs
namespace ConsoleApp
{
    public class ConsoleApp
    {
        public void Program()
        {
            var dictionary = new OneToManyJson();
            dictionary.AddWord(new Word
            {
                Entry = new Entry
                {
                    Form = "test",
                    // ID を指定しなかった場合は、デフォルトで 0 が設定されます。
                    // AddWordメソッドは、 ID が他の単語と重複している場合、自動的に ID を修正します。
                },
            });
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

### 関連語の自動修正

```cs
namespace ConsoleApp
{
    public class ConsoleApp
    {
        public void Program()
        {
            var dictionary = new OneToManyJson();
            dictionary.AddWord(new Word
            {
                Entry = new Entry
                {
                    Form = "大きい",
                },
                Relations = new List<Relation>
                {
                    new Relation
                    {
                        Title = "対義語",
                        Entry = new Entry
                        {
                            Form = "小さい",
                        },
                    },
                },
            });
            dictionary.AddWord(new Word
            {
                Entry = new Entry
                {
                    Form = "小さい",
                },
                Relations = new List<Relation>
                {
                    new Relation
                    {
                        Title = "対義語",
                        Entry = new Entry
                        {
                            Form = "大きい",
                        },
                    }
                },
            });
            dictionary.RelationIdCompletion();
            /* RelationIdCompletion メソッドで、 *
             * 関連語に ID を設定していなくても、  *
             * 自動的に ID を関連付けてくれます。  */
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
```

## Version

### Version 1.0.0

- Otamajakushi リリース

### Version 1.1.0

- ZpDIC 内で用いるデータがうまく扱えない問題を修正
- 自動でIDを振って、単語を追加する機能を追加
- 自動で関連語のIDを関連付ける機能を追加
