using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Behaviour)]
    [ActionDescription("Check if a Behaviour is enabled.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Behaviour-enabled.html")]
    public class BehaviourCheckIsEnabled : BaseTrueFalseAction
    {
        [Tooltip("The Behaviour to check.")]
        [SerializeField]
        private BehaviourVar _behaviour;
        
        protected override string TrueSummary => "{_behaviour} is enabled";
        protected override string FalseSummary => "{_behaviour} is not enabled";
        
        public override bool CanExecute() => CheckParameters(_behaviour);

        protected override bool Test() => _behaviour.Value.enabled;
    }
}