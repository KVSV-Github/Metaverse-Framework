using System;
using System.Collections.Generic;

namespace KVSV.Metaverse
{
    public class Entity
    {
        public Guid Id { get; }
        private Dictionary<Type, IComponent> Components { get; }

        public Entity(List<IComponent> components) {
            Id = new Guid();
            Components = new Dictionary<Type, IComponent>();
            foreach(IComponent component in components) {
                Components.Add(component.GetType(), component);
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
            IComponent component;
            Components.TryGetValue(componentType, out component);
            return component;
        }
    }
}
