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
            List<Entity> eList = world1.GetEntities(new List<Type> {typeof(Transform), typeof(MeshRenderer)});
            foreach(Entity entity in eList) {
                Console.WriteLine(entity.Id);
            }
            //Logger.Log("Test");
        }
    }
}
