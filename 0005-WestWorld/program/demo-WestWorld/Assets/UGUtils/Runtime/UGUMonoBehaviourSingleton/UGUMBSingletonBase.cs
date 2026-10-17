using UnityEngine;

namespace UGU.Runtime
{
    public abstract class UGUMBSingletonBase : MonoBehaviour
    {
        protected abstract void OnCreate();

        internal void InternalOnCreate()
        {
            OnCreate();
        }
    }
}