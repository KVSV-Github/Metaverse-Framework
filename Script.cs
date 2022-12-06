using System;
using System.IO;
using NLua;

namespace KVSV.Metaverse
{   
    public interface IScript {
        public void Start();
        public void Update(float deltaTime);
    }
}
