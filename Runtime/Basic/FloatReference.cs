namespace GI.UnityToolkit.Variables
{
    [System.Serializable]
    public class FloatReference
    {
        public float ConstantValue;
        public bool UseConstant = true;
        public FloatVariable Variable;
        public float Value => UseConstant ? ConstantValue : Variable.Value;
        
        public FloatReference() { }

        public FloatReference(float value)
        {
            UseConstant = true;
            ConstantValue = value;
        }

        public static implicit operator float(FloatReference reference)
        {
            return reference.Value;
        }
    }
}