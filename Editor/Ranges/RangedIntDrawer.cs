using UnityEngine;
using UnityEditor;

namespace GI.UnityToolkit.Variables.Editor
{
    [CustomPropertyDrawer(typeof(RangedInt), true)]
    public class RangedIntDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            label = EditorGUI.BeginProperty(position, label, property);
            position = EditorGUI.PrefixLabel(position, label);

            var minProp = property.FindPropertyRelative("Min");
            var maxProp = property.FindPropertyRelative("Max");

            float minValue = minProp.intValue;
            float maxValue = maxProp.intValue;

            var rangeMin = 0;
            var rangeMax = 100;

            var ranges = (MinMaxIntRangeAttribute[]) fieldInfo.GetCustomAttributes(typeof(MinMaxIntRangeAttribute), true);
            if (ranges.Length > 0)
            {
                rangeMin = ranges[0].Min;
                rangeMax = ranges[0].Max;
            }
            
            const float rangeBoundsLabelWidth = 50f;

            var rangeBoundsLabel1Rect = new Rect(position) { width = rangeBoundsLabelWidth };
            minProp.intValue = Mathf.Max(EditorGUI.IntField(rangeBoundsLabel1Rect, Mathf.RoundToInt(minValue)), rangeMin);
            if (minValue > maxValue && !EditorGUIUtility.editingTextField)
            {
                maxValue = minValue;
                maxProp.intValue = (int) maxValue;
            }

            var rangeBoundsLabel2Rect = new Rect(position);
            rangeBoundsLabel2Rect.xMin = rangeBoundsLabel2Rect.xMax - rangeBoundsLabelWidth;
            maxProp.intValue = Mathf.Min(EditorGUI.IntField(rangeBoundsLabel2Rect, Mathf.RoundToInt(maxValue)), rangeMax);
            if (maxValue < minValue && !EditorGUIUtility.editingTextField)
            {
                minValue = maxValue;
                minProp.intValue = (int) maxValue;
            }

            EditorGUI.BeginChangeCheck();
            var sliderRect = new Rect(position)
            {
                x = position.x + rangeBoundsLabelWidth + 5,
                width = position.width - (2f * rangeBoundsLabelWidth) - 10
            };
            EditorGUI.MinMaxSlider(sliderRect, ref minValue, ref maxValue, rangeMin, rangeMax);
            if (EditorGUI.EndChangeCheck())
            {
                minProp.intValue = Mathf.RoundToInt(minValue);
                maxProp.intValue = Mathf.RoundToInt(maxValue);
            }

            EditorGUI.EndProperty();
        }
    }
}