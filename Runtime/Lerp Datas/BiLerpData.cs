using UnityEngine;

namespace Hybel
{
    /// <summary>
    /// An object which has values for bi-linear interpolation.
    /// </summary>
    public interface IBiLerpProvider
    {
        /// <summary>
        /// Get the data required to do a lerp in sync with the provider.
        /// </summary>
        public BiLerpData GetLerpData();
    }

    /// <summary>
    /// Helper struct to use when passing bi-lerp information across objects.
    /// </summary>
    public readonly struct BiLerpData
    {
        private readonly float _bottomLeft;
        private readonly float _bottomRight;
        private readonly float _topLeft;
        private readonly float _topRight;
        private readonly float _evaluator;
        private readonly bool _clamped;

        /// <param name="bottomLeft">The minimum value of the bottom lerp.</param>
        /// <param name="bottomRight">The maximum value of the bottom lerp.</param>
        /// <param name="topLeft">The minimum value of the top lerp.</param>
        /// <param name="topRight">The maximum value of the top lerp.</param>
        /// <param name="evaluator">A value to use when evaluating.</param>
        /// <param name="clamped">Should the <paramref name="evaluator"/> value be clamped before the evaluation?</param>
        public BiLerpData(float bottomLeft, float bottomRight, float topLeft, float topRight, float evaluator, bool clamped = true)
        {
            _bottomLeft = bottomLeft;
            _bottomRight = bottomRight;
            _topLeft = topLeft;
            _topRight = topRight;
            _evaluator = evaluator;
            _clamped = clamped;
        }

        public BiLerpData(BiLerpData source, float evaluator, bool clamped)
            : this(
                  source.BottomLeft,
                  source.BottomRight,
                  source.TopLeft,
                  source.TopRight,
                  evaluator,
                  clamped) { }

        public float BottomLeft => _bottomLeft;
        public float BottomRight => _bottomRight;
        public float TopLeft => _topLeft;
        public float TopRight => _topLeft;

        public float Evaluator => _evaluator;
        public bool Clamped => _clamped;

        public float Bottom(float t) => _clamped ? Mathf.LerpUnclamped(BottomLeft, BottomRight, t) : Mathf.Lerp(BottomLeft, BottomRight, t);
        public float Top(float t) => _clamped ? Mathf.LerpUnclamped(TopLeft, TopRight, t) : Mathf.Lerp(TopLeft, TopRight, t);

        /// <summary>
        /// Evaluate a lerp using the <see cref="Evaluator"/> value as the time.
        /// <para>If clamped is true, <see cref="Evaluator"/> will be clamped between 0 and 1 meaning this method will always return a value between <see cref="BottomLeft"/> and <see cref="BottomRight"/>.</para>
        /// </summary>
        public float Lerp()
        {
            float bottom;
            float top;

            if (_clamped)
            {
                bottom = Mathf.Lerp(_bottomLeft, _bottomRight, _evaluator);
                top = Mathf.Lerp(_topLeft, _topRight, _evaluator);
                return Mathf.Lerp(bottom, top, _evaluator);
            }

            bottom = Mathf.LerpUnclamped(_bottomLeft, _bottomRight, _evaluator);
            top = Mathf.LerpUnclamped(_topLeft, _topRight, _evaluator);
            return Mathf.LerpUnclamped(bottom, top, _evaluator);
        }

        /// <summary>
        /// Evaluate an inverse lerp using the <see cref="Evaluator"/> value as the input for which to get a time from.
        /// <para>If clamped is true, <see cref="Evaluator"/> will be clamped between <see cref="BottomLeft"/> and <see cref="BottomRight"/> meaning this method will always return a value between 0 and 1.</para>
        /// </summary>
        public float InverseLerp()
        {
            float bottom;
            float top;

            if (_clamped)
            {
                bottom = Mathf.InverseLerp(_bottomLeft, _bottomRight, Mathf.Clamp(_evaluator, _bottomLeft, _bottomRight));
                top = Mathf.InverseLerp(_topLeft, _topRight, Mathf.Clamp(_evaluator, _topLeft, _topRight));
                return Mathf.InverseLerp(bottom, top, Mathf.Clamp(_evaluator, bottom, top));
            }

            bottom = Mathf.InverseLerp(_bottomLeft, _bottomRight, _evaluator);
            top = Mathf.InverseLerp(_topLeft, _topRight, _evaluator);
            return Mathf.InverseLerp(bottom, top, _evaluator);
        }
    }
}
