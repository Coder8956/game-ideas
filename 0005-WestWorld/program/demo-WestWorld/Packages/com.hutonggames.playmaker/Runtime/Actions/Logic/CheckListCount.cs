using System;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [PublicAPI]
    [ActionCategory(Category.LogicCollection)]
    [ConvertibleGroup("CheckList")]
    [ActionDescription("Check a list's item count against a condition.")]
    [HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.count")]
    public class CheckListCount : BaseTrueFalseAction
    {
        [BaseType(typeof(IList))]
        [Tooltip("The list variable to check.")]
        [SerializeReference] public IListVariableRef List;

        [MatchType(nameof(_count))]
        [Tooltip(Strings.ConditionTest)]
        public ConditionTest CheckIf = new ();

        private readonly IntegerRef _count = new();

        public override bool CanExecute() => CheckParameters(List);

        protected override bool Test() => CheckIf.Evaluate(List.ListVariable.Count);

        protected override string TrueSummary => "{List} count {CheckIf}";
        protected override string FalseSummary => "{List} count not {CheckIf}";
    }
}
