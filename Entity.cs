using System;
using System.Collections.Generic;
using System.Linq;

namespace KVSV.Metaverse
{
    public class Entity
    {
        public Guid Id { get; }
        private Dictionary<Type, IComponent> Components = new();

        public Entity(List<IComponent> components) {
            Id = new();
            foreach(IComponent c in components) {
                Components.Add(c.GetType(), c);
            }
        }

        // Archetypes solve need for this
        
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

        public IComponent GetComponent(Type componentType) {
            IComponent c;
            Components.TryGetValue(componentType, out c);
            return c;
        }
    }
}
