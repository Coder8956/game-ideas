
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Behaviour)]
	[ActionDescription("Enabled Behaviours are Updated, disabled Behaviours are not.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Behaviour-enabled.html")]
	public sealed class BehaviourSetEnabled : BaseAction
	{
		
		[Tooltip("The Behaviour to enable/disable.<br/>Note: Renderers are not Behaviours. Use Renderer Set Enabled instead.")]
		[SerializeField]
		private BehaviourVar _behaviour;
		
		[Tooltip("Enable/disable the Behaviour")]
		[SerializeField, DefaultValue(true)]
		private BoolVar _setEnabled;
		
		public override bool CanExecute()
		{
			return CheckParameters(_behaviour, _setEnabled);
		}
		
		public override void Execute()
		{
			_behaviour.Value.enabled = _setEnabled.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_behaviour} Enabled to {_setEnabled}";
		}
	}
}
