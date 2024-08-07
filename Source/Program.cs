﻿// An entry point for the project.

using Core.Source.Async;
using Core.Source.BenchmarkDotNet;
using Core.Source.FrozenDictionary;
using Core.Source.FrozenSet;
using Core.Source.Records;
using Core.Source.SortedList;
using Core.Source.SortedSet;
using Core.Source.Span;

namespace Core.Source;

internal static class Program
{
    internal static async Task Main()
    {
        // RecordsExploration.ExecuteFromMain();
        // BenchmarkDotNetExploration.ExecuteFromMain();
        // FrozenSetExploration.ExecuteFromMain();
        // FrozenDictionaryExploration.ExecuteFromMain();

        // var asyncWorker = new AsyncWorker();
        // asyncWorker.ExecuteFromMain();

        // var taskWorker = new TaskWorker();
        // taskWorker.ExecuteFromMain();

        // var cancellable = new Cancellable();
        // await cancellable.ExecuteFromMain();

        // Console.WriteLine(SpanExploration.GetStringBetween(0, 2).Length);

        // SortedListExploration.BasicExample();
        // SortedListExploration.ExampleWithCustomType();
        // SortedListExploration.ExampleWithCustomTypeByProperty();

        // SortedSetExploration.BasicExample();
        SortedSetExploration.ExampleWithCustomType();
    }
}