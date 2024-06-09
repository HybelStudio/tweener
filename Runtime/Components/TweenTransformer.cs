using System;
using UnityEngine;

namespace Hybel.Tweener
{
    public class TweenTransformer : MonoBehaviour
    {
        [SerializeField] private Transformation transformation;
        [SerializeField] private Vector3 positionOffset;
        [SerializeField] private Space space;
        [SerializeField] private Vector3 rotationOffset;
        [SerializeField] private Vector3 scaleOffset;

        private Vector3 _startPositionWorld;
        private Vector3 _startPositionLocal;
        private Vector3 _startRotation;
        private Vector3 _startScale;

        private void Awake() => SaveTransforms();
        private void SaveTransforms()
        {
            _startPositionWorld = transform.position;
            _startPositionLocal = transform.localPosition;
            _startRotation = transform.eulerAngles;
            _startScale = transform.localScale;
        }

        public void Transform(float time)
        {
            if (transformation.HasFlag(Transformation.Position))
                TransformPosition(time);

            if (transformation.HasFlag(Transformation.Rotation))
                TransformRotation(time);

            if (transformation.HasFlag(Transformation.Scale))
                TransformScale(time);
        }

        private void TransformPosition(float time)
        {
            Vector3 startPosition = space switch
            {
                Space.World => _startPositionWorld,
                Space.Self => _startPositionLocal,
                _ => _startPositionWorld,
            };

            Vector3 endPosition = space switch
            {
                Space.World => _startPositionWorld + positionOffset,
                Space.Self => _startPositionLocal + positionOffset,
                _ => _startPositionWorld + positionOffset,
            };

            Vector3 position = Interpolate.Vector3Unclamped(startPosition, endPosition, time);

            switch (space)
            {
                default:
                case Space.World:
                    transform.position = position;
                    break;

                case Space.Self:
                    transform.localPosition = position;
                    break;
            }
        }

        private void TransformRotation(float time) =>
            transform.eulerAngles = Interpolate.Vector3Unclamped(_startRotation, _startRotation + rotationOffset, time);

        private void TransformScale(float time) =>
            transform.localScale = Interpolate.Vector3Unclamped(_startScale, _startScale + scaleOffset, time);

        [Flags]
        enum Transformation
        {
            Position = 1 << 0,
            Rotation = 1 << 1,
            Scale = 1 << 2,
        }
    }
}
