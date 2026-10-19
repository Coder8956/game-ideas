using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(ComponentVariable), typeof(bool), "isNotNull", false)]
    public class ComponentIsNotNullVariable : BaseVariableProperty<Component, bool>
    {
        public override string PropertyName => "isNotNull";

        private Component Component => Target?.GetValue() as Component;
        
#if UNITY_EDITOR
        public override string Description => "Is the Component not null?";
#endif

        public override bool Value
        {
            get => Component != null;
            set { }
        }
    }
}
