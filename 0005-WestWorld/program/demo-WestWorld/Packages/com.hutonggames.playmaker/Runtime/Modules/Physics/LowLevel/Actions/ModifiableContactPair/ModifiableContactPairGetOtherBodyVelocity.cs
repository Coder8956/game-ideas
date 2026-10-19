
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ModifiableContactPair)]
	[ActionDescription("Linear velocity of the second body in the contact pair.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ModifiableContactPair-otherBodyVelocity." +
		"html")]
	public sealed class ModifiableContactPairGetOtherBodyVelocity : BaseAction
	{
		
		[Tooltip("The ModifiableContactPair")]
		[SerializeField]
		private ModifiableContactPairRef _modifiableContactPair;
		
		[Tooltip("Get ModifiableContactPair Other Body Velocity")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _getOtherBodyVelocity;
		
		public override bool CanExecute()
		{
			return CheckParameters(_modifiableContactPair, _getOtherBodyVelocity);
		}
		
		public override void Execute()
		{
			_getOtherBodyVelocity.Value = _modifiableContactPair.Value.otherBodyVelocity;
		}
		
		public override string GetSummary()
		{
			return "Get {_modifiableContactPair} otherBodyVelocity -> {_getOtherBodyVelocity}";
		}
	}
}
