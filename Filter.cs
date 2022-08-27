using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRProject
{
    public struct Filter
    {
        public HashSet<Type> IncludesComponents;
        public HashSet<Type> ExcludesComponents;
    }
}
