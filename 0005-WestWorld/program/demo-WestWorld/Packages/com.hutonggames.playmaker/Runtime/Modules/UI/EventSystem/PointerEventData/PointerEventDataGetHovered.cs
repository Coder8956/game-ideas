
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.EventSystems
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PointerEventData)]
	[ActionDescription("List of objects in the hover stack.")]
	[HelpURL("https://docs.unity3d.com/2019.1/Documentation/ScriptReference/EventSystems.PointerEventData.html")]
	public sealed class PointerEventDataGetHovered : BaseAction
	{
		
		[Tooltip("The PointerEventData")]
		[SerializeField]
		private PointerEventDataRef _pointerEventData;
		
		[Tooltip("Get PointerEventData Hovered")]
		[SerializeField]
		[WriteOnly]
		private GameObjectListRef _getHovered;
		
		public override bool CanExecute()
		{
			return CheckParameters(_pointerEventData, _getHovered);
		}
		
		public override void Execute()
		{
			if (_pointerEventData.Value == null) return;
			_getHovered.Value = _pointerEventData.Value.hovered;
		}
		
		public override string GetSummary()
		{
			return "Get {_pointerEventData} hovered -> {_getHovered}";
		}
	}
}
