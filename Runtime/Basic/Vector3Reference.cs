using UnityEngine;

namespace GI.UnityToolkit.Variables
{
    [System.Serializable]
    public class Vector3Reference
    {
        public Vector3 ConstantValue;
        public bool UseConstant = true;
        public Vector3Variable Variable;
        public Vector3 Value => UseConstant ? ConstantValue : Variable.Value;
        
        public Vector3Reference() { }

        public Vector3Reference(Vector3 value)
        {
            UseConstant = true;
            ConstantValue = value;
        }

        public static implicit operator Vector3(Vector3Reference reference)
        {
            return reference.Value;
        }
    }
}