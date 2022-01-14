using UnityEngine;

namespace GI.UnityToolkit.Variables
{
    [CreateAssetMenu(menuName = "Variable/Ranged/Int")]
    public class RangedIntVariable : DataObject
    {
        #region UNITY_EDITOR_INTERFACE

        public RangedInt Range;

        #endregion
        
        #region PUBLIC_INTERFACE

        public void SetValue(RangedInt range)
        {
            Range.Min = range.Min;
            Range.Max = range.Max;
        }

        public void SetValue(RangedIntVariable variable)
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