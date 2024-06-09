using System;
using System.Collections;
using UnityEngine;

namespace Hybel.Tweener
{
    public class IntervalSequenceable : ISequenceable
    {
        public event Action Complete;
            
        private readonly float _seconds;

        public IntervalSequenceable(float seconds) => _seconds = seconds;

        public void Play() => TweenerMono.RunCoroutine(IntervalRoutine(_seconds));
        public void PlayReverse() => Play();

        private IEnumerator IntervalRoutine(float seconds)
        {
            yield return new WaitForSecondsRealtime(seconds * TweenerMono.DefaultTimeScaleHook());
            Complete?.Invoke();
        }
    }
}