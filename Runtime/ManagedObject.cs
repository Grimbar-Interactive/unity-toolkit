using System;
using UnityEditor;
using UnityEngine;

namespace GI.UnityToolkit.Variables
{
    public abstract class ManagedObject : ScriptableObject
    {
        protected abstract void OnBegin();
        protected abstract void OnEnd();

#if UNITY_EDITOR
        protected void OnEnable()
        {
            EditorApplication.playModeStateChanged += OnPlayStateChange;
        }

        protected void OnDisable()
        {
            EditorApplication.playModeStateChanged -= OnPlayStateChange;
        }

        private void OnPlayStateChange(PlayModeStateChange state)
        {
            switch (state)
            {
                case PlayModeStateChange.EnteredPlayMode:
                    OnBegin();
                    break;
                case PlayModeStateChange.ExitingPlayMode:
                    OnEnd();
                    break;
                case PlayModeStateChange.EnteredEditMode:
                    break;
                case PlayModeStateChange.ExitingEditMode:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }
#else
        protected void OnEnable()
        {
            OnBegin();
        }
 
        protected void OnDisable()
        {
            OnEnd();
        }
#endif
    }
}