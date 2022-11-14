using System;
using System.Collections.Generic;
using System.Linq;

namespace KVSV.Metaverse
{
    public class Entity
    {
        public Guid Id { get; }
        public Dictionary<Type, IComponent> Components { get; set; }

        public Entity() {
            Id = Guid.NewGuid();
            Components = new Dictionary<Type, IComponent>();
        }

        public IComponent AddComponent(IComponent component) {
            try
            {
                Components.Add(component.GetType(), component);
                return component;
            }
            catch(ArgumentException)
            {
                return GetComponent(component.GetType());
            }
        }

        public bool RemoveComponent(IComponent component) {
            return Components.Remove(component.GetType());
        }

        public IComponent GetComponent(Type ComponentType) {
            IComponent c;
            Components.TryGetValue(ComponentType, out c);
            return c;
        }
    }
}
