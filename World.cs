using System;
using System.IO;
using System.Collections.Generic;

namespace KVSV.Metaverse
{
    public class World {
        public Dictionary<Guid, Entity> Entities = new Dictionary<Guid, Entity>();

        private List<Script> scripts = new List<Script>();
        private const string scriptsPath = "Scripts";
    
        public World() {
            ScanScripts();
        }
        
        public Entity CreateEntity(List<IComponent> components) {
            Entity e = new Entity(components);
            Entities.Add(e.Id, e);

            return e;
        }

        public void Update(float deltaTime) {
            foreach(Script s in scripts) {
                s.Update(deltaTime);
            }
        }

        public Entity GetEntity(Guid id) {
            return Entities[id];
        }

        private void ScanScripts() {
            DirectoryInfo d = new DirectoryInfo(scriptsPath);
            foreach(var file in d.GetFiles("*.lua")) {
                Console.WriteLine(file.FullName);
                Script s = new Script(file.FullName);
                scripts.Add(s);
            }
        }
        
    }
}
