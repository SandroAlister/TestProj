using System.Collections.Generic;

namespace TestProj.NativeGen
{
    public class Chromosome : List<int>
    {
        public Chromosome(): base() { }
        public Chromosome(IEnumerable<int> collection) : base(collection) { }
    }
}
