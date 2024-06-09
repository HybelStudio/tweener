using System.Collections.Generic;

namespace Hybel.Tweener
{
    public class Sequence
    {
        private readonly QueueStack<ISequenceable> _sequenceQueue;

        public Sequence() => _sequenceQueue = new QueueStack<ISequenceable>();

        /// <param name="capacity">Starting capacity of the internal Queue.</param>
        public Sequence(int capacity) => _sequenceQueue = new QueueStack<ISequenceable>(capacity);

        /// <summary>
        /// Append any sequenceable operation to the sequence.
        /// </summary>
        /// <returns>Itself.</returns>
        public Sequence Append(ISequenceable sequenceable)
        {
            _sequenceQueue.Enqueue(sequenceable);
            return this;
        }

        /// <summary>
        /// Repeats the previous entry a number of times equal to <paramref name="repetitions"/>.
        /// </summary>
        /// <param name="repetitions">Number of repetitions. The amount of calls will equals this number.</param>
        /// <returns>Itself.</returns>
        public Sequence Repeat(int repetitions)
        {
            if (!_sequenceQueue.TryStackPeek(out ISequenceable item))
                return this;

            for (int i = 0; i < repetitions - 1; i++)
                _sequenceQueue.Enqueue(item);

            return this;
        }
        
        /// <summary>
        /// Repeats the <paramref name="depth"/> previous entries a number of times equal to <paramref name="repetitions"/>.
        /// </summary>
        /// <param name="depth">How many of the previous items should be repeated.</param>
        /// <param name="repetitions">Number of repetitions. The amount of calls will equals this number.</param>
        /// <returns>Itself.</returns>
        public Sequence Repeat(int depth, int repetitions)
        {
            var items = new ISequenceable[depth];

            for (int i = depth - 1; i >= 0; i--)
            {
                if (!_sequenceQueue.TryPop(out ISequenceable item))
                {
                    for (int j = 0; j < depth; j++)
                        _sequenceQueue.Push(items[i]);
                    
                    return this;
                }

                items[i] = item;
            }

            for (int i = 0; i < repetitions; i++)
                for (int j = 0; j < depth; j++)
                    _sequenceQueue.Enqueue(items[j]);

            return this;
        }

        /// <summary>
        /// Play the sequence.
        /// </summary>
        public void Play()
        {
            if (_sequenceQueue.Count == 0)
                return;

            PlayNext();
        }

        public void PlayReverse()
        {
            if (_sequenceQueue.Count == 0)
                return;

            PlayNextReverse();
        }

        // This method creates a recursion effect using events.
        // Using the local function to capture the 'next' variable we can unsubscribe to the event to avoid any shenanigans.
        private void PlayNext()
        {
            if (!_sequenceQueue.TryDequeue(out ISequenceable next))
                return;
            
            next.Complete += PlayNextAndUnSubscribe;
            next.Play();

            void PlayNextAndUnSubscribe()
            {
                next.Complete -= PlayNextAndUnSubscribe;
                PlayNext();
            }
        }
        
        // This method creates a recursion effect using events.
        // Using the local function to capture the 'next' variable we can unsubscribe to the event to avoid any shenanigans.
        private void PlayNextReverse()
        {
            if (!_sequenceQueue.TryPop(out ISequenceable next))
                return;
            
            next.Complete += PlayNextAndUnSubscribe;
            next.PlayReverse();

            void PlayNextAndUnSubscribe()
            {
                next.Complete -= PlayNextAndUnSubscribe;
                PlayNextReverse();
            }
        }
    }

    public static class SequenceExtensions
    {
        public static Sequence AppendInterval(this Sequence sequence, float seconds) =>
            sequence.Append(new IntervalSequenceable(seconds));

        public static Sequence AppendCallback(this Sequence sequence, Callback callback) =>
            sequence.Append(new CallbackSequenceable(callback));
    }
}
