using UnityEngine;

namespace GI.UnityToolkit.Variables
{
    /// <summary>
    /// Represents a range of possible values.
    /// </summary>
    [System.Serializable]
    public class MinMaxType<T>
    {
        #region UNITY_EDITOR_INTERFACE

        [SerializeField] public T Min;
        [SerializeField] public T Max;

        #endregion

        #region PUBLIC_INTERFACE

        public MinMaxType(T value)
        {
            Min = value;
            Max = value;
        }

        public MinMaxType(T min, T max)
        {
            Min = min;
            Max = max;
        }

        public override string ToString()
        {
            return "[" + Min + " - " + Max + "]";
        }

        #endregion PUBLIC_INTERFACE
    }
}