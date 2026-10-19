
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ModifiableContactPair)]
	[ActionDescription("World-space position of the second collider in this contact pair as seen by the s" +
		"olver.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ModifiableContactPair-otherPosition.html" +
		"")]
	public sealed class ModifiableContactPairSetOtherPosition : BaseAction
	{
		
		[Tooltip("The ModifiableContactPair")]
		[SerializeField]
		private ModifiableContactPairRef _modifiableContactPair;
		
		[Tooltip("Set ModifiableContactPair Other Position")]
		[SerializeField]
		private Vector3Var _setOtherPosition;
		
		public override bool CanExecute()
		{
			return CheckParameters(_modifiableContactPair, _setOtherPosition);
		}
		
		public override void Execute()
		{
			var value = _modifiableContactPair.Value;
			value.otherPosition = _setOtherPosition.Value;
			_modifiableContactPair.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_modifiableContactPair} Other Position to {_setOtherPosition}";
		}
	}
}
