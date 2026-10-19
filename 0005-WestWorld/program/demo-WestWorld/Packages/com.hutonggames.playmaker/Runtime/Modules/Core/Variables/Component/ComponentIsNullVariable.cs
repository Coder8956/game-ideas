using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(ComponentVariable), typeof(bool), "isNull", false)]
    public class ComponentIsNullVariable : BaseVariableProperty<Component, bool>
    {
        public override string PropertyName => "isNull";

        private Component Component => Target?.GetValue() as Component;
        
#if UNITY_EDITOR
        public override string Description => "Is the Component null?";
#endif

        public override bool Value
        {
            get => Component == null;
            set { }
        }
    }
}
