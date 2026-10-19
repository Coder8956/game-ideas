using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.LogicValue)]
    [ActionDescription("Check a GameObject variable value.")]
    public class CheckGameObjectEquals : BaseTrueFalseAction
    {
        [NotOwnerDefaultValue]
        [Tooltip("The GameObject variable to check.")]
        public GameObjectRef GameObject;
        
        [CanBeNullOrEmpty]
        [Tooltip("The value to compare to.")]
        public GameObjectVar Value;
        
        protected override string TrueSummary => "{GameObject} == {Value}";
        protected override string FalseSummary => "{GameObject} != {Value}";
        
        public override bool CanExecute() => !GameObject.IsNone;

        protected override bool Test() => GameObject.Value == Value.Value;
    }
}
