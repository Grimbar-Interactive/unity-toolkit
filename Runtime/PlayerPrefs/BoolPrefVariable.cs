using UnityEngine;

namespace GI.UnityToolkit.Variables
{
    /// <summary>
    ///     A BoolVariable able to be saved to and loaded from a PlayerPref.
    /// </summary>
    [CreateAssetMenu(menuName = "Variable/Player Pref/Bool")]
    public class BoolPrefVariable : BoolVariable, ISaveable
    {
        private const int TRUE = 1;
        private const int FALSE = 0;

        #region UNITY_EDITOR_INTERFACE

        [SerializeField] private string prefName = "";

        #endregion

        #region PUBLIC_INTERFACE

        public string GetName => prefName;

        public void Save()
        {
            UnityEngine.PlayerPrefs.SetInt(prefName, Value ? TRUE : FALSE);
        }

        public void Load()
        {
            Value = UnityEngine.PlayerPrefs.GetInt(prefName, DefaultValue ? TRUE : FALSE) == TRUE;
        }

        #endregion
    }
}