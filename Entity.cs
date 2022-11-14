using System;
using System.Collections.Generic;
using System.Linq;

namespace KVSV.Metaverse
{
    public class Entity
    {
        public Guid Id { get; }
        public HashSet<IComponent> Components { get; set; }

        public Entity() {
            Id = Guid.NewGuid();
        }

        public IComponent AddComponent(IComponent component) {
            bool added = Components.Add(component);
            if(added) {
                return component;
            }
            else {
                IComponent existing;
                if(Components.TryGetValue(component, out existing)) {
                    return existing;
                }
                else {
                    //throw new Exception();
                }
                return null;
            }
        }

        public bool RemoveComponent(IComponent component) {
            return Components.Remove(component);
        }

        public IComponent GetComponent(Type ComponentType) {
            IComponent c;
            Components.TryGetValue(ComponentType, out c);
            return c;
        }
    }
}
