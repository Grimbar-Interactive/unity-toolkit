namespace GI.UnityToolkit.Variables
{
    [System.Serializable]
    public class IntReference
    {
        public int ConstantValue;
        public bool UseConstant = true;
        public IntVariable Variable;
        public int Value => UseConstant ? ConstantValue : Variable.Value;
        
        public IntReference() { }

        public IntReference(int value)
        {
            UseConstant = true;
            ConstantValue = value;
        }

        public static implicit operator int(IntReference reference)
        {
            return reference.Value;
        }
    }
}