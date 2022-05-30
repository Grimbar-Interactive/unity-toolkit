using UnityEngine;
using UnityEngine.Events;

#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif

namespace GI.UnityToolkit.Variables
{
    public class VariableChangeListener : MonoBehaviour
    {
#if ODIN_INSPECTOR
        [Title("Variable")]
#else
        [Header("Variable")]
#endif
        [SerializeField] private Variable variable = null;
        
#if ODIN_INSPECTOR
        [Title("Response")]
#else
        [Header("Response")]
#endif
        [SerializeField] private UnityEvent onChangeEvent = default;

        private void OnEnable()
        {
            variable.AddListener(InvokeEvent);
        }

        private void OnDisable()
        {
            variable.RemoveListener(InvokeEvent);
        }

        private void InvokeEvent()
        {
            onChangeEvent?.Invoke();
        }
    }
}