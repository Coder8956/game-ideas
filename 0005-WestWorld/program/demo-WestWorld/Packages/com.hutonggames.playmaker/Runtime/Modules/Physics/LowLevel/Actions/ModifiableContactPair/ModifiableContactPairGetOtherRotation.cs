
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ModifiableContactPair)]
	[ActionDescription("World-space rotation of the second collider in this contact pair as seen by the s" +
		"olver.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ModifiableContactPair-otherRotation.html" +
		"")]
	public sealed class ModifiableContactPairGetOtherRotation : BaseAction
	{
		
		[Tooltip("The ModifiableContactPair")]
		[SerializeField]
		private ModifiableContactPairRef _modifiableContactPair;
		
		[Tooltip("Get ModifiableContactPair Other Rotation")]
		[SerializeField]
		[WriteOnly]
		private QuaternionRef _getOtherRotation;
		
		public override bool CanExecute()
		{
			return CheckParameters(_modifiableContactPair, _getOtherRotation);
		}
		
		public override void Execute()
		{
			_getOtherRotation.Value = _modifiableContactPair.Value.otherRotation;
		}
		
		public override string GetSummary()
		{
			return "Get {_modifiableContactPair} otherRotation -> {_getOtherRotation}";
		}
	}
}
