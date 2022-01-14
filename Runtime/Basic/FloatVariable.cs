using UnityEngine;

namespace GI.UnityToolkit.Variables
{
    [CreateAssetMenu(menuName = "Variable/Float")]
    public class FloatVariable : DefaultedVariable<float>
    {
        #region PUBLIC_INTERFACE

        public void ApplyChange(float amount)
        {
            Value += amount;
        }

        public void ApplyChange(FloatVariable amount)
        {
            Value += amount.Value;
        }

        public static implicit operator float(FloatVariable variable)
        {
            return variable == null ? 0 : variable.Value;
        }

        #endregion PUBLIC_INTERFACE
    }
}