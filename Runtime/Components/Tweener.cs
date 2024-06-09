using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Hybel.Tweener
{
    public class Tweener : MonoBehaviour, ILerpProvider
    {
        [SerializeField] protected EaseOrCurve easeIn;
        [SerializeField] protected AnimationCurve curveIn = AnimationCurve.Linear(0f, 0, 1f, 1f);
        [SerializeField] protected float easeInSeconds = 1f;

        [SerializeField] protected EaseOrCurve easeOut;
        [SerializeField] protected AnimationCurve curveOut = AnimationCurve.Linear(0f, 0, 1f, 1f);
        [SerializeField] protected float easeOutSeconds = 1f;
        [Space]
        public UnityEvent<float> ValueChanged;

        protected EaseFunction _easeInFunction;
        protected EaseFunction _easeOutFunction;

        private float _currentValue;
        private Coroutine _currentRoutine;

        public float CurrentValue
        {
            get => _currentValue;
            private set
            {
                _currentValue = value;
                ValueChanged?.Invoke(_currentValue);
            }
        }

        public bool IsPlaying { get; private set; }

        protected EaseFunction easeInFunction => _easeInFunction;
        protected EaseFunction easeOutFunction => _easeOutFunction;

        protected virtual void Awake()
        {
            CurrentValue = 0f;
            CreateEaseFunctions();
        }

        private void OnValidate() => CreateEaseFunctions();

        [ContextMenu("Play Forwards")]
        public void PlayForwards()
        {
            if (IsPlaying)
                return;

            StartCoroutine(ForwardsRoutine());
        }

        [ContextMenu("Play Backwards")]
        public void PlayBackwards()
        {
            if (IsPlaying)
                return;

            StartCoroutine(BackwardsRoutine());
        }

        [ContextMenu("Stop")]
        public void Stop()
        {
            if (!IsPlaying)
                return;

            StopCoroutine(_currentRoutine);
            IsPlaying = false;
        }

        public LerpData GetLerpData() => new LerpData(0f, 1f, CurrentValue, false);

        private IEnumerator ForwardsRoutine()
        {
            IsPlaying = true;
            float startTime = Time.time;

            while (Time.time <= startTime + easeInSeconds)
            {
                float currentTime = (Time.time - startTime) / easeInSeconds;
                CurrentValue = _easeInFunction(currentTime);
                yield return null;
            }

            CurrentValue = _easeInFunction(1f);
            IsPlaying = false;
        }

        private IEnumerator BackwardsRoutine()
        {
            IsPlaying = true;
            float startTime = Time.time;

            while (Time.time <= startTime + easeOutSeconds)
            {
                float currentTime = 1f - (Time.time - startTime) / easeOutSeconds;
                CurrentValue = _easeOutFunction(currentTime);
                yield return null;
            }

            CurrentValue = _easeOutFunction(0f);
            IsPlaying = false;
        }

        private void CreateEaseFunctions()
        {
            if (easeIn == EaseOrCurve.Curve)
                _easeInFunction = Interpolate.FromCurve(curveIn);
            else
                _easeInFunction = Interpolate.Ease((Ease)easeIn);

            if (easeOut == EaseOrCurve.Curve)
                _easeOutFunction = Interpolate.FromCurve(curveOut);
            else
                _easeOutFunction = Interpolate.Ease((Ease)easeOut);
        }
    }
}
