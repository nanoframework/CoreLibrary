# Copilot Instructions for nanoFramework CoreLibrary

## Repository Overview

This repository contains the **Base Class Library (BCL)** for [.NET nanoFramework](https://www.nanoframework.net/) — a free, open-source platform that enables writing managed .NET code for embedded systems and microcontrollers. The BCL provides the core `System` namespace types and is the nanoFramework equivalent of `mscorlib`.

## Key Architectural Concepts

### This Is NOT Standard .NET
- The code targets embedded systems (MCUs) with severe memory and flash constraints.
- Many methods are implemented in native C++ ("native stubs") and are declared with `[MethodImpl(MethodImplOptions.InternalCall)]` — **do not add a body to these methods**.
- Some standard .NET APIs are intentionally unsupported (throw `NotSupportedException`) to preserve assembly/image size. Do not remove these stubs; they exist to satisfy interface contracts.
- The library targets `TargetFrameworkVersion v1.0` (the nanoFramework target, not desktop .NET).

### Two Library Flavours
| Project | Description | NuGet |
|---|---|---|
| `nanoFramework.CoreLibrary` | Full BCL **with** `System.Reflection` | `nanoFramework.CoreLibrary` |
| `nanoFramework.CoreLibrary.NoReflection` | BCL **without** reflection (smaller flash footprint) | `nanoFramework.CoreLibrary.NoReflection` |

Both produce an assembly named `mscorlib`. The no-reflection variant excludes files under `System/Reflection/` and sets no `NANOCLR_REFLECTION` define.

### Project File Format
Projects use `.nfproj` files (nanoFramework MSBuild project system), not standard `.csproj`. These require Visual Studio with the **nanoFramework VS extension** installed, or MSBuild with `NFProjectSystem.CSharp.targets`.

## Repository Structure

```
nanoFramework.CoreLibrary/       # Main BCL project (with reflection)
  System/                        # All System.* source files
    Collections/                 # IEnumerable, ArrayList, generic interfaces
    Diagnostics/                 # Debug, Debugger, attributes
    Globalization/               # CultureInfo, DateTimeFormatInfo, etc.
    IO/                          # IOException
    Reflection/                  # Assembly, MethodInfo, FieldInfo, etc.
    Runtime/                     # CompilerServices, InteropServices, Remoting
    Threading/                   # Thread, Monitor, Timer, WaitHandle, etc.
  CoreLibrary.nfproj
  Directory.Build.props

nanoFramework.CoreLibrary.NoReflection/   # BCL without reflection
  System/                        # Subset of System.* files (no Reflection/)
  CoreLibrary.NoReflection.nfproj

Tests/                           # Unit tests (one folder per test suite)
  NFUnitTestArithmetic/
  NFUnitTestArray/
  NFUnitTestBitConverter/
  NFUnitTestSystemLib/           # Covers most primitive types, strings, DateTime, etc.
  NFUnitTestThread/
  ... (21 test suites total)

nanoFramework.TestFramework/     # Git submodule: test framework source
azure-pipelines.yml              # CI/CD pipeline (Azure Pipelines, Windows)
nanoFramework.CoreLibrary.sln    # Main solution (library + tests)
nanoFramework.CoreLibrary.Benchmarks.sln  # Benchmarks solution
version.json                     # Nerdbank.GitVersioning configuration
```

## Build & Test

### Build Requirements
- **Windows only** — the nanoFramework build toolchain runs on Windows (Azure Pipelines uses `windows-latest`).
- Visual Studio 2022 with the nanoFramework VS extension, or MSBuild 17+.
- NuGet packages are restored automatically; `packages.lock.json` enforces locked restore in CI.

### Building
```powershell
# Restore NuGet packages first
nuget restore nanoFramework.CoreLibrary.sln

# Build the solution (Release)
msbuild nanoFramework.CoreLibrary.sln /p:Configuration=Release /p:Platform="Any CPU"

# Build only CoreLibrary (Debug)
msbuild nanoFramework.CoreLibrary\CoreLibrary.nfproj /p:Configuration=Debug
```

### Running Tests
Tests use the [nanoFramework.TestFramework](https://github.com/nanoframework/nanoFramework.TestFramework) with the **nanoCLR Win32 emulator** (no real hardware needed by default).

```powershell
# From Developer Command Prompt for VS 2022:
vstest.console.exe .\Tests\NFUnitTestBitConverter\bin\Release\NFUnitTest.dll ^
  /Settings:.\.runsettings ^
  /TestAdapterPath:.\nanoFramework.TestFramework\source\TestAdapter\bin\Debug\net4.8

# Run all tests using runsettings:
# .runsettings   -> uses preview nanoCLR from NuGet (default)
# local_clr.runsettings -> uses a locally built nanoCLR
```

Key runsettings config:
- `IsRealHardware=False` — runs on emulator
- `UsePreviewClr=True` — downloads latest preview nanoCLR
- `MaxCpuCount=1` — tests run sequentially
- `TestSessionTimeout=1200000` (20 min)

### Adding Tests
- Each test suite is a separate `.nfproj` in `Tests/`.
- Use `nanoFramework.TestFramework` attributes: `[TestClass]`, `[TestMethod]`, `[Setup]`, `[Cleanup]`, `[DataRow]`.
- **Do not** reference the NuGet `nanoFramework.TestFramework` — use the project reference from `nanoFramework.TestFramework/` submodule instead (this is required for the CoreLibrary because it replaces mscorlib).
- **Do not** reference `mscorlib`, `nanoFramework.TestFramework`, or `nanoFramework.UnitTestLauncher` NuGet packages; use project references.
- Every new API **must** have test coverage for all methods, properties, events, and exceptions.

## Coding Conventions

### File Header
Every `.cs` file must begin with:
```csharp
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
```

### Naming
| Item | Convention | Example |
|---|---|---|
| Constants | PascalCase | `MaxValue` |
| Private/internal fields | `_camelCase` | `_thread` |
| Private/internal static fields | `s_camelCase` | `s_instance` |
| Public members | PascalCase | `GetEnumerator` |

### Formatting (from `.editorconfig`)
- Indent: 4 spaces (C#), 2 spaces (XML/project files)
- Line endings: CRLF
- Encoding: UTF-8 BOM
- Always use braces, even for single-line blocks
- `using` directives outside namespace
- System directives first

### C# Language
- Language version: C# 13.0 (main project); `default` for NoReflection variant
- Avoid `var` — use explicit types
- Prefer expression-bodied members where appropriate
- `[MethodImpl(MethodImplOptions.InternalCall)]` for native implementations — never add a body

### Assembly Size Awareness
- Avoid adding features that significantly increase binary size.
- Throw `NotSupportedException` (without a message string) when a method cannot be implemented on the constrained target.
- Comment rationale when omitting functionality for size reasons.

## CI/CD Pipeline

CI runs on **Azure Pipelines** (`azure-pipelines.yml`), not GitHub Actions. There is no GitHub Actions CI workflow for the main build. The pipeline:
1. Builds `nanoFramework.CoreLibrary.sln` on Windows
2. Runs all unit tests with nanoCLR emulator
3. Packages and publishes two NuGet packages
4. Updates dependent repositories on tag releases

## Important Notes for Contributions

1. **Avoid breaking native interop**: Methods marked `[MethodImpl(MethodImplOptions.InternalCall)]` have matching native C++ implementations in the nanoFramework interpreter. Changing their signatures requires coordinated changes to the native runtime.
2. **Two-project sync**: When adding or removing files from `nanoFramework.CoreLibrary`, evaluate whether the same change applies to `nanoFramework.CoreLibrary.NoReflection`. Reflection-related files belong only in the main project.
3. **Versioning**: Versions are managed by [Nerdbank.GitVersioning](https://github.com/dotnet/Nerdbank.GitVersioning) via `version.json`. Do not manually edit version numbers.
4. **Assembly signing**: The assembly is strong-named with `key.snk`. Do not replace or remove this file.
5. **`Friends.cs`**: This file declares `InternalsVisibleTo` attributes for test projects. Add new test projects here if they need access to internals.

## Known Constraints & Workarounds

- The build requires Windows and the nanoFramework MSBuild extension. Running builds in a Linux environment (e.g., standard GitHub Actions) will fail because `NFProjectSystem.CSharp.targets` is not available there.
- Tests must be run via `vstest.console.exe` with the nanoFramework test adapter; standard `dotnet test` does not work.
- The `RestoreLockedMode` is enabled in CI to prevent unexpected package version changes — if packages need updating, the `packages.lock.json` must be regenerated and committed.
- Some APIs intentionally throw `NotSupportedException` or return stub values — this is by design for embedded constraints, not a bug.
