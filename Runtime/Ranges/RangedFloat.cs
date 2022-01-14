using UnityEngine;

namespace GI.UnityToolkit.Variables
{
    [System.Serializable]
    public struct RangedFloat
    {
        public float Min;
        public float Max;
        
        public float Random()
        {
            return UnityEngine.Random.Range(Min, Max);
        }

        public float Evaluate(float value)
        {
            return Mathf.Lerp(Min, Max, Mathf.Clamp01(value));
        }
    }
}