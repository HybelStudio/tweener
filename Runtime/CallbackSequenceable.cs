using System;

namespace Hybel.Tweener
{
    public delegate void Callback();

    public class CallbackSequenceable : ISequenceable
    {
        public event Action Complete;
            
        private readonly Callback _callback;

        public CallbackSequenceable(Callback callback) => _callback = callback;

        public void Play()
        {
            _callback?.Invoke();
            Complete?.Invoke();
        }
        
        public void PlayReverse() => Play();
    }
}