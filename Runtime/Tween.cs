using System;
using System.Collections;
using UnityEngine;

namespace Hybel.Tweener
{
    public delegate T Getter<out T>();
    public delegate void Setter<in T>(T value);
    public delegate T From<out T>();
    public delegate T To<out T>();
    public delegate float TimeScaleHook();

    public static class Tween
    {
        public static Sequence Sequence() => new Sequence(8);
        
        /// <param name="capacity">Starting capacity of the internal Queue.</param>
        public static Sequence Sequence(int capacity) => new Sequence(capacity);
    }

    public class Tween<T> : ISequenceable
    {
        public event Action Complete;
        
        private readonly Getter<T> _getter;
        private readonly Setter<T> _setter;
        private readonly From<T> _from;
        private readonly To<T> _to;
        private readonly To<T> _toInverse;
        private readonly float _duration;
        private readonly Interpolation<T> _interpolation;
        private EaseFunction _easeFunc;

        private TimeScaleHook _timeScaleHook;
        private readonly bool _isTimeScaled;

        public Tween(Getter<T> getter, Setter<T> setter, Interpolation<T> interpolation, From<T> from, To<T> to, To<T> toInverse, float duration)
        {
            getter = getter ?? throw new ArgumentNullException(nameof(getter));
            setter = setter ?? throw new ArgumentNullException(nameof(setter));
            interpolation = interpolation ?? throw new ArgumentNullException(nameof(interpolation));
            from = from ?? throw new ArgumentNullException(nameof(from));
            to = to ?? throw new ArgumentNullException(nameof(to));
            
            _getter = getter;
            _setter = setter;
            _from = from;
            _to = to;
            _toInverse = toInverse;
            _duration = Mathf.Max(duration, 0f);
            _interpolation = interpolation;
            _easeFunc = Interpolate.Linear;

            _isTimeScaled = true;
        }

        private float Duration
        {
            get
            {
                if (!_isTimeScaled)
                    return _duration;

                TimeScaleHook timeScaleHook = _timeScaleHook ?? TweenerMono.DefaultTimeScaleHook;
                float timeScale = timeScaleHook();

                if (timeScale <= 0f)
                    return float.PositiveInfinity;

                return _duration / timeScale;
            }
        }

        public void Play() => TweenerMono.RunCoroutine(TweenRoutine());

        public void PlayReverse() => TweenerMono.RunCoroutine(TweenReverseRoutine());
        
        public Tween<T> SetEase(EaseFunction easeFunc)
        {
            _easeFunc = easeFunc;
            return this;
        }

        public Tween<T> SetEase(Ease ease)
        {
            _easeFunc = Interpolate.Ease(ease);
            return this;
        }

        public Tween<T> SetTimeScaleHook(TimeScaleHook timeScaleHook)
        {
            _timeScaleHook = timeScaleHook;
            return this;
        }

        private IEnumerator TweenRoutine()
        {
            float startTime = Time.unscaledTime;

            T from = _from();
            T to = _to();
            
            while (Time.unscaledTime <= startTime + Duration)
            {
                float time = (Time.unscaledTime - startTime) / Duration;
                T value = _interpolation(from, to, _easeFunc(time));
                _setter(value);
                yield return new WaitForEndOfFrame();
            }
            
            Complete?.Invoke();
        }
        
        private IEnumerator TweenReverseRoutine()
        {
            float startTime = Time.unscaledTime;

            T from = _from();
            T to = _toInverse();
            
            while (Time.unscaledTime <= startTime + Duration)
            {
                float time = (Time.unscaledTime - startTime) / Duration;
                T value = _interpolation(from, to, Interpolate.Reverse(_easeFunc, time));
                _setter(value);
                yield return new WaitForEndOfFrame();
            }
            
            Complete?.Invoke();
        }
    }
}
