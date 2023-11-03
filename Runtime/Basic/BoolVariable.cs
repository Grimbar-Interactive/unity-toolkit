using System;
using UnityEngine;

namespace GI.UnityToolkit.Variables
{
    [CreateAssetMenu(menuName = "Variable/Bool")]
    public class BoolVariable : PersistableVariable<bool>
    {
        #region PUBLIC_INTERFACE

        public static implicit operator bool(BoolVariable variable)
        {
            return variable != null && variable.Value;
        }

        public void Toggle()
        {
            Value = !Value;
        }

        #endregion PUBLIC_INTERFACE

        protected override Action<string, bool> GetSaveMethod()
        {
            return (id, value) => PlayerPrefs.SetInt(id, value ? 1 : 0);
        }

        protected override Func<string, bool, bool> GetLoadMethod()
        {
            return (id, defaultValue) => PlayerPrefs.GetInt(id, defaultValue ? 1 : 0) == 1;
        }
    }
}