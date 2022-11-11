using UnityEngine;

namespace GI.UnityToolkit.Variables
{
    public abstract class ManagedObject : ScriptableObject
    {
        protected abstract void OnBegin();
        protected abstract void OnEnd();
        
#if UNITY_EDITOR
        private void OnEnable()
        {
            if (UnityEditor.EditorApplication.isPlayingOrWillChangePlaymode)
            {
                OnBegin();
            }
        }

        private void OnDisable()
        {
            OnEnd();
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