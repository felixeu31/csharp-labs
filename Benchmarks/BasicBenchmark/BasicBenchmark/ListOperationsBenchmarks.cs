using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace BasicBenchmark
{
    [MemoryDiagnoser()]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn()]
    public class ListOperationsBenchmarks
    {
        private readonly List<int> _list;
        private readonly IEnumerable<int> _enumerable;

        public ListOperationsBenchmarks()
        {
            Random rand = new Random();
            _enumerable = Enumerable.Range(0, 10000).Select(x => rand.Next(10000));
            _list = _enumerable.ToList();
        }

        [Benchmark]
        public void ListAny()
        {
            var any = _list.Any();
        }
        
        [Benchmark]
        public void ListCount()
        {
            var any = _list.Count > 0;
        }


        [Benchmark]
        public void EnumerableAny()
        {
            var any = _enumerable.Any();
        }

        [Benchmark]
        public void EnumerableCount()
        {
            var any = _enumerable.Count() > 0;
        }
    }
}
