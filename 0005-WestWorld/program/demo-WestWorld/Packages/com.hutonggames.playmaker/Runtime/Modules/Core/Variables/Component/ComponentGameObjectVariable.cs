using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(ComponentVariable), typeof(GameObject), "gameObject", false)]
    public class ComponentGameObjectVariable : BaseVariableProperty<Component, GameObject>
    {
        public override string PropertyName => "gameObject";

#if UNITY_EDITOR
        public override string Description => "The Component's GameObject.";
#endif

        private Component Component => Target?.GetValue() as Component;

        public override GameObject Value
        {
            get => Component ? Component.gameObject : null;
            set { }
        }
    }
}
