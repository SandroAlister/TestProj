using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProj.NativeGen
{
    public class Chromosome : List<int>
    {
        public Chromosome(): base() { }
        public Chromosome(IEnumerable<int> collection) : base(collection) { }
    }
}
