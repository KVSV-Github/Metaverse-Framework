using StereoKit;

namespace VRProject
{
    public interface IComponent { }

    public struct TransformComponent : IComponent
    {
        public Matrix transform;
    }

    public struct ModelComponent : IComponent
    {
        public Mesh mesh;
        public Material material;
    }

    public struct GrabbableComponent : IComponent
    {
        public float maxGrabDistance;
    }

    public struct SoundComponent : IComponent
    {
        public string soundFile;
        public float volume;
    }
}
