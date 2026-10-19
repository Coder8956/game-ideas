
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Behaviour)]
	[ActionDescription("Restart a Behaviour by disabling it then enabling it.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Behaviour-enabled.html")]
	public sealed class BehaviourRestart : BaseAction
	{
		
		[Tooltip("The Behaviour to restart.")]
		[SerializeField]
		private BehaviourVar _behaviour;
		
		public override bool CanExecute() => CheckParameters(_behaviour);

		public override void Execute()
		{
			_behaviour.Value.enabled = false;
			_behaviour.Value.enabled = true;
		}

		public override string GetSummary() => "Restart {_behaviour}";
	}
}
