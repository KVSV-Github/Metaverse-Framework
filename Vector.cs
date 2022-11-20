using System;

namespace KVSV.Metaverse
{
    public class Vector3
    {

        public float x { get; }
        public float y { get; }
        public float z { get; }

        public Vector3(float x = 0f, float y = 0f, float z = 0f)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public float Magnitude()
        {
            return (float)Math.Sqrt((x * x) + (y * y) + (z * z));
        }

        public Vector3 Normalized()
        {
            return new Vector3(x / Magnitude(), y / Magnitude(), z / Magnitude());
        }

        public override string ToString() => $"X:{x} Y:{y} Z:{z}";
        public static Vector3 operator +(Vector3 a, Vector3 b) => new Vector3(a.x+b.x, a.y+b.y, a.z+b.z);
    }
}