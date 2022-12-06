namespace KVSV.Metaverse {
    public interface IComponent {}

    public record Transform : IComponent {
        public Vector3 Position { get; set; }
        public Vector3 Rotation { get; set; }
        public Vector3 Scale { get; set; }
    }
}