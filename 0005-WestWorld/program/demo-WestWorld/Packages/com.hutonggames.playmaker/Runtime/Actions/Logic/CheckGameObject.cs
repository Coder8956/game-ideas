using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.LogicValue)]
    [ConvertibleGroup("CheckGameObject")]
    [ActionDescription("Check a GameObject value against a condition.")]
    public class CheckGameObject : BaseTrueFalseAction
    {
        [Tooltip("The GameObject variable to check.")]
        public GameObjectRef GameObject;

        [MatchType(nameof(GameObject))]
        [Tooltip(Strings.ConditionTest)]
        public ConditionTest CheckIf = new ();
        
        public override bool CanExecute() => GameObject is { IsNone: false };

        protected override string TrueSummary => "{GameObject} {CheckIf}";
        protected override string FalseSummary => "{GameObject} not {CheckIf}";
        
        protected override bool Test() => CheckIf.Evaluate(GameObject.Value);
    }
}
