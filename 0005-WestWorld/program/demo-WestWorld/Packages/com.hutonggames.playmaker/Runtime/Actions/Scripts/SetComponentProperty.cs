
using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Script)]
    [ActionDescription("Set the value of a property in a Component.")]
    public class SetComponentProperty : BaseAction
    {
        [Tooltip("The Component to set a property in.")]
        [SerializeField]
        private ComponentVar _component;
        
        [MatchType(nameof(_component))]
        [SerializeField]
        private PropertySetter _setter;
        
        public override bool CanExecute() => CheckParameters(_component) && _setter.CanExecute();

        public override void Execute() => _setter.Execute(_component);

        public override string GetSummary() => _setter.GetSummary(nameof(_component), nameof(_setter));
    }
}
