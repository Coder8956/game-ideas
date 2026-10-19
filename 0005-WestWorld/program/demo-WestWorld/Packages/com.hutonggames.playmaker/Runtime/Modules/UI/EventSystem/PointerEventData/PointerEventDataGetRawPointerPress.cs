
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.EventSystems
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PointerEventData)]
	[ActionDescription("The object that the press happened on even if it can not handle the press event.")]
	[HelpURL("https://docs.unity3d.com/2019.1/Documentation/ScriptReference/EventSystems.PointerEventData.html")]
	public sealed class PointerEventDataGetRawPointerPress : BaseAction
	{
		
		[Tooltip("The PointerEventData")]
		[SerializeField]
		private PointerEventDataRef _pointerEventData;
		
		[Tooltip("Get PointerEventData Raw Pointer Press")]
		[SerializeField]
		[WriteOnly]
		private GameObjectRef _getRawPointerPress;
		
		public override bool CanExecute()
		{
			return CheckParameters(_pointerEventData, _getRawPointerPress);
		}
		
		public override void Execute()
		{
			if (_pointerEventData.Value == null) return;
			_getRawPointerPress.Value = _pointerEventData.Value.rawPointerPress;
		}
		
		public override string GetSummary()
		{
			return "Get {_pointerEventData} raw pointer press -> {_getRawPointerPress}";
		}
	}
}
