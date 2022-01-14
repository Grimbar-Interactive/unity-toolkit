namespace GI.UnityToolkit.Variables
{
    [System.Serializable]
    public class BoolReference
    {
        public bool ConstantValue;
        public bool UseConstant = true;
        public BoolVariable Variable;
        public bool Value => UseConstant ? ConstantValue : Variable.Value;
        
        public BoolReference() { }

        public BoolReference(bool value)
        {
            UseConstant = true;
            ConstantValue = value;
        }

        public static implicit operator bool(BoolReference reference)
        {
            return reference.Value;
        }
    }
}