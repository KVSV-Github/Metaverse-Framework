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
            Entity cube = world1.CreateEntity();
            Transform test = new();
            cube.AddComponent(new Transform());
            cube.GetComponent(typeof(Transform));
            Logger.Log("Test");
        }
    }
}
