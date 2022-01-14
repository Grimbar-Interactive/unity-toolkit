using UnityEngine;

namespace GI.UnityToolkit.Variables
{
    [CreateAssetMenu(menuName = "Variable/String")]
    public class StringVariable : DefaultedVariable<string>
    {
        #region PUBLIC_INTERFACE

        public static implicit operator string(StringVariable variable)
        {
            return variable == null ? "" : variable.Value;
        }

        public static implicit operator bool(StringVariable stringVariable)
        {
            return string.IsNullOrEmpty(stringVariable) == false;
        }

        #endregion PUBLIC_INTERFACE
    }
}