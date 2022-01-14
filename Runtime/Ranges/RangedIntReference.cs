namespace GI.UnityToolkit.Variables
{
    [System.Serializable]
    public class RangedIntReference
    {
        public RangedInt ConstantValue;
        public bool UseConstant = true;
        public RangedIntVariable Variable;

        public RangedInt Value => UseConstant ? ConstantValue : Variable.Range;

        public RangedIntReference() { }

        public RangedIntReference(RangedInt value)
        {
            UseConstant = true;
            ConstantValue = value;
        }

        public RangedIntReference(int min, int max)
        {
            UseConstant = true;
            ConstantValue = new RangedInt {Min = min, Max = max};
        }

        public static implicit operator RangedInt(RangedIntReference reference)
        {
            return reference.Value;
        }
    }
}