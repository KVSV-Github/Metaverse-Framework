using System;
using System.Collections.Generic;

namespace KVSV.Metaverse
{
    public class World {
        public List<Entity> Entities = new();

        public Entity CreateEntity() {
            return new Entity();
        }
    }
}
