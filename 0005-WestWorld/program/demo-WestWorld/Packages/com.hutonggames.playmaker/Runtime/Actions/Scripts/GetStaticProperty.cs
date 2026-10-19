
using System;
using HutongGames.Reflection;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Script)]
    [ActionDescription("Get the value of a static property.")]
    public class GetStaticProperty : BaseAction
    {
        [Tooltip("The type that contains the static property.")]
        [SerializeField]
        private TypeReference _type;
        
        [MatchType(nameof(_type))]
        [SerializeField]
        private PropertyGetter _getter = new();
        
        public override bool CanExecute() => _getter.CanExecute(_type?.Type);

        public override void Execute() => _getter.Execute(_type?.Type);
        
        public override string GetSummary() => _getter.GetSummary(nameof(_type), nameof(_getter));
    }
}
