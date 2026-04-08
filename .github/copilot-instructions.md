# Copilot Instructions for nanoFramework CoreLibrary

## Repository Overview

This is the **Base Class Library (BCL)** for [.NET nanoFramework](https://www.nanoframework.net/) — a free, open-source platform that implements .NET for resource-constrained embedded devices (microcontrollers). The library produces `mscorlib.dll`, the core runtime library for nanoFramework, and is analogous to `System.Private.CoreLib` in full .NET.

The BCL is split into two NuGet packages:
- **`nanoFramework.CoreLibrary`** (`nanoFramework.CoreLibrary/` project) — includes `System.Reflection` API.
- **`nanoFramework.CoreLibrary.NoReflection`** (`nanoFramework.CoreLibrary.NoReflection/` project) — excludes `System.Reflection` to save flash space on constrained targets.

## Project System

- Projects use the **nanoFramework project system** with `.nfproj` file extension (not `.csproj`). The project type GUIDs are `{11A8DD76-328B-46DF-9F39-F559912D0360};{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}`.
- The solution file is `nanoFramework.CoreLibrary.sln`.
- The output assembly name is `mscorlib` (set via `<AssemblyName>mscorlib</AssemblyName>` and `<IsMscorlib>true</IsMscorlib>`).
- The target framework version is `v1.0` (nanoFramework's own TFM, not standard .NET).
- This is a **core assembly** (`<IsCoreAssembly>true</IsCoreAssembly>` and `<NF_IsCoreLibrary>True</NF_IsCoreLibrary>`), meaning it has no external managed dependencies.

## Key Conventions

### Native Calls
Many methods are implemented natively in the nanoFramework C++ runtime (nanoCLR). These are declared with `extern` and `[MethodImpl(MethodImplOptions.InternalCall)]`:

```csharp
using System.Runtime.CompilerServices;

[MethodImpl(MethodImplOptions.InternalCall)]
public static extern bool Equals(String a, String b);
```

When implementing new methods that require native support, mark them with `[MethodImpl(MethodImplOptions.InternalCall)]` and `extern`. The native counterpart must be implemented in the [nf-interpreter](https://github.com/nanoframework/nf-interpreter) repository.

### Reflection Conditional Compilation
Code that depends on reflection must be wrapped with `#if NANOCLR_REFLECTION`:

```csharp
#if NANOCLR_REFLECTION
[DebuggerDisplay("Count = {Count}")]
#endif // NANOCLR_REFLECTION
```

The `NANOCLR_REFLECTION` constant is defined in the `nanoFramework.CoreLibrary` project but **not** in `nanoFramework.CoreLibrary.NoReflection`.

### Namespace Layout
- Source files live under `nanoFramework.CoreLibrary/System/` and `nanoFramework.CoreLibrary.NoReflection/System/`, mirroring the `System` namespace hierarchy.
- Sub-namespaces map to subdirectories: `Collections/`, `Threading/`, `Reflection/`, `Diagnostics/`, `Globalization/`, `IO/`, `Runtime/CompilerServices/`, etc.

### XML Documentation
All public APIs must have complete XML documentation comments (`<summary>`, `<param>`, `<returns>`, `<exception>`, etc.). Keep them concise; avoid adding message strings to exceptions to preserve assembly/memory size. Example:

```csharp
// (no message to preserve assembly size/memory consumption)
throw new NotSupportedException();
```

### License Header
Every source file starts with:

```csharp
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
```

### Pragma Suppression
Some `#pragma warning disable/restore` directives for CS0659, CS0661, and S1206 (SonarAnalyzer) are used where native implementations handle `GetHashCode`. Follow this pattern when adding types that have native hash code support.

## Building

Build uses **Azure Pipelines** (`azure-pipelines.yml`), not GitHub Actions. The only GitHub Actions workflow is `generate-changelog.yml`, which triggers on version tags.

For local builds:
- Install the **nanoFramework Visual Studio extension** which brings the nanoFramework project system and `MSBuildExtensionsPath\nanoFramework\v1.0\`.
- Open `nanoFramework.CoreLibrary.sln` in Visual Studio (Windows only).
- Restore NuGet packages before building.
- The pipeline uses `windows-latest` and references the shared [nf-tools](https://github.com/nanoframework/nf-tools) template library.
- Versioning is managed by **Nerdbank.GitVersioning** (`version.json`); the current version prefix is `1.17`.
- The assembly is strong-named using `key.snk`.

## Testing

### Framework
Tests use the [nanoFramework.TestFramework](https://github.com/nanoframework/nanoFramework.TestFramework) (included as a git submodule at `nanoFramework.TestFramework/`). Tests run on the **nanoCLR Win32 emulator** (no real hardware required by default).

### Test Layout
- All test projects live under `Tests/`, one project per test area (e.g., `Tests/NFUnitTestSystemLib/`, `Tests/NFUnitTestArray/`, etc.).
- Test class files are named `UnitTest<Feature>.cs`.
- Each test class uses `[TestClass]` and each test method uses `[TestMethod]`.
- Data-driven tests use `[DataRow(...)]`.

### Critical Setup for Test Projects
Because this repository IS the core library, test projects must use **project references** instead of NuGet references for:
1. `mscorlib` (this repo)
2. `nanoFramework.TestFramework`
3. `nanoFramework.UnitTestLauncher`

Do **not** add NuGet references for these three; reference the submodule/project directly.

Each test subdirectory needs a `nano.runsettings` file. The root `.runsettings` configures the emulator run:
```xml
<nanoFrameworkAdapter>
    <Logging>Verbose</Logging>
    <IsRealHardware>False</IsRealHardware>
    <RunnerExtraArguments> --forcegc </RunnerExtraArguments>
</nanoFrameworkAdapter>
```

### Running Tests from Command Line
Use the `Developer Command Prompt for VS 2019` (or 2022):
```cmd
vstest.console.exe .\Tests\NFUnitTestBitConverter\bin\Release\NFUnitTest.dll \
  /Settings:.\Tests\NFUnitTestAdapater\nano.runsettings \
  /TestAdapterPath:.\nanoFramework.TestFramework\source\TestAdapter\bin\Debug\net4.8 \
  /Diag:.\log.txt /Logger:trx
```

Note: The `NFUnitTestAdapter` project (in `Tests/`) must remain untouched — it provides the core nanoCLR Win32 executable needed by the test adapter.

### Test Coverage Requirements
**All new code must include tests** covering:
- All public methods and properties
- All events (where applicable)
- All documented exceptions
- Do not introduce more test failures than already exist.

## Repository Structure Summary

```
nanoFramework.CoreLibrary/        # Main BCL project (with reflection)
  System/                         # Source files mirroring System namespace
nanoFramework.CoreLibrary.NoReflection/  # BCL without reflection
  System/                         # Source files (subset, no Reflection/)
Tests/
  NFUnitTest<Area>/               # One test project per feature area
  TestFramework/                  # Test framework source (submodule)
  UnitTestLauncher/               # Launcher project (submodule)
nanoFramework.TestFramework/      # Git submodule: test framework source
azure-pipelines/                  # Pipeline template overrides
azure-pipelines.yml               # Main CI pipeline (Azure DevOps)
nanoFramework.CoreLibrary.sln     # Main solution
nanoFramework.CoreLibrary.nuspec  # NuGet packaging spec
version.json                      # Nerdbank.GitVersioning config
.runsettings                      # Root test run settings
```

## Common Pitfalls

1. **Do not use `System.Span<T>`** — only `SpanByte` (a custom byte-only span) is supported due to embedded constraints.
2. **No LINQ, no async/await** — these are not supported in nanoFramework.
3. **Memory is precious** — avoid string allocations in exception messages, prefer no-argument exception constructors.
4. **NoReflection parity** — any new managed (non-reflection) API added to `nanoFramework.CoreLibrary` must also be added to `nanoFramework.CoreLibrary.NoReflection` unless it inherently requires reflection.
5. **Strong naming** — the assembly must be signed with `key.snk`; do not remove or replace the key file.
6. **`[Reflection.FieldNoReflection]`** — fields that must not be exposed via reflection (e.g., native object handles) use this attribute.

## Known Errors & Workarounds

- **`NFProjectSystem.Default.props` not found**: Occurs when the nanoFramework VS extension is not installed or `MSBuildExtensionsPath` is not set. Install the [nanoFramework VS extension](https://marketplace.visualstudio.com/items?itemName=nanoframework.nanoFramework-VS2022-Extension) and build within Visual Studio.
- **Test NuGet conflicts**: If you see "could not find mscorlib" during test runs, ensure test projects use project references (not NuGet) for mscorlib, TestFramework, and UnitTestLauncher. Check the `.nfproj` `<Reference>` vs `<ProjectReference>` items.
- **Device firmware mismatch**: When running on real hardware, flash the device with the firmware built from this source to ensure the native checksum matches. The pipeline embeds the native version checksum in the NuGet package description.
