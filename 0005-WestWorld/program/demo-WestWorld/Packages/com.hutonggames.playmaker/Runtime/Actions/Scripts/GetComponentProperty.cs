
using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Script)]
    [ActionDescription("Get the value of a property in a Component.")]
    public class GetComponentProperty : BaseAction
    {
        [Tooltip("The Component to get a property from.")]
        [SerializeField]
        private ComponentVar _component;
        
        [MatchType(nameof(_component))]
        [SerializeField]
        private PropertyGetter _getter;
        
        public override bool CanExecute() => CheckParameters(_component) && _getter.CanExecute();

        public override void Execute() => _getter.Execute(_component.Value);
        
        public override string GetSummary() => _getter.GetSummary(nameof(_component), nameof(_getter));

    }
}
