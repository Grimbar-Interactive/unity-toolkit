namespace GI.UnityToolkit.Variables
{
    [System.Serializable]
    public struct RangedInt
    {
        public int Min;
        public int Max;
        
        public int Random()
        {
            return UnityEngine.Random.Range(Min, Max);
        }
    }
}