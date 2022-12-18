using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace KVSV.Metaverse
{
<<<<<<< HEAD
=======
    public class World {
        public Dictionary<Guid, Entity> Entities = new Dictionary<Guid, Entity>();

        private List<Script> scripts = new List<Script>();
        private const string scriptsPath = "Scripts";
>>>>>>> compatibility-.netcore2.1
    

    public class World
    {
        public Dictionary<Guid, Entity> Entities { get; }
        public List<IScript> Scripts { get; }

        public World() {
<<<<<<< HEAD
            Entities = new();
            Scripts = new();
=======
            ScanScripts();
        }
        
        public Entity CreateEntity(List<IComponent> components) {
            Entity e = new Entity(components);
            Entities.Add(e.Id, e);

            return e;
>>>>>>> compatibility-.netcore2.1
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

<<<<<<< HEAD
        public void LoadAssembly(string assembly) {
            Assembly loadedAssembly =  Assembly.LoadFrom(assembly);

            Type scriptType = typeof(IScript);

            foreach(Type script in AssemblyTypeLoader.GetLoadableTypes(loadedAssembly).Where(scriptType.IsAssignableFrom).ToList()) {
                IScript scriptObject = (IScript)Activator.CreateInstance(script);
                Scripts.Add(scriptObject);
=======
        private void ScanScripts() {
            DirectoryInfo d = new DirectoryInfo(scriptsPath);
            foreach(var file in d.GetFiles("*.lua")) {
                Console.WriteLine(file.FullName);
                Script s = new Script(file.FullName);
                scripts.Add(s);
>>>>>>> compatibility-.netcore2.1
            }
        }
    }
}