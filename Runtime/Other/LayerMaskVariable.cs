using UnityEngine;

namespace GI.UnityToolkit.Variables
{
    [CreateAssetMenu(menuName = "Variable/Unity/LayerMask")]
    public class LayerMaskVariable : Variable<LayerMask>
    {
        #region PUBLIC_INTERFACE

        public static implicit operator LayerMask(LayerMaskVariable variable)
        {
            return variable == null ? default : variable.Value;
        }

        public static implicit operator int(LayerMaskVariable variable)
        {
            return variable == null ? 0 : variable.Value.value;
        }
        
        #endregion PUBLIC_INTERFACE
    }
}