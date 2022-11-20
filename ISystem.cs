using System;
using System.Collections.Generic;
using KVSV.Metaverse.DefaultComponents;

namespace KVSV.Metaverse
{
    public interface ISystem
    {
        public void Start(World world);
        public void Update(float delta);
    }

    public class SpinSystem : ISystem {
        List<Transform> transforms = new();
        
        public void Start(World world) {/*
            foreach(Entity entity in world.Entities) {
                foreach(IComponent component in entity) {
                    if(component is typeof(Transform)) {
                        transforms.Add(component);
                        break;
                    }
                }
            }*/
        }

        public void Update(float delta) {
            foreach(Transform transform in transforms) {
                transform.Rotation += new Vector3(1, 0, 0);
            }
        }
    }
}
