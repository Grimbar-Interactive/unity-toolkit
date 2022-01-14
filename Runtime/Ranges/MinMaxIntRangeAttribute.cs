using System;

namespace GI.UnityToolkit.Variables
{
    public class MinMaxIntRangeAttribute : Attribute
    {
        public int Min { get; private set; }
        public int Max { get; private set; }

        public MinMaxIntRangeAttribute(int min, int max)
        {
            Min = min;
            Max = max;
        }
    }
}