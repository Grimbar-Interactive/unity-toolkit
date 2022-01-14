using UnityEngine;

namespace GI.UnityToolkit.Variables
{
    [CreateAssetMenu(menuName = "Variable/Vector2")]
    public class Vector2Variable : DefaultedVariable<Vector2>
    {
        #region PUBLIC_INTERFACE

        public static implicit operator Vector2(Vector2Variable variable)
        {
            return variable.Value;
        }

        #endregion PUBLIC_INTERFACE
    }
}