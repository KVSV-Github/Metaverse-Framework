using System.IO;
using Newtonsoft.Json;

namespace KVSV.Metaverse
{
    public class Component
    {
        public string source;

        public Component(string sourcePath) {
            source = File.ReadAllText(sourcePath);
        }

        
    }
}