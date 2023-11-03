using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;

#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#else
using NaughtyAttributes;
#endif

namespace GI.UnityToolkit.Variables
{
    /// <summary>
    /// Base class of all shareable variable types.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Variable<T> : Variable
    {
        #region UNITY_EDITOR_INTERFACE
        /// <summary>
        /// The value of the variable. Used internally and in the editor.
        /// </summary>
#if ODIN_INSPECTOR
        [Title("Variable"), PropertyOrder(1), OnValueChanged(nameof(OnValueChanged))]
#else
        [Header("Variable"), OnValueChanged(nameof(OnValueChanged))]
#endif
        [Tooltip("Current value this variable has in the game."), SerializeField]
        private T value = default;

        /// <summary>
        /// A default value for the variable.
        /// </summary>
#if ODIN_INSPECTOR
        [Title("Default"), PropertyOrder(2)]
#else
        [Header("Default")]
#endif
        [Tooltip("A default value for this variable. If the persistence method is \"Default\" then the variable will be set to this value on startup."), SerializeField]
        private T defaultValue = default;
        
        /// <summary>
        /// How the value of the variable is set at startup.
        ///     None
        ///         - The value is not deliberately changed at startup.
        /// 
        ///     Reset To Default
        ///         - The value is set to the specified default value at startup.
        /// 
        ///     Save Between Sessions
        ///         - Changes to the value are saved between app sessions.
        /// </summary>
#if ODIN_INSPECTOR
        [Title("Persistence"), PropertyOrder(2), ValueDropdown("AvailablePersistenceModes")]
#else
        [Header("Persistence"), Dropdown("AvailablePersistenceModes")]
#endif
        [Tooltip("How the value of this variable is handled at startup"), SerializeField]
        protected PersistenceMode PersistenceMode = PersistenceMode.ResetToDefault;
        
        #endregion UNITY_EDITOR_INTERFACE

        #region PUBLIC_INTERFACE
        public T Value
        {
            get => value;
            set
            {
                var oldValue = this.value;
                this.value = value;
                if (this.value == null && oldValue != null || this.value != null && !this.value.Equals(oldValue)) OnValueChanged();
            }
        }
        
        public T DefaultValue => defaultValue;
        
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
        /// Sets the variable to its specified default value.
        /// </summary>
        public void Default()
        {
            var oldValue = Value;
            Value = DefaultValue;
            if (Value == null && oldValue != null || Value != null && !Value.Equals(oldValue)) OnValueChanged();
        }
        #endregion PUBLIC_INTERFACE
        
        #region OVERRIDES
        protected override void OnBegin()
        {
            base.OnBegin();
            if (PersistenceMode == PersistenceMode.ResetToDefault) Default();
        }
        #endregion
        
        [UsedImplicitly]
        protected virtual PersistenceMode[] AvailablePersistenceModes => new[] { PersistenceMode.None, PersistenceMode.ResetToDefault };
        
        protected virtual void OnValueChanged()
        {
            if (Application.isPlaying == false) return;
            OnChangedEvent?.Invoke();
        }
    }

    public abstract class Variable : DataObject
    {
#if ODIN_INSPECTOR
        [Title("Events"), PropertyOrder(4)]
#else
        [Header("Events")]
#endif
        [SerializeField] protected UnityEvent OnChangedEvent = default;
        
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