
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ModifiableContactPair)]
	[ActionDescription("World-space position of the first collider in this contact pair as seen by the so" +
		"lver.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ModifiableContactPair-position.html")]
	public sealed class ModifiableContactPairSetPosition : BaseAction
	{
		
		[Tooltip("The ModifiableContactPair")]
		[SerializeField]
		private ModifiableContactPairRef _modifiableContactPair;
		
		[Tooltip("Set ModifiableContactPair Position")]
		[SerializeField]
		private Vector3Var _setPosition;
		
		public override bool CanExecute()
		{
			return CheckParameters(_modifiableContactPair, _setPosition);
		}
		
		public override void Execute()
		{
			var value = _modifiableContactPair.Value;
			value.position = _setPosition.Value;
			_modifiableContactPair.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_modifiableContactPair} Position to {_setPosition}";
		}
	}
}
