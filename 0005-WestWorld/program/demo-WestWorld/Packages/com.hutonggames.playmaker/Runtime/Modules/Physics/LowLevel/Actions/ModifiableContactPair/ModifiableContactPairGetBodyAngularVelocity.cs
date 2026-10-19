
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ModifiableContactPair)]
	[ActionDescription("Angular velocity of the first body in the contact pair.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ModifiableContactPair-bodyAngularVelocit" +
		"y.html")]
	public sealed class ModifiableContactPairGetBodyAngularVelocity : BaseAction
	{
		
		[Tooltip("The ModifiableContactPair")]
		[SerializeField]
		private ModifiableContactPairRef _modifiableContactPair;
		
		[Tooltip("Get ModifiableContactPair Body Angular Velocity")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _getBodyAngularVelocity;
		
		public override bool CanExecute()
		{
			return CheckParameters(_modifiableContactPair, _getBodyAngularVelocity);
		}
		
		public override void Execute()
		{
			_getBodyAngularVelocity.Value = _modifiableContactPair.Value.bodyAngularVelocity;
		}
		
		public override string GetSummary()
		{
			return "Get {_modifiableContactPair} bodyAngularVelocity -> {_getBodyAngularVelocity}";
		}
	}
}
