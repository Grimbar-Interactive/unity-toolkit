using UnityEngine;

namespace GI.UnityToolkit.Variables
{
    /// <summary>
    ///     An IntVariable able to be saved to and loaded from a PlayerPref.
    /// </summary>
    [CreateAssetMenu(menuName = "Variable/Player Pref/Int")]
    public class IntPrefVariable : IntVariable, ISaveable
    {
        #region UNITY_EDITOR_INTERFACE

        [SerializeField] private string prefName = "";

        #endregion

        #region PUBLIC_INTERFACE

        public string GetName => prefName;

        public void Save()
        {
            UnityEngine.PlayerPrefs.SetInt(prefName, Value);
        }

        public void Load()
        {
            Value = UnityEngine.PlayerPrefs.GetInt(prefName, DefaultValue);
        }

        #endregion
    }
}