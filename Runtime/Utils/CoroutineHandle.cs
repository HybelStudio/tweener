using System;
using System.Collections;
using UnityEngine;

namespace Hybel
{
    public class CoroutineHandle : IEnumerator
    {
        public event Action<CoroutineHandle> OnComplete;
        public bool IsDone { get; private set; }
        public bool MoveNext() => !IsDone;
        public object Current { get; }
        public void Reset() { }

        public CoroutineHandle(MonoBehaviour behaviour, IEnumerator coroutine) =>
            Current = behaviour.StartCoroutine(Wrap(coroutine));

        private IEnumerator Wrap(IEnumerator coroutine)
        {
            yield return coroutine;
            IsDone = true;
            OnComplete?.Invoke(this);
        }
    }

    public static class CoroutineHandleExtensions
    {
        public static CoroutineHandle RunCoroutine(
            this MonoBehaviour behaviour,
            IEnumerator coroutine) =>
                new CoroutineHandle(behaviour, coroutine);
    }
}
