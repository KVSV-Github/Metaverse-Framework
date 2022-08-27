using System;
using System.Collections.Generic;
using System.Linq;

namespace VRProject
{
    public sealed class ArchetypeManager
    {
        #region Singleton
        private static readonly Lazy<ArchetypeManager> lazy = new Lazy<ArchetypeManager>(() => new ArchetypeManager());
        public static ArchetypeManager Instance { get { return lazy.Value; } }
        #endregion

        Dictionary<HashSet<Type>, List<Guid>> Archetypes = new(HashSet<Type>.CreateSetComparer());

        public List<Guid> GetArchetype(HashSet<Type> archetype)
        {
            if(Archetypes.ContainsKey(archetype))
            {
                return Archetypes[archetype];
            }
            else
            {
                return new List<Guid>();
            }
        }

        public List<Guid> GetEntities(Filter filter)
        {
            List<Guid> entities = new List<Guid>();

            foreach(KeyValuePair<HashSet<Type>, List<Guid>> kvp in Archetypes)
            {
                if (!kvp.Key.Overlaps(filter.ExcludesComponents) && kvp.Key.Overlaps(filter.IncludesComponents))
                {
                    entities = entities.Union(kvp.Value).ToList();
                }
            }

            return entities;
        }

        public void AddToArchetype(Guid entityId)
        {
            HashSet<Type> components = new();
            Entity entity = World.Instance.loadedEntities[entityId];

            foreach (IComponent component in entity.Components)
            {
                components.Add(component.GetType());
            }

            if(Archetypes.ContainsKey(components))
            {
                Console.WriteLine("Archetype: Adding ");
                Console.Write(entityId);
                Archetypes[components].Add(entityId);
            }
            else
            {
                Console.Write("Archetype: Creating new, adding ");
                Console.WriteLine(entityId);
                List<Guid> guids = new();
                guids.Add(entityId);
                Archetypes.Add(components, guids);
            }
        }
    }
}
