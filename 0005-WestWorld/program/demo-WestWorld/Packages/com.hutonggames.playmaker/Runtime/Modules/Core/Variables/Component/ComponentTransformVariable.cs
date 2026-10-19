using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(ComponentVariable), typeof(Transform), "transform", false)]
    public class ComponentTransformVariable : BaseVariableProperty<Component, Transform>
    {
        public override string PropertyName => "transform";

#if UNITY_EDITOR
        public override string Description => "The Component's Transform.";
#endif

        private Component Component => Target?.GetValue() as Component;

        public override Transform Value
        {
            get => Component ? Component.transform : null;
            set { }
        }
    }
}
