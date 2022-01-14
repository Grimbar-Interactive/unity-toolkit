using UnityEngine;

namespace GI.UnityToolkit.Variables
{
    [CreateAssetMenu(menuName = "Variable/Vector3")]
    public class Vector3Variable : DefaultedVariable<Vector3>
    {
        #region PUBLIC_INTERFACE

        public static implicit operator Vector3(Vector3Variable variable)
        {
            return variable.Value;
        }

        #endregion PUBLIC_INTERFACE
    }
}