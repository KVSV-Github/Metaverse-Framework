namespace KVSV.Metaverse
{
    public interface IComponent { }
}

namespace KVSV.Metaverse.DefaultComponents {
    
    public class Transform : IComponent {
        public Vector3 Position { get; set; }
        public Vector3 Rotation { get; set; }
        public Vector3 Scale { get; set; }

        public Transform() {
            Position = new();
            Rotation = new();
            Scale = new(1,1,1);
        }
    }

    public class MeshRenderer : IComponent {
        public string test { get; set; }
    }
    
}