using System;
using UnityEngine;
using UnityEditor;

namespace GI.UnityToolkit.Variables.Editor
{
    [CustomPropertyDrawer(typeof(RangedFloat), true)]
    public class RangedFloatDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            label = EditorGUI.BeginProperty(position, label, property);
            position = EditorGUI.PrefixLabel(position, label);

            var minProp = property.FindPropertyRelative("Min");
            var maxProp = property.FindPropertyRelative("Max");

            var minValue = minProp.floatValue;
            var maxValue = maxProp.floatValue;

            float rangeMin = 0;
            float rangeMax = 1;
            
            var ranges = (MinMaxFloatRangeAttribute[]) fieldInfo.GetCustomAttributes(typeof(MinMaxFloatRangeAttribute), true);
            if (ranges.Length > 0)
            {
                rangeMin = ranges[0].Min;
                rangeMax = ranges[0].Max;
            }

            const float rangeBoundsLabelWidth = 50f;

            var rangeBoundsLabel1Rect = new Rect(position) { width = rangeBoundsLabelWidth };
            minProp.floatValue = minValue = Mathf.Max((float) Math.Round(EditorGUI.FloatField(rangeBoundsLabel1Rect, minValue), 2), rangeMin);
            if (minValue > maxValue && !EditorGUIUtility.editingTextField)
            {
                maxProp.floatValue = maxValue = minValue;
            }

            var rangeBoundsLabel2Rect = new Rect(position);
            rangeBoundsLabel2Rect.xMin = rangeBoundsLabel2Rect.xMax - rangeBoundsLabelWidth;
            maxProp.floatValue = maxValue = Mathf.Min((float) Math.Round(EditorGUI.FloatField(rangeBoundsLabel2Rect, maxValue), 2), rangeMax);
            if (maxValue < minValue && !EditorGUIUtility.editingTextField)
            {
                minProp.floatValue = minValue = maxValue;
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
                minProp.floatValue = (float)Math.Round(minValue, 2);
                maxProp.floatValue = (float)Math.Round(maxValue, 2);
            }

            EditorGUI.EndProperty();
        }
    }
}