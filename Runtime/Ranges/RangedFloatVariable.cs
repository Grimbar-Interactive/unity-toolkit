using UnityEngine;

namespace GI.UnityToolkit.Variables
{
    [CreateAssetMenu(menuName = "Variable/Ranged/Float")]
    public class RangedFloatVariable : DataObject
    {
        #region UNITY_EDITOR_INTERFACE

        public RangedFloat Range;

        #endregion
        
        #region PUBLIC_INTERFACE

        public void SetValue(RangedFloat range)
        {
            Range.Min = range.Min;
            Range.Max = range.Max;
        }

        public void SetValue(RangedFloatVariable variable)
        {
            Range.Min = variable.Range.Min;
            Range.Max = variable.Range.Max;
        }

        public override string ToString()
        {
            return $"[{Range.Min}, {Range.Max}]";
        }

        #endregion
    }
}