
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.EventSystems
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PointerEventData)]
	[ActionDescription("Specifies the state of the pen. For example, whether the pen is in contact with the screen or tablet, whether the pen is inverted, and whether buttons are pressed.")]
	[HelpURL("https://docs.unity3d.com/2019.1/Documentation/ScriptReference/EventSystems.PointerEventData.html")]
	public sealed class PointerEventDataGetPenStatus : BaseAction
	{
		
		[Tooltip("The PointerEventData")]
		[SerializeField]
		private PointerEventDataRef _pointerEventData;
		
		[Tooltip("Get PointerEventData Pen Status")]
		[SerializeField]
		[WriteOnly]
		private PenStatusRef _getPenStatus;
		
		public override bool CanExecute()
		{
			return CheckParameters(_pointerEventData, _getPenStatus);
		}
		
		public override void Execute()
		{
			if (_pointerEventData.Value == null) return;
			_getPenStatus.Value = _pointerEventData.Value.penStatus;
		}
		
		public override string GetSummary()
		{
			return "Get {_pointerEventData} pen status -> {_getPenStatus}";
		}
	}
}
