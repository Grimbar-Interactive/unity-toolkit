using System;
using UnityEngine;

namespace GI.UnityToolkit.Variables
{
    [CreateAssetMenu(menuName = "Variable/String")]
    public class StringVariable : PersistableVariable<string>
    {
        #region PUBLIC_INTERFACE

        public static implicit operator string(StringVariable variable)
        {
            return variable == null ? "" : variable.Value;
        }

        public static implicit operator bool(StringVariable stringVariable)
        {
            return string.IsNullOrEmpty(stringVariable) == false;
        }

        #endregion PUBLIC_INTERFACE

        protected override Action<string, string> GetSaveMethod() => PlayerPrefs.SetString;

        protected override Func<string, string, string> GetLoadMethod() => PlayerPrefs.GetString;
    }
}