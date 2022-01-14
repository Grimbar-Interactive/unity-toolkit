using UnityEngine;

namespace GI.UnityToolkit.Variables
{
    [CreateAssetMenu(menuName = "Variable/Unity/LayerMask")]
    public class LayerMaskVariable : DefaultedVariable<LayerMask>
    {
        #region PUBLIC_INTERFACE

        public static implicit operator LayerMask(LayerMaskVariable variable)
        {
            return variable == null ? default : variable.Value;
        }

        public static implicit operator int(LayerMaskVariable variable)
        {
            return variable == null ? 0 : (int)variable.Value;
        }
        
        #endregion PUBLIC_INTERFACE
    }
}