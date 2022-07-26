using UnityEngine;

namespace GI.UnityToolkit.Variables
{
    public abstract class ManagedObject : ScriptableObject
    {
        protected abstract void OnBegin();
        protected abstract void OnEnd();

        protected void OnEnable()
        {
            OnBegin();
        }
 
        protected void OnDisable()
        {
            OnEnd();
        }
    }
}