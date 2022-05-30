using UnityEngine;

#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif

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

#if ODIN_INSPECTOR
        [Title("Default"), PropertyOrder(2)]
#else
        [Header("Default")]
#endif
        [Tooltip("Value will be set to this whenever this variable is reset.")]
        public T DefaultValue;

#if ODIN_INSPECTOR
        [PropertyOrder(2)]
#endif
        [Tooltip("Set this to false if you don't want to reset to default value on enable.")]
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