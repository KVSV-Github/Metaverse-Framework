using System;
using System.Collections.Generic;

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

        public bool RemoveComponent(Type componentType) {
            return Components.Remove(componentType);
        }

        public IComponent GetComponent(Type componentType) {
            IComponent c;
            Components.TryGetValue(componentType, out c);
            return c;
        }
    }
}
