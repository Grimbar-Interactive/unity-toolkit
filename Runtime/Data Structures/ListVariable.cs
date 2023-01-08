using System.Collections.Generic;

namespace GI.UnityToolkit.Variables
{
    /// <summary>
    ///   Base class for generic variable lists
    /// </summary>
    public abstract class ListVariable<T> : DefaultedVariable<List<T>>
    {
        public void Add(T item)
        {
            Value.Add(item);
            OnChangedEvent?.Invoke();
        }

        public void Remove(T item)
        {
            if (Value.Remove(item))
            {
                OnChangedEvent?.Invoke();
            }
        }

        public void RemoveAt(int index)
        {
            if (Value.Count <= index || index <= 0) return;
            Value.RemoveAt(index);
            OnChangedEvent?.Invoke();
        }
    }
}