using UnityEngine;

namespace GI.UnityToolkit.Variables
{
    /// <summary>
    ///     Base class for all variables and states.
    /// </summary>
    [CreateAssetMenu(menuName = "Variable/Empty")]
    public class DataObject : ManagedObject
    {
        #region UNITY_EDITOR_INTERFACE

// Disable warnings about unused vars - this is for Editor viewing only
#pragma warning disable CS0414
        [SerializeField] [TextArea(3, 10)] private string DeveloperDescription = "";
#pragma warning restore CS0414

        #endregion UNITY_EDITOR_INTERFACE

        #region MANAGED_OBJECT

        protected override void OnBegin()
        {
#if !UNITY_EDITOR
            DeveloperDescription = null;
#endif
            // Don't want the object to die even if there are no references
            hideFlags |= HideFlags.DontUnloadUnusedAsset;
        }

        protected override void OnEnd()
        {
        }

        #endregion MANAGED_OBJECT
    }
}