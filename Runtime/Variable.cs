using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace GI.UnityToolkit.Variables
{
    /// <summary>
    ///     Base class of all shareable variable types.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Variable<T> : Variable
    {
        #region UNITY_EDITOR_INTERFACE

        [Title("Variable")]
        [Tooltip("Current value this variable has in the game.")]
        [SerializeField, PropertyOrder(1)] private T value = default;
        public T Value
        {
            get => value;
            set
            {
                var oldValue = this.value;
                this.value = value;
                if (this.value == null && oldValue != null || this.value != null && !this.value.Equals(oldValue)) OnChangedEvent?.Invoke();
            }
        }

        #endregion UNITY_EDITOR_INTERFACE

        #region PUBLIC_INTERFACE

        public void SetValue(T newValue)
        {
            Value = newValue;
        }

        public void SetValue(Variable<T> newValue)
        {
            Value = newValue.Value;
        }
        
        public override string ToString()
        {
            return Value == null ? "[null]" : Value.ToString();
        }

        /// <summary>
        ///     Sets Value to the default value for the given type - "", 0, or null
        /// </summary>
        public virtual void Default()
        {
            Value = default;
        }

        #endregion PUBLIC_INTERFACE
    }

    public abstract class Variable : DataObject
    {
        [Title("Events")]
        [SerializeField, PropertyOrder(3)] protected UnityEvent OnChangedEvent = default;
        
        public void AddListener(UnityAction listener)
        {
            OnChangedEvent.AddListener(listener);
        }

        public void RemoveListener(UnityAction listener)
        {
            OnChangedEvent.RemoveListener(listener);
        }
    }
}