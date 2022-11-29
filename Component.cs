using System.IO;
using System.Dynamic;
using Newtonsoft.Json;

namespace KVSV.Metaverse
{
    public class Component
    {
        public string source;
        public dynamic ComponentObject = new ExpandoObject();

        public Component(string sourcePath) {
            source = File.ReadAllText(sourcePath);
        }

        
    }
}