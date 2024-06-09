using UnityEngine;

namespace Hybel.Tweener
{
    public static class TransformExtensions
    {
        public static Tween<Vector3> TweenPos(this Transform transform, To<Vector3> to, float duration)
        {
            return new Tween<Vector3>(Getter, Setter, Interpolate.Vector3Unclamped, Getter, to, to.Invert(Getter()), duration);

            Vector3 Getter() => transform.position;
            void Setter(Vector3 position) => transform.position = position;
        }

        public static Tween<Vector3> TweenPos(this Transform transform, Vector3 to, float duration)
        {
            Vector3 from = Getter();
            return new Tween<Vector3>(Getter, Setter, Interpolate.Vector3Unclamped, () => from, () => to, () => -to, duration);

            Vector3 Getter() => transform.position;
            void Setter(Vector3 position) => transform.position = position;
        }
        
        public static Tween<Vector3> TweenLocalPos(this Transform transform, To<Vector3> to, float duration)
        {
            return new Tween<Vector3>(Getter, Setter, Interpolate.Vector3Unclamped, Getter, to, to.Invert(Getter()), duration);

            Vector3 Getter() => transform.localPosition;
            void Setter(Vector3 position) => transform.localPosition = position;
        }

        public static Tween<Vector3> TweenLocalPos(this Transform transform, Vector3 to, float duration)
        {
            Vector3 from = Getter();
            return new Tween<Vector3>(Getter, Setter, Interpolate.Vector3Unclamped, () => from, () => to, () => -to, duration);

            Vector3 Getter() => transform.localPosition;
            void Setter(Vector3 position) => transform.localPosition = position;
        }

        public static Tween<Vector3> TweenRot(this Transform transform, To<Vector3> to, float duration)
        {
            return new Tween<Vector3>(Getter, Setter, Interpolate.Vector3Unclamped, Getter, to, to.Invert(Getter()), duration);

            Vector3 Getter() => transform.eulerAngles;
            void Setter(Vector3 position) => transform.eulerAngles = position;
        }

        public static Tween<Vector3> TweenRot(this Transform transform, Vector3 to, float duration)
        {
            Vector3 from = Getter();
            return new Tween<Vector3>(Getter, Setter, Interpolate.Vector3Unclamped, () => from, () => to, () => -to, duration);

            Vector3 Getter() => transform.eulerAngles;
            void Setter(Vector3 position) => transform.eulerAngles = position;
        }

        public static Tween<Vector3> TweenScale(this Transform transform, To<Vector3> to, float duration)
        {
            return new Tween<Vector3>(Getter, Setter, Interpolate.Vector3Unclamped, Getter, to, to.Invert(Getter()), duration);

            Vector3 Getter() => transform.localScale;
            void Setter(Vector3 localScale) => transform.localScale = localScale;
        }
        
        public static Tween<Vector3> TweenScale(this Transform transform, Vector3 to, float duration)
        {
            Vector3 from = Getter();
            return new Tween<Vector3>(Getter, Setter, Interpolate.Vector3Unclamped, () => from, () => to, () => -to, duration);

            Vector3 Getter() => transform.localScale;
            void Setter(Vector3 localScale) => transform.localScale = localScale;
        }
    }
}
