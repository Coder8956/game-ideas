
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ModifiableContactPair)]
	[ActionDescription("Linear velocity of the first body in the contact pair.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ModifiableContactPair-bodyVelocity.html")]
	public sealed class ModifiableContactPairGetBodyVelocity : BaseAction
	{
		
		[Tooltip("The ModifiableContactPair")]
		[SerializeField]
		private ModifiableContactPairRef _modifiableContactPair;
		
		[Tooltip("Get ModifiableContactPair Body Velocity")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _getBodyVelocity;
		
		public override bool CanExecute()
		{
			return CheckParameters(_modifiableContactPair, _getBodyVelocity);
		}
		
		public override void Execute()
		{
			_getBodyVelocity.Value = _modifiableContactPair.Value.bodyVelocity;
		}
		
		public override string GetSummary()
		{
			return "Get {_modifiableContactPair} bodyVelocity -> {_getBodyVelocity}";
		}
	}
}
