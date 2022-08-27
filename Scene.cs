using System;
using System.Collections.Generic;

namespace VRProject
{
    public class Scene
    {
        public Dictionary<Guid, Entity> Entities { get; }
        public HashSet<ISystem> Systems { get; }
    }
}