using System;
using UnityEngine;

namespace GI.UnityToolkit.Variables
{
    [CreateAssetMenu(menuName = "Variable/Int")]
    public class IntVariable : PersistableVariable<int>
    {
        #region PUBLIC_INTERFACE

        public void Increment()
        {
            ++Value;
        }

        public void Decrement()
        {
            --Value;
        }

        public void ApplyChange(int amount)
        {
            Value += amount;
        }

        public void ApplyChange(IntVariable amount)
        {
            Value += amount.Value;
        }

        public static implicit operator int(IntVariable variable)
        {
            return variable == null ? 0 : variable.Value;
        }

        public static implicit operator bool(IntVariable intVariable)
        {
            return intVariable != null && intVariable.Value != 0;
        }

        #endregion PUBLIC_INTERFACE

        protected override Action<string, int> GetSaveMethod() => PlayerPrefs.SetInt;

        protected override Func<string, int, int> GetLoadMethod() => PlayerPrefs.GetInt;
    }
}