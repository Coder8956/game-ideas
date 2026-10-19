using UnityEngine;

namespace HutongGames.PlayMaker
{
    [System.Serializable]
    public abstract class BaseTransformProperty<T> : BaseVariableProperty<Transform, T>
    {
        protected Transform Transform => TargetAs<Variable<Transform>>()?.Value;
    }
}
