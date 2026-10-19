
using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Script)]
    [ActionDescription("Get the value of a property in an Object.")]
    public class GetObjectProperty : BaseAction
    {
        [Tooltip("The Object to get a property from.")]
        [SerializeField]
        private ObjectVar _object;
        
        [MatchType(nameof(_object))]
        [SerializeField]
        private PropertyGetter _getter;
        
        public override bool CanExecute() => CheckParameters(_object) && _getter.CanExecute();

        public override void Execute() => _getter.Execute(_object.Value);
        
        public override string GetSummary() => _getter.GetSummary(nameof(_object), nameof(_getter));

    }
}
