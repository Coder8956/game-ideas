
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ModifiableContactPair)]
	[ActionDescription("World-space rotation of the first collider in this contact pair as seen by the so" +
		"lver.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ModifiableContactPair-rotation.html")]
	public sealed class ModifiableContactPairSetRotation : BaseAction
	{
		
		[Tooltip("The ModifiableContactPair")]
		[SerializeField]
		private ModifiableContactPairRef _modifiableContactPair;
		
		[Tooltip("Set ModifiableContactPair Rotation")]
		[SerializeField]
		private QuaternionRef _setRotation;
		
		public override bool CanExecute()
		{
			return CheckParameters(_modifiableContactPair, _setRotation);
		}
		
		public override void Execute()
		{
			var value = _modifiableContactPair.Value;
			value.rotation = _setRotation.Value;
			_modifiableContactPair.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_modifiableContactPair} Rotation to {_setRotation}";
		}
	}
}
