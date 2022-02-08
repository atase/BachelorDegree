
using System.Collections.Generic;

namespace Business.Models
{
    public class Compatibility<T, U>
    {
        public IEnumerable<Pair<T, IEnumerable<U>>> CompatiblePairs { get; set; }
        public Pair<T, IEnumerable<U>> SubjectCompatibility { get; set; }
        public IEnumerable<Pair<Pair<T, U>, int>> CompatibilityScores { get; set; }
        public Compatibility() { }

    }
}
