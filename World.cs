using System;
using System.IO;
using System.Collections.Generic;

namespace KVSV.Metaverse
{
    public class World {
        public Dictionary<Guid, Entity> Entities = new();

        private List<Script> scripts = new();
        private const string scriptsPath = "Scripts";
    
        public World() {
            ScanScripts();
        }
        
        public Entity CreateEntity(List<Component> components) {
            Entity e = new(components);
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
            DirectoryInfo d = new(scriptsPath);
            foreach(var file in d.GetFiles("*.lua")) {
                Console.WriteLine(file.FullName);
                Script s = new(file.FullName);
                scripts.Add(s);
            }
        }
        
    }
}
