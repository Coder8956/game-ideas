
using System;
using HutongGames.Reflection;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Script)]
    [ActionDescription("Set the value of a static property.")]
    public class SetStaticProperty : BaseAction
    {
        [Tooltip("The type that contains the static property.")]
        [SerializeField]
        private TypeReference _type;
        
        [SerializeField, MatchType(nameof(_type)), StaticOnly]
        private PropertySetter _setter = new();
        
        public override bool CanExecute() => _setter.CanExecute(_type?.Type);

        public override void Execute() => _setter.Execute(_type?.Type);
        
        public override string GetSummary() => _setter.GetSummary(nameof(_type), nameof(_setter));
    }
}
