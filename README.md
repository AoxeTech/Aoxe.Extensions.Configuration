# Aoxe.Extensions.Configuration

The implementations for Microsoft.Extensions.Configuration, include several configuration sources and several parsers (Json / Xml / Ini / Toml / Yaml).

- [Aoxe.Extensions.Configuration](https://github.com/AoxeTech/Aoxe.Extensions.Configuration)
- [Aoxe.Extensions.Configuration.Consul](https://github.com/AoxeTech/Aoxe.Extensions.Configuration.Consul)
- [Aoxe.Extensions.Configuration.Etcd](https://github.com/AoxeTech/Aoxe.Extensions.Configuration.Etcd)
- [Aoxe.Extensions.Configuration.Redis](https://github.com/AoxeTech/Aoxe.Extensions.Configuration.Redis)

## Why

The Microsoft.Extensions.Configuration provide develops out of box and powerful configuration functions. It supports several formats (Json / Xml / Ini) to covers most usage scenarios. But still has some points I think it can be improved.

### The parser is the core function but hasn't been defined to public, this design affects modularity and reuse

Every configuration is base on its stream version with the same format, like JsonConfigurationProvider and JsonStreamConfigurationProvider etc. In the stream provider it use serializer to parse the structure stream into a Dictionary<string, string?>. But in these offical configuration providers the parser classes or functions were defined to internal or pravite.

### Maybe need other serializers

Like Microsoft.Extensions.Configuration.Json was base on System.Text.Json, it is a great package but someone prefer Newtonsoft.Json or other serializers with some reasons, and the Microsoft.Extensions.Configuration.NewtonsoftJson has been set to deprecate from 2020. And then in addition to Json / Xml / Ini, we may now need other configration formats like Toml / Yaml etc.

### Need different configuration sources

With the microservices and cloud, the Centralized Configuration will be more and more important. Microsoft has provided some Centralized Configuration sources for us, but they are usually based on azure. All the more reason to be cloud neutrality when cloud is so powerful, some projects and services prefer privately deployed key-value stores.

## What this project does

### Flantteners

For parser, Aoxe.Extensions.Configuration abstracts the concept called Flanttener to parse and flatten the stream into Dictionary<string, string?>. Then now we have the following implementations:

#### Aoxe.Extensions.Configuration.Flattener.Ini

Base on Microsoft.Extensions.Configuration.Ini and with the same behavior.

#### Aoxe.Extensions.Configuration.Flattener.IniParser

[ini-parser](https://github.com/rickyah/ini-parser) is A .NET, Mono and Unity3d compatible(*) library for reading/writing INI data from IO streams, file streams, and strings written in C#.

Also implements merging operations, both for complete ini files, sections, or even just a subset of the keys contained by the files.

(*) This library is 100% .NET code and does not have any dependencies on Windows API calls in order to be portable.

#### Aoxe.Extensions.Configuration.Flattener.Json

Base on Microsoft.Extensions.Configuration.Json and with the same behavior.

#### Aoxe.Extensions.Configuration.Flattener.NewtonsoftJson

[Newtonsoft.Json](https://github.com/JamesNK/Newtonsoft.Json) is a popular high-performance JSON framework for .NET. With this implement we can pass JsonSerializerSettings for cumstomize parsie.

#### Aoxe.Extensions.Configuration.Flattener.SharpYaml

[SharpYaml](https://github.com/xoofx/SharpYaml) is a .NET library that provides a YAML parser and serialization engine for .NET objects, compatible with CoreCLR.

#### Aoxe.Extensions.Configuration.Flattener.Tomlet

[Tomlet](https://github.com/SamboyCoding/Tomlet) is a Zero-Dependency, model-based TOML De/Serializer for .NET.

#### Aoxe.Extensions.Configuration.Flattener.Tomlyn

[Tomlyn](https://github.com/xoofx/Tomlyn) is a TOML parser, validator and authoring library for .NET Framework and .NET Core.

#### Aoxe.Extensions.Configuration.Flattener.Xml

Base on Microsoft.Extensions.Configuration.Xml and with the same behavior.

#### Aoxe.Extensions.Configuration.Flattener.YamlDotNet

[YamlDotNet](https://github.com/aaubry/YamlDotNet) is a .NET library for YAML. YamlDotNet provides low level parsing and emitting of YAML as well as a high level object model similar to XmlDocument. A serialization library is also included that allows to read and write objects from and to YAML streams.

### Difference Configuration sources

In addition to configuration files, modern services increasingly rely on centralized configuration. For this purpose there are these configuration sources:

#### [Aoxe.Extensions.Configuration](https://github.com/AoxeTech/Aoxe.Extensions.Configuration)

Because the abstractions of Flantten Aoxe.Extensions.Configuration support difference configuration files, like Json, Xml, Ini, Toml and Yaml.

#### [Aoxe.Extensions.Configuration.Consul](https://github.com/AoxeTech/Aoxe.Extensions.Configuration.Consul)

[Consul](https://www.consul.io/) is a service networking solution that provides a full-featured control plane with service discovery, configuration, and segmentation functionality. It is designed to make it easy to manage and secure service-to-service communication across distributed infrastructure.

#### [Aoxe.Extensions.Configuration.Etcd](https://github.com/AoxeTech/Aoxe.Extensions.Configuration.Etcd)

[Etcd](https://etcd.io/) is a distributed key-value store that provides a reliable way to store data across a cluster of machines. It is used to store configuration data, metadata, and other critical information that needs to be accessed by distributed systems.

#### [Aoxe.Extensions.Configuration.Redis](https://github.com/AoxeTech/Aoxe.Extensions.Configuration.Redis)

[Redis (Remote Dictionary Server)](https://redis.io/) is an open-source, in-memory data structure store that can be used as a database, cache, and message broker. It supports various data structures such as strings, hashes, lists, sets, sorted sets, bitmaps, hyperloglogs, and geospatial indexes.

### How to use

Taking Toml file configuration as an example, we now have a Toml file which named 'Test.toml' like below:

```toml
stringKey = "stringValue"
numberKey = 123
booleanKey = true
nullKey = ""  # TOML does not have a native null type, so we use an empty string

[nestedObject]
nestedStringKey = "nestedStringValue"
nestedNumberKey = 456
nestedBooleanKey = false
nestedNullKey = ""  # Again, using an empty string for null

arrayKey = ["arrayStringValue", 789, false, ""]

[[arrayKeyWithNestedObjects]]
arrayNestedObjectKey = "arrayNestedObjectValue"

# Date and time example
dateKey = 1979-05-27T07:32:00Z
```

And then can get this package via nuget.

```shell
PM> Install-Package Aoxe.Extensions.Configuration.Tomlyn
```

Now we can use it like this:

```csharp
var configurationBuilder = new ConfigurationBuilder();
configurationBuilder.AddTomlFile("./Test.toml");
IConfiguration configuration = configurationBuilder.Build();
var value = configuration["nestedObject:nestedStringKey"]; // The value is "nestedStringValue"
```

Thank`s for [JetBrains](https://www.jetbrains.com/) for the great support in providing assistance and user-friendly environment for my open source projects.

[![JetBrains](https://resources.jetbrains.com/storage/products/company/brand/logos/jb_beam.svg?_gl=1*f25lxa*_ga*MzI3ODk2MjY0LjE2NzA0NjY4MDQ.*_ga_9J976DJZ68*MTY4OTY4NzY5OS4zNC4xLjE2ODk2ODgwMDAuNTMuMC4w)](https://www.jetbrains.com/community/opensource/#support)