
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Behaviour)]
	[ActionDescription("Enabled Behaviours are Updated, disabled Behaviours are not.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Behaviour-enabled.html")]
	public sealed class BehaviourGetEnabled : BaseAction
	{
		
		[Tooltip("The Behaviour")]
		[SerializeField]
		private BehaviourVar _behaviour;
		
		[Tooltip("Get Behaviour Enabled")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getEnabled;
		
		public override bool CanExecute()
		{
			return CheckParameters(_behaviour, _getEnabled);
		}
		
		public override void Execute()
		{
			_getEnabled.Value = _behaviour.Value.enabled;
		}
		
		public override string GetSummary()
		{
			return "Get {_behaviour} enabled -> {_getEnabled}";
		}
	}
}
