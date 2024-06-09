using System;

namespace Hybel.Tweener
{
    /// <summary>
    /// Implement this if you want your type to be able to be sequenced in a <see cref="Sequence"/>.
    /// </summary>
    public interface ISequenceable
    {
        /// <summary>
        /// This is called when the sequence has reached this item.
        /// </summary>
        public void Play();

        /// <summary>
        /// This is called the sequence has reached this item and is running in reverse.
        /// </summary>
        public void PlayReverse();
        
        /// <summary>
        /// This should be invoked when the <see cref="Play"/> is done.
        /// <para>If you're calling into a coroutine from the <see cref="Play"/> method, invoke this at the end of the coroutine.</para>
        /// </summary>
        public event Action Complete;
    }
}