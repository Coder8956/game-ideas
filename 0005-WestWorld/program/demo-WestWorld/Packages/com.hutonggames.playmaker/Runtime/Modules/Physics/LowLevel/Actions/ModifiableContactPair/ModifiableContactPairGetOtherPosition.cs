
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
	public sealed class ModifiableContactPairGetOtherPosition : BaseAction
	{
		
		[Tooltip("The ModifiableContactPair")]
		[SerializeField]
		private ModifiableContactPairRef _modifiableContactPair;
		
		[Tooltip("Get ModifiableContactPair Other Position")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _getOtherPosition;
		
		public override bool CanExecute()
		{
			return CheckParameters(_modifiableContactPair, _getOtherPosition);
		}
		
		public override void Execute()
		{
			_getOtherPosition.Value = _modifiableContactPair.Value.otherPosition;
		}
		
		public override string GetSummary()
		{
			return "Get {_modifiableContactPair} otherPosition -> {_getOtherPosition}";
		}
	}
}
