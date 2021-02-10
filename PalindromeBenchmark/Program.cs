#if DEBUG
#error Benchmarks must be built in Release mode!
#endif
using BenchmarkDotNet.Attributes;
using PermutationPalindrome;
using System;

namespace PalindromeBenchmark
{
    [SimpleJob]
    public class Program
    {
        static void Main(string[] args)
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                throw new InvalidOperationException("Benchmarks must not be run inside the debugger!");
            }

            BenchmarkDotNet.Running.BenchmarkRunner.Run<Program>();
        }

        // set up our test values; we assume the unit tests have already validated the logic of each algorithm
        [Params("abcdefghijklmnopqrstuvwxyz", "aaaaaaaaaaaaaaaaaaaaaaaaaaabc", "aaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabc")]
        public string TestValue { get; set; }

        // run each benchmark
        [Benchmark]
        public void DictionarySearch()
        {
            RunBenchmark<DictionarySearch>(TestValue);
        }

        [Benchmark]
        public void SortAndTraverse()
        {
            RunBenchmark<SortAndTraverse>(TestValue);
        }

        [Benchmark]
        public void LINQ()
        {
            RunBenchmark<LINQPermuter>(TestValue);
        }

        [Benchmark]
        public void Stephen()
        {
            RunBenchmark<StephenPermuter>(TestValue);
        }

        [Benchmark]
        public void Andrew()
        {
            RunBenchmark<AndrewTest>(TestValue);
        }

        private static void RunBenchmark<T>(string testValue)
            where T : Permuter, new()
        {
            var p = new T();
            for (var i = 0; i < 1000000; i++)
            {
                p.HasPalindrome(testValue);
            }
        }
    }
}
