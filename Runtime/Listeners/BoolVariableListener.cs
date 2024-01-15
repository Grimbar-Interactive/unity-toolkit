using UnityEngine;
using UnityEngine.Events;

#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif

namespace GI.UnityToolkit.Variables.Listeners
{
    public class BoolVariableListener : MonoBehaviour
    {
        [SerializeField] private BoolVariable variable;

#if ODIN_INSPECTOR
        private bool VariableIsNull => variable == null;

        [Title("Events"), HideIfGroup("Events", Condition = nameof(VariableIsNull))]
#else
        [Header("Events")]
#endif
        [SerializeField]
        private UnityEvent onTrue;

#if ODIN_INSPECTOR
        [HideIfGroup("Events", Condition = nameof(VariableIsNull))]
#endif
        [SerializeField] private UnityEvent onFalse;

        private void OnEnable()
        {
            variable.AddListener(OnChanged);
            OnChanged();
        }

        private void OnDisable()
        {
            variable.RemoveListener(OnChanged);
        }

        private void OnChanged()
        {
            if (variable.Value)
            {
                onTrue?.Invoke();
            }
            else
            {
                onFalse?.Invoke();
            }
        }
    }
}