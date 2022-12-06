using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace KVSV.Metaverse
{
    

    public class World
    {
        public Dictionary<Guid, Entity> Entities = new();
        public List<IScript> scripts = new(); 

        public Entity CreateEntity(List<IComponent> components)
        {
            Entity e = new(components);
            Entities.Add(e.Id, e);

            return e;
        }

        public void Update(float deltaTime)
        {
            foreach (IScript s in scripts)
            {
                s.Update(deltaTime);
            }
        }

        public void Start()
        {
            foreach (IScript s in scripts)
            {
                s.Start();
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
                scripts.Add(scriptObject);
            }
        }
    }
}