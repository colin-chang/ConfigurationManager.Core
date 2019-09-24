# ConfigurationHelper.Core
A configuration reader for .NET Core Application.

**Nuget**
```sh
# Package Manager
Install-Package ColinChang.ConfigurationManager.Core

# .NET CLI
dotnet add package ColinChang.ConfigurationManager.Core
```

**Configuration Supported**
* CommandLine
* InMemoryCollection
* Json file named `appsettings.json`
* Reload on change automatically

All of the knowledge of the package is based on https://netcore.colinchang.net/pages/config.html 

**Requirements**
* .Net Core 2.2 or newer
* Only support `appsettings.json` by current version

About how to use this,please check the [sample project](https://github.com/colin-chang/ConfigurationHelper.Core/tree/master/ColinChang.ConfigurationHelper.Sample).
