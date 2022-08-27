using System;
using System.Collections.Generic;

namespace VRProject
{
    public struct Entity
    {
        public string name { get; set; }
        public HashSet<IComponent> Components { get; }
    }
}
