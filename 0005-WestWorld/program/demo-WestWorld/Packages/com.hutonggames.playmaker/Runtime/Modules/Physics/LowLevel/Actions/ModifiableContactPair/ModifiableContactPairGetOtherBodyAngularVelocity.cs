
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ModifiableContactPair)]
	[ActionDescription("Angular velocity of the second body in the contact pair.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ModifiableContactPair-otherBodyAngularVe" +
		"locity.html")]
	public sealed class ModifiableContactPairGetOtherBodyAngularVelocity : BaseAction
	{
		
		[Tooltip("The ModifiableContactPair")]
		[SerializeField]
		private ModifiableContactPairRef _modifiableContactPair;
		
		[Tooltip("Get ModifiableContactPair Other Body Angular Velocity")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _getOtherBodyAngularVelocity;
		
		public override bool CanExecute()
		{
			return CheckParameters(_modifiableContactPair, _getOtherBodyAngularVelocity);
		}
		
		public override void Execute()
		{
			_getOtherBodyAngularVelocity.Value = _modifiableContactPair.Value.otherBodyAngularVelocity;
		}
		
		public override string GetSummary()
		{
			return "Get {_modifiableContactPair} otherBodyAngularVelocity -> {_getOtherBodyAngularVelocity}";
		}
	}
}
