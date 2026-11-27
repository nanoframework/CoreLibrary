# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

`.github/copilot-instructions.md` is the authoritative rulebook for this repo (build details, coding conventions, contribution rules). Read it whenever you need more than the summary below.

## What this repo is

The Base Class Library (BCL) for **.NET nanoFramework** — the `mscorlib` equivalent for embedded/MCU targets. This is **not** standard .NET: it targets `TargetFrameworkVersion v1.0` (the nanoFramework target), builds `.nfproj` projects, and pairs with a native C++ runtime.

Two output NuGet packages, both producing an assembly named `mscorlib`:
- `nanoFramework.CoreLibrary/` — full BCL including `System.Reflection`
- `nanoFramework.CoreLibrary.NoReflection/` — reflection excluded for smaller flash footprint (same sources, minus `System/Reflection/`)

When adding or removing files, decide whether the change also applies to the NoReflection variant and update its `.nfproj` accordingly. Reflection-only sources stay in the full project.

## Native-interop constraints (read before editing methods)

- Methods marked `[MethodImpl(MethodImplOptions.InternalCall)]` are **native stubs** — the implementation lives in the nanoFramework C++ interpreter. Never add a body. Changing signatures requires a coordinated change to the native runtime.
- Some methods intentionally `throw new NotSupportedException();` (usually no message) to satisfy an interface contract while omitting the feature to save flash. This is by design — do not "fix" them.
- Assembly size is a first-class concern. Avoid adding features that noticeably grow the binary; comment the rationale when omitting functionality.

## Build & test

Windows only. Requires Visual Studio 2022 with the nanoFramework VS extension (or MSBuild 17+ with `NFProjectSystem.CSharp.targets`). Linux CI cannot build this repo. CI is Azure Pipelines (`azure-pipelines.yml`), not GitHub Actions.

```powershell
nuget restore nanoFramework.CoreLibrary.sln
msbuild nanoFramework.CoreLibrary.sln /p:Configuration=Release /p:Platform="Any CPU"
```

Tests run on the **nanoCLR Win32 emulator** via `vstest.console.exe` — `dotnet test` will not work. Run a single suite from a Developer Command Prompt:

```powershell
vstest.console.exe .\Tests\NFUnitTestBitConverter\bin\Release\NFUnitTest.dll /Settings:.\.runsettings /TestAdapterPath:.\nanoFramework.TestFramework\source\TestAdapter\bin\Debug\net4.8
```

Runsettings:
- `.runsettings` — preview nanoCLR downloaded from NuGet (default)
- `local_clr.runsettings` — locally-built nanoCLR

Every test suite is its own `.nfproj` under `Tests/`. Tests reference `mscorlib`, `nanoFramework.TestFramework`, and `nanoFramework.UnitTestLauncher` **as project references** (via the `nanoFramework.TestFramework/` submodule), not as NuGet packages — this is mandatory because the CoreLibrary itself replaces `mscorlib`.

New API surface requires test coverage for methods, properties, events, and thrown exceptions.

## Repo layout landmarks

- `nanoFramework.CoreLibrary/System/` — all `System.*` sources, subfoldered by sub-namespace (`Collections/`, `Diagnostics/`, `Globalization/`, `IO/`, `Reflection/`, `Runtime/`, `Threading/`, …)
- `nanoFramework.CoreLibrary/Friends.cs` — `InternalsVisibleTo` declarations for test projects; add new ones here when they need access to internals
- `nanoFramework.CoreLibrary/key.snk` — strong-name key; do not replace or remove
- `nanoFramework.TestFramework/` — git submodule; test framework sources referenced by every test project
- `version.json` — Nerdbank.GitVersioning; do not hand-edit version numbers
- `.runsettings`, `local_clr.runsettings` — test runner configs (emulator, sequential execution, 20 min timeout)

## Coding conventions (highlights)

- File header on every `.cs`:
  ```csharp
  // Licensed to the .NET Foundation under one or more agreements.
  // The .NET Foundation licenses this file to you under the MIT license.
  ```
- 4-space C# indent, CRLF, UTF-8 BOM, `using` outside namespace, System usings first, always braces.
- Private/internal fields `_camelCase`; private/internal statics `s_camelCase`; constants and public members PascalCase.
- Avoid `var` — use explicit types.
- C# language version: 13.0 for the main project; `default` for the NoReflection variant.

## Pipeline note

`RestoreLockedMode` is on in CI. If a package version genuinely needs to change, regenerate and commit the corresponding `packages.lock.json`; do not bypass the lock.
