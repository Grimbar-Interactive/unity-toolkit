using UnityEngine;

namespace GI.UnityToolkit.Variables
{
    [CreateAssetMenu(menuName = "Variable/Bool")]
    public class BoolVariable : DefaultedVariable<bool>
    {
        #region PUBLIC_INTERFACE

        public static implicit operator bool(BoolVariable variable)
        {
            return variable != null && variable.Value;
        }

        #endregion PUBLIC_INTERFACE
    }
}