
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Behaviour)]
	[ActionDescription("Disable a Behaviour. Enabled Behaviours are Updated, disabled Behaviours are not.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Behaviour-enabled.html")]
	public sealed class BehaviourDisable : BaseAction
	{
		
		[Tooltip("The Behaviour to disable.<br/>Note: Renderers are not Behaviours. Use Renderer Set Enabled instead.")]
		[SerializeField]
		private BehaviourVar _behaviour;
		
		public override bool CanExecute() => CheckParameters(_behaviour);

		public override void Execute() => _behaviour.Value.enabled = false;

		public override string GetSummary() => "Disable {_behaviour}";
	}
}
