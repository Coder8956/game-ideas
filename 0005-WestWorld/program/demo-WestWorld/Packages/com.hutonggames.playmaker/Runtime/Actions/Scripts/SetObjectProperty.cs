
using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Script)]
    [ActionDescription("Set the value of a property in an Object.")]
    public class SetObjectProperty : BaseAction
    {
        [Tooltip("The Object to set a property in.")]
        [SerializeField]
        private ObjectVar _object;
        
        [MatchType(nameof(_object))]
        [SerializeField]
        private PropertySetter _setter;
        
        public override bool CanExecute() => CheckParameters(_object) && _setter.CanExecute();

        public override void Execute() => _setter.Execute(_object);
        
        public override string GetSummary() => _setter.GetSummary(nameof(_object), nameof(_setter));
    }
}
