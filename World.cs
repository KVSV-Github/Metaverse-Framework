using System;
using System.Collections.Generic;

namespace KVSV.Metaverse
{
    public class World {
        public Dictionary<Guid, Entity> Entities = new();
        private List<ISystem> Systems = new();

        public Entity CreateEntity(List<IComponent> components) {
            Entity e = new(components);
            Entities.Add(e.Id, e);

            return e;
        }

        public Entity GetEntity(Guid id) {
            return Entities[id];
        }

        public void AddSystem(ISystem system) {
            Systems.Add(system);
        }

        public void RemoveSystem(ISystem system) {
            Systems.Remove(system);
        }
        
    }
}
