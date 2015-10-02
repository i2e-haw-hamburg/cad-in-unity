using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STPConverter.Implementation
{
    public class Tuple<T1, T2>
    {
        public T1 First { get; private set; }
        public T2 Second { get; private set; }
        internal Tuple(T1 first, T2 second)
        {
            First = first;
            Second = second;
        }
    }

    public static class Tuple
    {
        public static Tuple<T1, T2> New<T1, T2>(T1 first, T2 second)
        {
            var tuple = new Tuple<T1, T2>(first, second);
            return tuple;
        }

        public static Tuple<int, List<int>> AggregateIndices<T>(Tuple<int, List<int>> last, Tuple<IList<T>, IList<int>> next)
        {
            var offset = last.First;
            var indices = last.Second;
            indices.AddRange(next.Second.Select(i => i + offset));
            return New(offset + next.First.Count, indices);
        }
    }
}
