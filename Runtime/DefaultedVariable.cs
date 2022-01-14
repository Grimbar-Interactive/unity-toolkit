using Sirenix.OdinInspector;
using UnityEngine;

namespace GI.UnityToolkit.Variables
{
    /// <summary>
    ///     Variable class that has a default value it is set to on enable (or via code).
    /// </summary>
    public abstract class DefaultedVariable<T> : Variable<T>
    {
        #region UNITY_LIFECYCLE

        protected override void OnBegin()
        {
            base.OnBegin();
            if (DefaultOnEnable) Default();
        }

        #endregion UNITY_LIFECYCLE

        #region UNITY_EDITOR_INTERFACE

        [Title("Default")]
        [Tooltip("Value will be set to this whenever this variable is reset."), PropertyOrder(2)]
        public T DefaultValue;

        [Tooltip("Set this to false if you don't want to reset to default value on enable."), PropertyOrder(2)]
        public bool DefaultOnEnable = true;

        #endregion UNITY_EDITOR_INTERFACE

        #region PUBLIC_INTERFACE

        public override void Default()
        {
            var oldValue = Value;
            Value = DefaultValue;
            if (Value == null && oldValue != null || Value != null && !Value.Equals(oldValue)) OnChangedEvent?.Invoke();
        }

        public void SetDefaultValue(T value)
        {
            DefaultValue = value;
        }

        #endregion PUBLIC_INTERFACE
    }
}