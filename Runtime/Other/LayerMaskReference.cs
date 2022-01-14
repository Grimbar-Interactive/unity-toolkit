using UnityEngine;

namespace GI.UnityToolkit.Variables
{
    [System.Serializable]
    public class LayerMaskReference
    {
        public LayerMask ConstantValue;
        public bool UseConstant = true;
        public LayerMaskVariable Variable;

        public LayerMask Value => UseConstant ? ConstantValue : Variable.Value;

        public LayerMaskReference() { }

        public LayerMaskReference(LayerMask value)
        {
            UseConstant = true;
            ConstantValue = value;
        }

        public static implicit operator LayerMask(LayerMaskReference reference)
        {
            return reference.Value;
        }

        public static implicit operator int(LayerMaskReference reference)
        {
            return reference.Value;
        }
    }
}