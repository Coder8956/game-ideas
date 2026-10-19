
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
	public sealed class ModifiableContactPairGetPosition : BaseAction
	{
		
		[Tooltip("The ModifiableContactPair")]
		[SerializeField]
		private ModifiableContactPairRef _modifiableContactPair;
		
		[Tooltip("Get ModifiableContactPair Position")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _getPosition;
		
		public override bool CanExecute()
		{
			return CheckParameters(_modifiableContactPair, _getPosition);
		}
		
		public override void Execute()
		{
			_getPosition.Value = _modifiableContactPair.Value.position;
		}
		
		public override string GetSummary()
		{
			return "Get {_modifiableContactPair} position -> {_getPosition}";
		}
	}
}
