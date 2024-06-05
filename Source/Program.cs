// An entry point for the project.

using Core.Source.BenchmarkDotNet;
using Core.Source.FrozenSet;
using Core.Source.Records;

namespace Core.Source;

internal static class Program
{
    internal static void Main()
    {
        // RecordsExploration.ExecuteFromMain();
        // BenchmarkDotNetExploration.ExecuteFromMain();
        FrozenSetExploration.ExecuteFromMain();
    }
}