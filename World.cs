using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Dynamic;

namespace KVSV.Metaverse
{
    public class World
    {
        public Dictionary<Guid, Entity> Entities = new();
        public dynamic Components = new ExpandoObject();
        public List<Script> scripts = new(); 

        public World()
        {
            ScanComponents();
            ScanScripts();
        }

        public Entity CreateEntity(List<dynamic> components)
        {
            Entity e = new(components);
            Entities.Add(e.Id, e);

            return e;
        }

        public void Update(float deltaTime)
        {
            foreach (Script s in scripts)
            {
                s.Update(deltaTime);
            }
        }

        public void Start()
        {
            foreach (Script s in scripts)
            {
                s.Start();
            }
        }

        public Entity GetEntity(Guid id)
        {
            return Entities[id];
        }

        public void ScanScripts()
        {
            DirectoryInfo d = new(Directory.GetCurrentDirectory() + "\\Scripts");
            foreach (var file in d.GetFiles("*.lua"))
            {
                Script s = new(file.FullName);
                s.state["Components"] = Components;
                scripts.Add(s);
            }
        }

        public void ScanComponents()
        {
            DirectoryInfo d = new(Directory.GetCurrentDirectory() + "\\Components");
            foreach (var file in d.GetFiles("*.cpt"))
            {
                string source = File.ReadAllText(file.FullName);
                dynamic obj = ComponentConvert.Deserialize(source);
                ((IDictionary<string, object>)Components).Add(obj.Id, obj);
            }
        }
    }
}