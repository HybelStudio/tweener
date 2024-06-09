using UnityEngine;

namespace Hybel.Tweener
{
    public static class ToExtensions
    {
        public static To<float> Invert(this To<float> to, float center) => () => center + -(to() - center);
        public static To<Vector2> Invert(this To<Vector2> to, Vector2 center) => () => center + -(to() - center);
        public static To<Vector3> Invert(this To<Vector3> to, Vector3 center) => () => center + -(to() - center);
        public static To<Vector4> Invert(this To<Vector4> to, Vector4 center) => () => center + -(to() - center);
    }
}
