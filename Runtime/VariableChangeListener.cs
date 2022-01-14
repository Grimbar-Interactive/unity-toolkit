using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace GI.UnityToolkit.Variables
{
    public class VariableChangeListener : MonoBehaviour
    {
        [Title("Variable"), SerializeField] private Variable variable = null;
        [Title("Response"), SerializeField] private UnityEvent onChangeEvent = default;

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