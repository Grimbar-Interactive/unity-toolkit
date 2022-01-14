namespace GI.UnityToolkit.Variables
{
    /// <summary>
    ///     A variable that can be saved/loaded as a PlayerPref
    /// </summary>
    public interface ISaveable
    {
        #region PUBLIC_INTERFACE

        string GetName { get; }

        /// <summary>
        ///     Saves the current value to the PlayerPref
        /// </summary>
        void Save();

        /// <summary>
        ///     Updates the value from the loaded PlayerPref
        /// </summary>
        void Load();

        #endregion PUBLIC_INTERFACE
    }
}