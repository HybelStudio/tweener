using UnityEngine;

namespace Hybel.Tweener
{
    /// <summary>
    /// An object which has values for lerping.
    /// </summary>
    public interface ILerpProvider
    {
        /// <summary>
        /// Get the data required to do a lerp in sync with the provider.
        /// </summary>
        public LerpData GetLerpData();
    }

    /// <summary>
    /// Helper struct to use when passing lerp information across objects.
    /// </summary>
    public readonly struct LerpData
    {
        private readonly float _min;
        private readonly float _max;
        private readonly float _evaluator;
        private readonly bool _clamped;

        /// <param name="min">The minimum value of the lerp.</param>
        /// <param name="max">The maximum value of the lerp.</param>
        /// <param name="evaluator">A value to use when evaluating.</param>
        /// <param name="clamped">Should the <paramref name="evaluator"/> value be clamped before the evaluation?</param>
        public LerpData(float min, float max, float evaluator, bool clamped = true)
        {
            _min = min;
            _max = max;
            _evaluator = evaluator;
            _clamped = clamped;
        }

        public float Min => _min;
        public float Max => _max;
        public float Evaluator => _evaluator;
        public bool Clamped => _clamped;

        /// <summary>
        /// Evaluate a lerp using the <see cref="Evaluator"/> value as the time.
        /// <para>If clamped is true, <see cref="Evaluator"/> will be clamped between 0 and 1 meaning this method will always return a value between <see cref="Min"/> and <see cref="Max"/>.</para>
        /// </summary>
        public float Lerp() => _clamped ? Mathf.Lerp(_min, _max, _evaluator) : Mathf.LerpUnclamped(_min, _max, _evaluator);

        /// <summary>
        /// Evaluate an inverse lerp using the <see cref="Evaluator"/> value as the input for which to get a time from.
        /// <para>If clamped is true, <see cref="Evaluator"/> will be clamped between <see cref="Min"/> and <see cref="Max"/> meaning this method will always return a value between 0 and 1.</para>
        /// </summary>
        public float InverseLerp() => Mathf.InverseLerp(_min, _max, _clamped ? Mathf.Clamp(_evaluator, _min, _max) : _evaluator);
    }
}
