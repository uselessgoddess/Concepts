using System;
using System.Linq;

namespace Concepts
{
    public class Concept
    {
        private readonly Requires[] _requires;

        public Concept(params Requires[] requires)
        {
            _requires = requires;
        }

        public bool Is<T>()
        {
            return _requires.All(requires => requires.Is<T>());
        }
    }
}