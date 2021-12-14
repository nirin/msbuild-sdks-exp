# MSBuild.Project.Sdk

## Summary

Supports creating projects that do not compile to an assembly.
This is usually the base SDK for other SDKs in this repository.

### Package Name: `MSBuild.Project.Sdk`

[![MSBuild.Project.Sdk](https://img.shields.io/myget/msbuild-sdks/v/MSBuild.Project.Sdk?style=flat-square&logo=nuget)](https://myget.org/feed/msbuild-sdks/package/nuget/MSBuild.Project.Sdk)

### Getting started

Visual Studio v15.6+ includes support for SDK's resolved from NuGet.
That makes using the custom SDKs much easier.

See [Using MSBuild project SDKs][msbuild-sdk-usage] guide on [Microsoft Docs](https://docs.ms) for more information on how project SDKs work and [how project SDKs are resolved][msbuild-sdk-resolver].

[msbuild-sdk-usage]: https://docs.microsoft.com/visualstudio/msbuild/how-to-use-project-sdk
[msbuild-sdk-resolver]: https://docs.microsoft.com/visualstudio/msbuild/how-to-use-project-sdk#how-project-sdks-are-resolved

#### Using the SDK

1. Create a new project
    - from `dotnet new` templates.
    - With your existing SDK-style project.

2. Replace `Microsoft.NET.Sdk` with `MSBuild.Project.Sdk` in the project's top-level `Sdk` attribute.

3. You have to tell MSBuild that the `Sdk` should resolve from NuGet by
    - Adding a `global.json` containing the SDK name and version.
    - Appending a version info to the `Sdk` attribute value.

4. Remove the `TargetFramework(s)` and other .NET specific properties from the project file.
   Older versions of VS IDE might require `TargetFramework(s)` property to open the project in IDE successfully.

5. Then you can add custom properties, items, tasks and targets and use the project for various purposes other than building a .NET assembly.

The final project should look like this:

```xml
<Project Sdk="MSBuild.Project.Sdk" DefaultTargets="Greet">

    <PropertyGroup>
        <Greeting>Hello, World!</Greeting>
    </PropertyGroup>

    <Target Name="Greet">
      <Message Importance="High" Text="$(Greeting)"/>
    </Target>

</Project>
```

You can put the SDK version in the `global.json` file next to your solution:

```json
{
    "msbuild-sdks": {
        "MSBuild.Project.Sdk": "1.0.0"
    }
}
```

Then, all of your project files, from that directory forward, uses the version from the `global.json` file.
This would be a preferred solution for all the projects in your solution.

Then again, you might want to override the version for just one project **OR** if you have only one project in your solution (_without adding `global.json`_), you can do so like this:

```xml
<Project Sdk="MSBuild.Project.Sdk/1.0.0" DefaultTargets="Greet">

    <PropertyGroup>
        <Greeting>Hello, World!</Greeting>
    </PropertyGroup>

    <Target Name="Greet">
      <Message Importance="High" Text="$(Greeting)"/>
    </Target>

</Project>
```

That's it! You do not need to specify any default properties or items as they'll be automatically defined.
After that, you can use the `Greet` target to display the greeting message (_in my example_) **OR** roll your own targets to do things that you want: e.g., `msbuild -t:DoWork ...`.

#### Important to Note

- This SDK does not support Common Project System (**CPS**) protocol.
  As such, it may not open in Visual Studio and other IDEs that require it.
- But code editors such as Visual Studio Code and others will open the project without any issues as they (_OmniSharp_) don't require CPS.
