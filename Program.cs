using KVSV.Metaverse;
using KVSV.Metaverse.DefaultComponents;
using KVSV.Debug;
using System;
using System.Collections.Generic;

namespace KVSV.VRProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            World world1 = new();
            
            Entity cube = world1.CreateEntity(new List<IComponent> {new Transform(), new MeshRenderer()});

            for(int x=1; x<=10; x++) {
                world1.Update(-1);
            }
        }
    }
}
