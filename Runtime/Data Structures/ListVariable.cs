using System.Collections.Generic;
using System.Linq;

namespace GI.UnityToolkit.Variables
{
    /// <summary>
    /// Base class for generic variable lists
    /// </summary>
    public abstract class ListVariable<T> : Variable<List<T>>
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
        
        public int Count => Value?.Count ?? 0;

        public new List<T> Value
        {
            get => base.Value;
            set
            {
                var original = base.Value;
                SetValueQuietly(new List<T>(value));
                if (!AreListsEqual(original, Value)) OnValueChanged();
            }
        }
        
        public override void SetValue(List<T> newValue)
        {
            Value = new List<T>(newValue);
        }

        public override void SetValue(Variable<List<T>> newValue)
        {
            Value = new List<T>(newValue.Value);
        }
        
        public override void Default()
        {
            var original = Value;
            Value = DefaultValue == null || DefaultValue.Count == 0 ? new List<T>() : new List<T>(DefaultValue);
            if (!AreListsEqual(original, Value)) OnChangedEvent?.Invoke();
        }

        private static bool AreListsEqual(IReadOnlyCollection<T> list1, IReadOnlyCollection<T> list2)
        {
            if (list1 == null && list2 == null) return true;
            if (list1 == null || list2 == null) return false;
            return list1.SequenceEqual(list2);
        }
    }
}