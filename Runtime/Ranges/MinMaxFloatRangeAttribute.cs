using System;

namespace GI.UnityToolkit.Variables
{
    public class MinMaxFloatRangeAttribute : Attribute
    {
        public float Min { get; private set; }
        public float Max { get; private set; }

        public MinMaxFloatRangeAttribute(float min, float max)
        {
            Min = min;
            Max = max;
        }
    }
}