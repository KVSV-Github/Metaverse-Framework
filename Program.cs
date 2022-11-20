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
            Transform t = (Transform)cube.GetComponent(typeof(Transform));
            t.Position = new Vector3(5,25,10);
            //Console.WriteLine(t.Position);
            Console.WriteLine(t.Scale);
            //Logger.Log("Test");
        }
    }
}
