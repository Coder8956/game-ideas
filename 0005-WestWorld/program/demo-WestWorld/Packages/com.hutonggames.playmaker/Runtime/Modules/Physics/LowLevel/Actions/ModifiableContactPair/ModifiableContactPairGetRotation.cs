
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
	public sealed class ModifiableContactPairGetRotation : BaseAction
	{
		
		[Tooltip("The ModifiableContactPair")]
		[SerializeField]
		private ModifiableContactPairRef _modifiableContactPair;
		
		[Tooltip("Get ModifiableContactPair Rotation")]
		[SerializeField]
		[WriteOnly]
		private QuaternionRef _getRotation;
		
		public override bool CanExecute()
		{
			return CheckParameters(_modifiableContactPair, _getRotation);
		}
		
		public override void Execute()
		{
			_getRotation.Value = _modifiableContactPair.Value.rotation;
		}
		
		public override string GetSummary()
		{
			return "Get {_modifiableContactPair} rotation -> {_getRotation}";
		}
	}
}
