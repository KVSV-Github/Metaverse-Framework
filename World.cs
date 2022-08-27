using System;
using System.Collections.Generic;
using System.Text.Json;

namespace VRProject
{
    public sealed class World
    {
        #region Singleton
        private static readonly Lazy<World> lazy = new Lazy<World>(() => new World());
        public static World Instance { get { return lazy.Value; } }
        #endregion

        Scene loadedScene;
        public Dictionary<Guid, Entity> loadedEntities = new();

        public void LoadScene(string jsonPath)
        {
            loadedScene = JsonSerializer.Deserialize<Scene>(jsonPath);

            foreach(KeyValuePair<Guid, Entity> entityPair in loadedScene.Entities)
            {
                ArchetypeManager.Instance.AddToArchetype(entityPair.Key);
            }

            foreach (ISystem system in loadedScene.Systems)
            {
                system.Start();
            }
        }

        public void CreateEntity(string name)
        {
            Entity entity = new();
            entity.name = name;
            loadedEntities.Add(Guid.NewGuid(), entity);
        }

        public void Update()
        {
            foreach (ISystem system in loadedScene.Systems)
            {
                system.Update();
            }
        }
    }
}
