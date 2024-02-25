using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#else
using GI.UnityToolkit.Attributes;
#endif

namespace GI.UnityToolkit.Variables.Listeners
{
    public class BoolVariableListener : MonoBehaviour
    {
        private enum Mode
        {
            Single,
            Multiple
        }
        
        private enum ComparisonType
        {
            All,
            Any
        }

        [SerializeField] private Mode mode;
        
        [ShowIf(nameof(mode), Mode.Single)]
        [SerializeField] private BoolVariable variable;

        [ShowIf(nameof(mode), Mode.Multiple)]
        [SerializeField] private List<BoolVariable> variables;
        [ShowIf(nameof(mode), Mode.Multiple)]
        [SerializeField] private ComparisonType Comparison;
        
        private bool NoVariables => (mode == Mode.Single && variable == null) ||
                                    (mode == Mode.Multiple && (variables == null || variables.Count == 0));
#if ODIN_INSPECTOR
        [Title("Events"), HideIfGroup("Events", Condition = nameof(NoVariables))]
#else
        [Header("Events"), HideIf(nameof(NoVariables))]
#endif
        [SerializeField]
        private UnityEvent onTrue;

#if ODIN_INSPECTOR
        [HideIfGroup("Events", Condition = nameof(NoVariables))]
#else
        [HideIf(nameof(NoVariables))]
#endif
        [SerializeField] private UnityEvent onFalse;

        private bool _currentValue = false;
        
        private void OnEnable()
        {
            switch (mode)
            {
                case Mode.Single:
                    variable.AddListener(OnChanged);
                    break;
                case Mode.Multiple:
                    variables.ForEach(v => v.AddListener(OnChanged));
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            _currentValue = !GetCurrentValue();
            OnChanged();
        }

        private void OnDisable()
        {
            switch (mode)
            {
                case Mode.Single:
                    variable.RemoveListener(OnChanged);
                    break;
                case Mode.Multiple:
                    variables.ForEach(v => v.RemoveListener(OnChanged));
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void OnChanged()
        {
            var value = GetCurrentValue();
            if (mode == Mode.Multiple && _currentValue == value) return;
            _currentValue = value;
            if (_currentValue)
            {
                onTrue?.Invoke();
            }
            else
            {
                onFalse?.Invoke();
            }
        }

        private bool GetCurrentValue()
        {
            return mode switch
            {
                Mode.Single => variable.Value,
                Mode.Multiple => Comparison switch
                {
                    ComparisonType.All => variables.All(v => v.Value),
                    ComparisonType.Any => variables.Any(v => v.Value),
                    _ => throw new ArgumentOutOfRangeException()
                },
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}