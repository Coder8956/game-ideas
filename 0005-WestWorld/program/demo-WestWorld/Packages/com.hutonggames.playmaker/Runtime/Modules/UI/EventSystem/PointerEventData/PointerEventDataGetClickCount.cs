
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.EventSystems
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PointerEventData)]
	[ActionDescription("Number of clicks in a row.")]
	[HelpURL("https://docs.unity3d.com/2019.1/Documentation/ScriptReference/EventSystems.PointerEventData.html")]
	public sealed class PointerEventDataGetClickCount : BaseAction
	{
		
		[Tooltip("The PointerEventData")]
		[SerializeField]
		private PointerEventDataRef _pointerEventData;
		
		[Tooltip("Get PointerEventData Click Count")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getClickCount;
		
		public override bool CanExecute()
		{
			return CheckParameters(_pointerEventData, _getClickCount);
		}
		
		public override void Execute()
		{
			if (_pointerEventData.Value == null) return;
			_getClickCount.Value = _pointerEventData.Value.clickCount;
		}
		
		public override string GetSummary()
		{
			return "Get {_pointerEventData} click count -> {_getClickCount}";
		}
	}
}
