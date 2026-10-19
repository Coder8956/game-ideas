
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.EventSystems
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PointerEventData)]
	[ActionDescription("Pointer delta since last update.")]
	[HelpURL("https://docs.unity3d.com/2019.1/Documentation/ScriptReference/EventSystems.PointerEventData.html")]
	public sealed class PointerEventDataGetDelta : BaseAction
	{
		
		[Tooltip("The PointerEventData")]
		[SerializeField]
		private PointerEventDataRef _pointerEventData;
		
		[Tooltip("Get PointerEventData Delta")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _getDelta;
		
		public override bool CanExecute()
		{
			return CheckParameters(_pointerEventData, _getDelta);
		}
		
		public override void Execute()
		{
			if (_pointerEventData.Value == null) return;
			_getDelta.Value = _pointerEventData.Value.delta;
		}
		
		public override string GetSummary()
		{
			return "Get {_pointerEventData} delta -> {_getDelta}";
		}
	}
}
