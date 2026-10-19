
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.EventSystems
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PointerEventData)]
	[ActionDescription("The last time a click event was sent.")]
	[HelpURL("https://docs.unity3d.com/2019.1/Documentation/ScriptReference/EventSystems.PointerEventData.html")]
	public sealed class PointerEventDataGetClickTime : BaseAction
	{
		
		[Tooltip("The PointerEventData")]
		[SerializeField]
		private PointerEventDataRef _pointerEventData;
		
		[Tooltip("Get PointerEventData Click Time")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getClickTime;
		
		public override bool CanExecute()
		{
			return CheckParameters(_pointerEventData, _getClickTime);
		}
		
		public override void Execute()
		{
			if (_pointerEventData.Value == null) return;
			_getClickTime.Value = _pointerEventData.Value.clickTime;
		}
		
		public override string GetSummary()
		{
			return "Get {_pointerEventData} click time -> {_getClickTime}";
		}
	}
}
