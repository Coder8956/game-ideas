
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.EventSystems
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PointerEventData)]
	[ActionDescription("The index of the display that this pointer event comes from.")]
	[HelpURL("https://docs.unity3d.com/2019.1/Documentation/ScriptReference/EventSystems.PointerEventData.html")]
	public sealed class PointerEventDataGetDisplayIndex : BaseAction
	{
		
		[Tooltip("The PointerEventData")]
		[SerializeField]
		private PointerEventDataRef _pointerEventData;
		
		[Tooltip("Get PointerEventData Display Index")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getDisplayIndex;
		
		public override bool CanExecute()
		{
			return CheckParameters(_pointerEventData, _getDisplayIndex);
		}
		
		public override void Execute()
		{
			if (_pointerEventData.Value == null) return;
			_getDisplayIndex.Value = _pointerEventData.Value.displayIndex;
		}
		
		public override string GetSummary()
		{
			return "Get {_pointerEventData} display index -> {_getDisplayIndex}";
		}
	}
}
