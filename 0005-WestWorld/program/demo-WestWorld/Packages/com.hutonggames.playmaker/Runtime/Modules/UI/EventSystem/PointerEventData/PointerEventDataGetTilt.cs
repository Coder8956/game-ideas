
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.EventSystems
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PointerEventData)]
	[ActionDescription("The tilt of the stylus, in radians.")]
	[HelpURL("https://docs.unity3d.com/2019.1/Documentation/ScriptReference/EventSystems.PointerEventData.html")]
	public sealed class PointerEventDataGetTilt : BaseAction
	{
		
		[Tooltip("The PointerEventData")]
		[SerializeField]
		private PointerEventDataRef _pointerEventData;
		
		[Tooltip("Get PointerEventData Tilt")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _getTilt;
		
		public override bool CanExecute()
		{
			return CheckParameters(_pointerEventData, _getTilt);
		}
		
		public override void Execute()
		{
			if (_pointerEventData.Value == null) return;
			_getTilt.Value = _pointerEventData.Value.tilt;
		}
		
		public override string GetSummary()
		{
			return "Get {_pointerEventData} tilt -> {_getTilt}";
		}
	}
}
