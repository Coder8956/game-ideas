
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.EventSystems
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PointerEventData)]
	[ActionDescription("The GameObject for the last press event.")]
	[HelpURL("https://docs.unity3d.com/2019.1/Documentation/ScriptReference/EventSystems.PointerEventData.html")]
	public sealed class PointerEventDataGetLastPress : BaseAction
	{
		
		[Tooltip("The PointerEventData")]
		[SerializeField]
		private PointerEventDataRef _pointerEventData;
		
		[Tooltip("Get PointerEventData Last Press")]
		[SerializeField]
		[WriteOnly]
		private GameObjectRef _getLastPress;
		
		public override bool CanExecute()
		{
			return CheckParameters(_pointerEventData, _getLastPress);
		}
		
		public override void Execute()
		{
			if (_pointerEventData.Value == null) return;
			_getLastPress.Value = _pointerEventData.Value.lastPress;
		}
		
		public override string GetSummary()
		{
			return "Get {_pointerEventData} last press -> {_getLastPress}";
		}
	}
}
