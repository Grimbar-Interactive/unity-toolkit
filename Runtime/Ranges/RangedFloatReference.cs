namespace GI.UnityToolkit.Variables
{
    [System.Serializable]
    public class RangedFloatReference
    {
        public RangedFloat ConstantValue;
        public bool UseConstant = true;
        public RangedFloatVariable Variable;

        public RangedFloat Value => UseConstant ? ConstantValue : Variable.Range;

        public RangedFloatReference() { }

        public RangedFloatReference(RangedFloat value)
        {
            UseConstant = true;
            ConstantValue = value;
        }

        public RangedFloatReference(float min, float max)
        {
            UseConstant = true;
            ConstantValue = new RangedFloat {Min = min, Max = max};
        }

        public static implicit operator RangedFloat(RangedFloatReference reference)
        {
            return reference.Value;
        }
    }
}