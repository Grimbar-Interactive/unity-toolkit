using UnityEngine;

namespace GI.UnityToolkit.Variables
{
    /// <summary>
    ///     A StringVariable able to be saved to and loaded from a PlayerPref.
    /// </summary>
    [CreateAssetMenu(menuName = "Variable/Player Pref/String")]
    public class StringPrefVariable : StringVariable, ISaveable
    {
        #region UNITY_EDITOR_INTERFACE

        [SerializeField] private string prefName = "";

        #endregion

        #region PUBLIC_INTERFACE

        public string GetName => prefName;

        public void Save()
        {
            UnityEngine.PlayerPrefs.SetString(prefName, Value);
        }

        public void Load()
        {
            Value = UnityEngine.PlayerPrefs.GetString(prefName, DefaultValue);
        }

        #endregion
    }
}