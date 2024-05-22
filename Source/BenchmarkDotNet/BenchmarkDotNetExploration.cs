using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Core.Source.BenchmarkDotNet;

// Class that will be the target for benchmarking operations.
public class BenchmarkTarget
{
    // Basic method that merges the strings.
    [Benchmark]
#pragma warning disable CA1822
    public string ExecuteBenchmarkForThis()
#pragma warning restore CA1822
    {
        var mergedString = string.Empty;

        const int limit = 10000;
        for (var i = 0; i < limit; i++)
        {
            mergedString = string.Concat(mergedString, i.ToString());
        }

        return mergedString;
    }
}

// Class to execute benchmarking on the target.
public static class BenchmarkDotNetExploration
{
    public static void ExecuteFromMain()
    {
        // ReSharper disable once UnusedVariable
        var summary = BenchmarkRunner.Run<BenchmarkTarget>();
    }
}