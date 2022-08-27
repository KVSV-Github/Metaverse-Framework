using System;
using System.Collections.Generic;
using StereoKit;

namespace VRProject
{
    public interface ISystem
    {
        public void Start();
        public void Update();
    }

    public class RendererSystem : ISystem
    {
        List<Guid> entityGuids = new();

        public void Start()
        {
            Filter filter = new Filter();
            filter.IncludesComponents = new HashSet<Type>() { typeof(TransformComponent), typeof(ModelComponent) };
            filter.ExcludesComponents = new();
            entityGuids = ArchetypeManager.Instance.GetEntities(filter);
        }

        public void Update()
        {
            entityGuids.ForEach((entityGuid) =>
            {
                // World.Instance.loadedEntities[entityGuid].Components;

            });
        }
    }
}
