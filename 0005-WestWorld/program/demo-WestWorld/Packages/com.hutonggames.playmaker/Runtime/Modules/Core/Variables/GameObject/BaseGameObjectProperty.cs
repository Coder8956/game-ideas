using UnityEngine;

namespace HutongGames.PlayMaker
{
    [System.Serializable]
    public abstract class BaseGameObjectProperty<T> : BaseVariableProperty<GameObject, T>
    {
        /// <summary>
        /// NOTE: We use Variable GameObject instead of GameObjectVariable
        /// to allow selection of OwnerValue variable.
        /// </summary>
        protected GameObject GameObject => (Target as Variable<GameObject>)?.Value;
    }
}
