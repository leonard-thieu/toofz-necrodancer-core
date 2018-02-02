# toofz NecroDancer Core

[![Build status](https://ci.appveyor.com/api/projects/status/de1vj801al1krlfa/branch/master?svg=true)](https://ci.appveyor.com/project/leonard-thieu/toofz-necrodancer-core/branch/master)
[![codecov](https://codecov.io/gh/leonard-thieu/toofz-necrodancer-core/branch/master/graph/badge.svg)](https://codecov.io/gh/leonard-thieu/toofz-necrodancer-core)
[![MyGet](https://img.shields.io/myget/toofz/v/toofz.NecroDancer.svg)](https://www.myget.org/feed/toofz/package/nuget/toofz.NecroDancer)

## Overview

**toofz NecroDancer Core** is a .NET library designed for parsing and editing **Crypt of the NecroDancer** files. 
The library supports `necrodancer.xml`, replays, and saves.

---

**toofz NecroDancer Core** is a component of **toofz**. 
Information about other projects that support **toofz** can be found in the [meta-repository](https://github.com/leonard-thieu/toofz-necrodancer).

## Description

toofz NecroDancer Core supports reading and modifying `necrodancer.xml`, replays, and saves.
It powers the **Item** and **Enemy** sections of **toofz** through data mining. 
It also provides richer leaderboard entry data by parsing replays associated with entries.

## Installing via NuGet

Add a NuGet.Config to your solution directory with the following content:

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageSources>
    <add key="toofz" value="https://www.myget.org/F/toofz/api/v3/index.json" />
  </packageSources>
</configuration>
```

```powershell
Install-Package 'toofz.NecroDancer'
```

### Dependents

* [toofz Data](https://github.com/leonard-thieu/toofz-data)
* [toofz Replays Service](https://github.com/leonard-thieu/replays-service)
* [toofz API](https://github.com/leonard-thieu/api.toofz.com)

### Dependencies

* [toofz Build](https://github.com/leonard-thieu/toofz-build)

## Requirements

* [.NET Standard 1.3](https://github.com/dotnet/standard/blob/master/docs/versions.md)-compatible platform
  * .NET Core 1.0
  * .NET Framework 4.6
  * Mono 4.6

## Usage

### [Data API](src/toofz.NecroDancer/Data) (`necrodancer.xml`)

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

### [Replays API](src/toofz.NecroDancer/Replays)

Reading a replay:

```csharp
using (var fs = File.OpenRead(replayPath))
{
    var serializer = new ReplayDataSerializer();
    ReplayData replayData = serializer.Deserialize(fs);
    // ...
}

```

### [Saves API](src/toofz.NecroDancer/Saves)

Reading a save:

```csharp
using (var fs = File.OpenRead(saveDataPath))
{
    var serializer = new SaveDataSerializer();
    SaveData saveData = serializer.Deserialize(fs);
    // ...
}
```

## Contributing

Contributions are welcome for toofz NecroDancer Core.

* Want to report a bug or request a feature? [File a new issue](https://github.com/leonard-thieu/toofz-necrodancer-core/issues).
* Join in design conversations.
* Fix an issue or add a new feature.
  * Aside from trivial issues, please raise a discussion before submitting a pull request.

### Development

#### Requirements

* Visual Studio 2017

#### Getting started

Open the solution file and build. Use Test Explorer to run tests.

#### Repository layout

* [Data](src/toofz.NecroDancer/Data) - read and modify `necrodancer.xml`
* [Replays](src/toofz.NecroDancer/Replays) - read and modify replays
* [Saves](src/toofz.NecroDancer/Saves) - read and modify save data

## License

**toofz NecroDancer Core** is released under the [MIT License](LICENSE).
