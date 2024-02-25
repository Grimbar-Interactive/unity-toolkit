using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#else
using GI.UnityToolkit.Attributes;
#endif

namespace GI.UnityToolkit.Variables
{
    public abstract class PersistableVariable<T> : Variable<T>
    {
        #region UNITY_EDITOR_INTERFACE
        /// <summary>
        /// The ID used to save this value, typically to PlayerPrefs.
        /// </summary>
#if ODIN_INSPECTOR
        [PropertyOrder(3), ShowIf("PersistenceMode", PersistenceMode.SaveBetweenSessions)]
#else
        [ShowIf("PersistenceMode", PersistenceMode.SaveBetweenSessions)]
#endif
        [Tooltip("The ID that the value is saved to in PlayerPrefs."), SerializeField]
        private string playerPrefID;
        #endregion
        
        #region OVERRIDES
        protected override PersistenceMode[] AvailablePersistenceModes => base.AvailablePersistenceModes
            .Concat(new[] { PersistenceMode.SaveBetweenSessions })
            .ToArray();
        
        protected override void OnValueChanged()
        {
            if (Application.isPlaying == false) return;
            OnChangedEvent?.Invoke();
            SaveValue();
        }

        protected override void OnBegin()
        {
            base.OnBegin();
            if (PersistenceMode == PersistenceMode.SaveBetweenSessions)
            {
                LoadValue();
            }
            else
            {
                ClearPref();
            }
        }
        #endregion
        
        private void SaveValue()
        {
            if (PersistenceMode != PersistenceMode.SaveBetweenSessions) return;

            if (string.IsNullOrEmpty(playerPrefID))
            {
                Debug.LogError($"[{GetType().Name}] Failed to save value for \"{name}\": playerPrefID is invalid!", this);
                return;
            }

            GetSaveMethod()?.Invoke(playerPrefID, Value);
            PlayerPrefs.Save();
        }

        private void LoadValue()
        {
            if (string.IsNullOrEmpty(playerPrefID))
            {
                Debug.LogError($"[{GetType().Name}] Failed to load value for \"{name}\": playerPrefID is invalid!", this);
                return;
            }

            SetValue(GetLoadMethod().Invoke(playerPrefID, DefaultValue));
        }

        protected abstract Action<string, T> GetSaveMethod();
        protected abstract Func<string, T, T> GetLoadMethod();

        protected void ClearPref()
        {
            if (string.IsNullOrEmpty(playerPrefID)) return;
            PlayerPrefs.DeleteKey(playerPrefID);
        }
    }
}