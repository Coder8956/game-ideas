
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Behaviour)]
	[ActionDescription("Reports whether a GameObject and its associated Behaviour is active and enabled.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Behaviour-isActiveAndEnabled.html")]
	public sealed class BehaviourGetIsActiveAndEnabled : BaseAction
	{
		
		[Tooltip("The Behaviour")]
		[SerializeField]
		private BehaviourVar _behaviour;
		
		[Tooltip("Get Behaviour Is Active And Enabled")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getIsActiveAndEnabled;
		
		public override bool CanExecute()
		{
			return CheckParameters(_behaviour, _getIsActiveAndEnabled);
		}
		
		public override void Execute()
		{
			_getIsActiveAndEnabled.Value = _behaviour.Value.isActiveAndEnabled;
		}
		
		public override string GetSummary()
		{
			return "Get {_behaviour} isActiveAndEnabled -> {_getIsActiveAndEnabled}";
		}
	}
}
