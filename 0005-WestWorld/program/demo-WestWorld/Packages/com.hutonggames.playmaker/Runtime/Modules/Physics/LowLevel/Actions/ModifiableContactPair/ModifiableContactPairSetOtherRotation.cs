
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
	public sealed class ModifiableContactPairSetOtherRotation : BaseAction
	{
		
		[Tooltip("The ModifiableContactPair")]
		[SerializeField]
		private ModifiableContactPairRef _modifiableContactPair;
		
		[Tooltip("Set ModifiableContactPair Other Rotation")]
		[SerializeField]
		private QuaternionRef _setOtherRotation;
		
		public override bool CanExecute()
		{
			return CheckParameters(_modifiableContactPair, _setOtherRotation);
		}
		
		public override void Execute()
		{
			var value = _modifiableContactPair.Value;
			value.otherRotation = _setOtherRotation.Value;
			_modifiableContactPair.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_modifiableContactPair} Other Rotation to {_setOtherRotation}";
		}
	}
}
