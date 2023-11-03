using System;
using UnityEngine;

namespace GI.UnityToolkit.Variables
{
    [CreateAssetMenu(menuName = "Variable/Vector2")]
    public class Vector2Variable : PersistableVariable<Vector2>
    {
        #region PUBLIC_INTERFACE

        public static implicit operator Vector2(Vector2Variable variable)
        {
            return variable.Value;
        }

        #endregion PUBLIC_INTERFACE

        protected override Action<string, Vector2> GetSaveMethod()
        {
            return (id, value) =>
            {
                PlayerPrefs.SetFloat($"{id}_x", value.x);
                PlayerPrefs.SetFloat($"{id}_y", value.y);
            };
        }

        protected override Func<string, Vector2, Vector2> GetLoadMethod()
        {
            return (id, defaultValue) => new Vector3(
                PlayerPrefs.GetFloat($"{id}_x", defaultValue.x),
                PlayerPrefs.GetFloat($"{id}_y", defaultValue.y)
            );
        }
    }
}