using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace KVSV.Metaverse
{
    public class Entity
    {
        public Guid Id { get; }
        private Dictionary<string, dynamic> Components = new();

        public Entity(List<dynamic> components) {
            Id = new();
            foreach(dynamic c in components) {
                Components.Add(c.id, c);
            }
        }
        
        public dynamic AddComponent(dynamic component) {
            try
            {
                Components.Add(component.id, component);
                return component;
            }
            catch(ArgumentException)
            {
                return GetComponent(component.id);
            }
        }

        public bool RemoveComponent(string componentId) {
            return Components.Remove(componentId);
        }

        public dynamic GetComponent(string componentId) {
            dynamic c;
            Components.TryGetValue(componentId, out c);
            return c;
        }
    }
}
