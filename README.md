# toofz NecroDancer Core

[![Build status](https://ci.appveyor.com/api/projects/status/de1vj801al1krlfa/branch/master?svg=true)](https://ci.appveyor.com/project/leonard-thieu/toofz-necrodancer-core/branch/master)
[![codecov](https://codecov.io/gh/leonard-thieu/toofz-necrodancer-core/branch/master/graph/badge.svg)](https://codecov.io/gh/leonard-thieu/toofz-necrodancer-core)
[![MyGet](https://img.shields.io/myget/toofz/v/toofz.NecroDancer.svg)](https://www.myget.org/feed/toofz/package/nuget/toofz.NecroDancer)

**toofz NecroDancer Core** is a .NET library designed for parsing and editing **Crypt of the NecroDancer** files. 
The library supports `necrodancer.xml`, replays, and saves.

**toofz NecroDancer Core** is a component of [toofz](http://crypt.toofz.com/).
It powers the **Item** and **Enemy** sections of **toofz** through data mining. 
It also provides richer leaderboard entry data by parsing replays associated with entries.

## Requirements

* [.NET Standard 1.3](https://github.com/dotnet/standard/blob/master/docs/versions.md)-compatible platform
  * .NET Core 1.0
  * .NET Framework 4.6
  * Mono 4.6

## Usage

### [Data API](toofz.NecroDancer/Data) (`necrodancer.xml`)

Reading `necrodancer.xml`:

```csharp
var necrodancerXmlPath = @"C:\Program Files\Steam\steamapps\common\Crypt of the NecroDancer\data\necrodancer.xml";
using (var fs = File.OpenRead(necrodancerXmlPath))
{
    var serializer = new NecroDancerDataSerializer();
    NecroDancerData data = serializer.Deserialize(fs);
    // ...
}
```

### [Replays API](toofz.NecroDancer/Replays)

Reading a replay:

```csharp
using (var fs = File.OpenRead(replayPath))
{
    var serializer = new ReplayDataSerializer();
    ReplayData replayData = serializer.Deserialize(fs);
    // ...
}

```

### [Saves API](toofz.NecroDancer/Saves)

```csharp
using (var fs = File.OpenRead(saveDataPath))
{
    var serializer = new SaveDataSerializer();
    var saveData = serializer.Deserialize(fs);
    // ...
}
```

## License

**toofz NecroDancer Core** is released under the [MIT License](LICENSE).
