using System;
using System.Collections.Generic;
using System.Linq;

namespace KVSV.Metaverse
{
    public class Entity
    {
        public Guid Id { get; }
        private Dictionary<Type, Component> Components = new();

        public Entity(List<Component> components) {
            Id = new();
            foreach(Component c in components) {
                Components.Add(c.GetType(), c);
            }
        }

        // Archetypes solve need for this
        
        public Component AddComponent(Component component) {
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

        public bool RemoveComponent(Component component) {
            return Components.Remove(component.GetType());
        }

        public Component GetComponent(Type componentType) {
            Component c;
            Components.TryGetValue(componentType, out c);
            return c;
        }
    }
}
