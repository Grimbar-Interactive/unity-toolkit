using UnityEngine;

namespace GI.UnityToolkit.Variables
{
    /// <summary>
    /// ScriptableObject type that has hooks for when the game enters and exits play mode.
    /// </summary>
    public abstract class ManagedObject : ScriptableObject
    {
        protected virtual void OnBegin() {}
        protected virtual void OnEnd() {}
        
#if UNITY_EDITOR
        private void OnEnable()
        {
            if (UnityEditor.EditorApplication.isPlayingOrWillChangePlaymode)
            {
                OnBegin();
            }
            
            UnityEditor.EditorApplication.playModeStateChanged += OnPlayStateChange;
        }

        private void OnDisable()
        {
            UnityEditor.EditorApplication.playModeStateChanged -= OnPlayStateChange;
        }

        private void OnPlayStateChange(UnityEditor.PlayModeStateChange state)
        {
            if (state == UnityEditor.PlayModeStateChange.ExitingPlayMode) {
                OnEnd();
            }
        }
#else
        /// <summary>
        /// Runs the OnBegin() method in builds.
        /// </summary>
        private void Awake()
        {
            OnBegin();
        }
        
        /// <summary>
        /// Runs the OnEnd() method in builds.
        /// </summary>
        private void OnDestroy()
        {
            OnEnd();
        }
#endif
    }
}