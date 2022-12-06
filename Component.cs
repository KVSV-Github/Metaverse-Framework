namespace KVSV.Metaverse {
    public interface IComponent {}

    public record Transform : IComponent {
        public Vector3 Position { get; set; }
        public Vector3 Rotation { get; set; }
        public Vector3 Scale { get; set; }
    }

    public record DefaultPlayer : IComponent {
        public float Speed { get; set; }
        public float JumpPower { get; set; }
    }

    public record Sound : IComponent {
        public bool Spatial { get; set; }
        public float Radius { get; set; }
        public string SoundPath { get; set; }
        public float Volume { get; set; }
    }

    public record PointLight : IComponent {
        public float Radius { get; set; }
        public float Brightness { get; set; }
        public Color LightColor { get; set; }
    }

    public record DirectionalLight : IComponent {
        public Color LightColor { get; set; }
        public float Brightness { get; set; }
    }
}