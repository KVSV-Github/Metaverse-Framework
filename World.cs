using System;
using System.Collections.Generic;

namespace KVSV.Metaverse
{
    public class World {
        private Dictionary<Guid, Entity> Entities = new();
        private List<ISystem> Systems = new();
        private Dictionary<List<Type>, List<Guid>> Archetypes = new();

        public Entity CreateEntity(List<IComponent> components) {
            Entity e = new(components);
            Entities.Add(e.Id, e);

            List<Type> cTypes = new();
            foreach(IComponent c in components) {
                cTypes.Add(c.GetType());
            }
            
            if(Archetypes.ContainsKey(cTypes)){
                Archetypes[cTypes].Add(e.Id);
            }
            else {
                List<Guid> t = new();
                t.Add(e.Id);
                Archetypes.Add(cTypes, t);
            }

            foreach(KeyValuePair<List<Type>,List<Guid>> kvp in Archetypes) {
                foreach(Type t in kvp.Key) {
                    Console.WriteLine(t);
                    foreach(Guid g in kvp.Value) {
                        Console.WriteLine(g);
                    }
                }
            }

            return e;
        }

        public List<Entity> GetEntities(List<Type> cTypes) {
            List<Guid> eIds = new();
            Console.WriteLine(Archetypes.TryGetValue(cTypes, out eIds));
            List<Entity> e = new();
            foreach(Guid id in eIds) {
                Console.WriteLine(id);
                e.Add(Entities[id]);
            }

            return e;
        }

        public void AddSystem(ISystem system) {
            Systems.Add(system);
        }

        public void RemoveSystem(ISystem system) {
            Systems.Remove(system);
        }
        
    }
}
