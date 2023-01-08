using System.Collections.Generic;

namespace GI.UnityToolkit.Variables
{
    /// <summary>
    ///   Base class for generic variable queues
    /// </summary>
    public abstract class QueueVariable<T> : DefaultedVariable<Queue<T>>
    {
        public void Enqueue(T item)
        {
            Value.Enqueue(item);
            OnChangedEvent?.Invoke();
        }

        public T Dequeue()
        {
            var item = Value.Dequeue();
            OnChangedEvent?.Invoke();
            return item;
        }

        public T Peek => Value.Peek();

        public void Clear()
        {
            var originalLength = Value.Count;
            Value.Clear();
            if (Value.Count != originalLength)
            {
                OnChangedEvent?.Invoke();
            }
        }
    }
}