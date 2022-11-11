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

        // #if UNITY_EDITOR
//         protected void OnEnable()
//         {
//             EditorApplication.playModeStateChanged += OnPlayStateChange;
//         }
//         
//         protected void OnDisable()
//         {
//             EditorApplication.playModeStateChanged -= OnPlayStateChange;
//         }
//         
//         private void OnPlayStateChange(PlayModeStateChange state)
//         {
//             switch (state)
//             {
//                 case PlayModeStateChange.EnteredPlayMode:
//                     OnBegin();
//                     break;
//                 case PlayModeStateChange.ExitingPlayMode:
//                     OnEnd();
//                     break;
//                 case PlayModeStateChange.EnteredEditMode:
//                     break;
//                 case PlayModeStateChange.ExitingEditMode:
//                     break;
//                 default:
//                     throw new ArgumentOutOfRangeException(nameof(state), state, null);
//             }
//         }
// #else
//         protected void OnEnable()
//         {
//             OnBegin();
//         }
//  
//         protected void OnDisable()
//         {
//             OnEnd();
//         }
// #endif
    }
}