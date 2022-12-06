namespace KVSV.Metaverse {
    public interface IComponent {}

    public record Transform : IComponent {
        public Vector3 Position;
        public Vector3 Rotation;
        public Vector3 Scale;
    }
}