using UnityEngine;

namespace Hybel.Tweener
{
    /// <summary>
    /// An object which has values for tri-linear interpolation.
    /// </summary>
    public interface ITriLerpProvider
    {
        /// <summary>
        /// Get the data required to do a lerp in sync with the provider.
        /// </summary>
        public TriLerpData GetLerpData();
    }

    /// <summary>
    /// Helper struct to use when passing tri-lerp information across objects.
    /// </summary>
    public readonly struct TriLerpData
    {
        private readonly BiLerpData _left;
        private readonly BiLerpData _right;
        private readonly float _evaluator;
        private readonly bool _clamped;

        /// <param name="left">The minimum value of the lerp.</param>
        /// <param name="right">The maximum value of the lerp.</param>
        /// <param name="evaluator">A value to use when evaluating.</param>
        /// <param name="clamped">Should the <paramref name="evaluator"/> value be clamped before the evaluation?</param>
        public TriLerpData(BiLerpData left, BiLerpData right, float evaluator, bool clamped = true)
        {
            _left = new BiLerpData(left, evaluator, clamped);
            _right = new BiLerpData(right, evaluator, clamped);
            _evaluator = evaluator;
            _clamped = clamped;
        }

        public BiLerpData Left => _left;
        public BiLerpData Right => _right;
        public float Evaluator => _evaluator;
        public bool Clamped => _clamped;

        /// <summary>
        /// Evaluate a lerp using the <see cref="Evaluator"/> value as the time.
        /// <para>If clamped is true, <see cref="Evaluator"/> will be clamped between 0 and 1 meaning this method will always return a value between <see cref="Left"/> and <see cref="Right"/>.</para>
        /// </summary>
        public float Lerp()
        {
            float left = _left.Lerp();
            float right = _right.Lerp();
            return _clamped ? Mathf.Lerp(left, right, _evaluator) : Mathf.LerpUnclamped(left, right, _evaluator);
        }

        /// <summary>
        /// Evaluate an inverse lerp using the <see cref="Evaluator"/> value as the input for which to get a time from.
        /// <para>If clamped is true, <see cref="Evaluator"/> will be clamped between <see cref="Left"/> and <see cref="Right"/> meaning this method will always return a value between 0 and 1.</para>
        /// </summary>
        public float InverseLerp()
        {
            float left = _left.InverseLerp();
            float right = _right.InverseLerp();
            return Mathf.InverseLerp(left, right, _clamped ? Mathf.Clamp(_evaluator, left, right) : _evaluator);
        }
    }
}
