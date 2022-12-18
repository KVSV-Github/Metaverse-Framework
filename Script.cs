using System;
using System.IO;
using NLua;

namespace KVSV.Metaverse
{   
    public interface IScript {
        void Start();
        void Update(float deltaTime);
    }
}
