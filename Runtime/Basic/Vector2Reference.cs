using UnityEngine;

namespace GI.UnityToolkit.Variables
{
    [System.Serializable]
    public class Vector2Reference
    {
        public Vector2 ConstantValue;
        public bool UseConstant = true;
        public Vector2Variable Variable;
        public Vector2 Value => UseConstant ? ConstantValue : Variable.Value;
        
        public Vector2Reference() { }

        public Vector2Reference(Vector2 value)
        {
            UseConstant = true;
            ConstantValue = value;
        }

        public static implicit operator Vector2(Vector2Reference reference)
        {
            return reference.Value;
        }
    }
}