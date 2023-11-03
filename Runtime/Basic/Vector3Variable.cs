using System;
using UnityEngine;

namespace GI.UnityToolkit.Variables
{
    [CreateAssetMenu(menuName = "Variable/Vector3")]
    public class Vector3Variable : PersistableVariable<Vector3>
    {
        #region PUBLIC_INTERFACE

        public static implicit operator Vector3(Vector3Variable variable)
        {
            return variable.Value;
        }

        #endregion PUBLIC_INTERFACE

        protected override Action<string, Vector3> GetSaveMethod()
        {
            return (id, value) =>
            {
                PlayerPrefs.SetFloat($"{id}_x", value.x);
                PlayerPrefs.SetFloat($"{id}_y", value.y);
                PlayerPrefs.SetFloat($"{id}_z", value.z);
            };
        }

        protected override Func<string, Vector3, Vector3> GetLoadMethod()
        {
            return (id, defaultValue) => new Vector3(
                PlayerPrefs.GetFloat($"{id}_x", defaultValue.x),
                PlayerPrefs.GetFloat($"{id}_y", defaultValue.y),
                PlayerPrefs.GetFloat($"{id}_z", defaultValue.z)
            );
        }
    }
}