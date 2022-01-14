using UnityEngine;

namespace GI.UnityToolkit.Variables
{
    /// <summary>
    ///     A FloatVariable able to be saved to and loaded from a PlayerPref.
    /// </summary>
    [CreateAssetMenu(menuName = "Variable/Player Pref/Float")]
    public class FloatPrefVariable : FloatVariable, ISaveable
    {
        #region UNITY_EDITOR_INTERFACE

        [SerializeField] private string prefName = "";

        #endregion

        #region PUBLIC_INTERFACE

        public string GetName => prefName;

        public void Save()
        {
            UnityEngine.PlayerPrefs.SetFloat(prefName, Value);
        }

        public void Load()
        {
            Value = UnityEngine.PlayerPrefs.GetFloat(prefName, DefaultValue);
        }

        #endregion
    }
}