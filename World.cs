using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace KVSV.Metaverse
{
    

    public class World
    {
        public Dictionary<Guid, Entity> Entities { get; }
        public List<IScript> Scripts { get; }

        public World() {
            Entities = new();
            Scripts = new();
        }

        public Entity CreateEntity(List<IComponent> components)
        {
            Entity entity = new(components);
            Entities.Add(entity.Id, entity);

            return entity;
        }

        public void Update(float deltaTime)
        {
            foreach (IScript script in Scripts)
            {
                script.Update(deltaTime);
            }
        }

        public void Start()
        {
            foreach (IScript script in Scripts)
            {
                script.Start();
            }
        }

        public Entity GetEntity(Guid id)
        {
            return Entities[id];
        }

        public void LoadAssembly(string assembly) {
            Assembly loadedAssembly =  Assembly.LoadFrom(assembly);

            Type scriptType = typeof(IScript);

            foreach(Type script in AssemblyTypeLoader.GetLoadableTypes(loadedAssembly).Where(scriptType.IsAssignableFrom).ToList()) {
                IScript scriptObject = (IScript)Activator.CreateInstance(script);
                Scripts.Add(scriptObject);
            }
        }
    }
}