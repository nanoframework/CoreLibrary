// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Diagnostics;
using System.Threading;
using nanoFramework.Benchmark;
using nanoFramework.CoreLibrary.Benchmarks.ToString;
using nanoFramework.Runtime.Native;

namespace nanoFramework.CoreLibrary.Benchmarks
{
    public class Program
    {
        public static void Main()
        {
            // Display header with system information
            Debug.WriteLine("================================================");
            Debug.WriteLine("  nanoFramework Core Library Benchmarks");
            Debug.WriteLine("================================================");
            Debug.WriteLine("");

            Debug.WriteLine($"Target Name: {SystemInfo.TargetName}");
            Debug.WriteLine($"Firmware: {SystemInfo.Version}");
            var coreLibVersion = typeof(object).Assembly.GetName().Version;
            Debug.WriteLine($"CoreLibrary Version: {coreLibVersion}");

            Debug.WriteLine("");
            Debug.WriteLine("================================================");
            Debug.WriteLine("");

            // Run benchmarks
            BenchmarkRunner.RunClass(typeof(ToStringPlain));
            BenchmarkRunner.RunClass(typeof(ToStringConcatenation));
            BenchmarkRunner.RunClass(typeof(ToStringInterpolation));
            BenchmarkRunner.RunClass(typeof(ToStringFormat));

            Thread.Sleep(Timeout.Infinite);
        }
    }
}
