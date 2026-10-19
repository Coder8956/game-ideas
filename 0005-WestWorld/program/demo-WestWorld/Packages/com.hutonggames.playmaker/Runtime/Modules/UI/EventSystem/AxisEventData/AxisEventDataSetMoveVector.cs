
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.EventSystems
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.AxisEventData)]
	[ActionDescription("Raw input vector associated with this event.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/api/UnityEngine.EventSystems" +
		".PointerEventData.html")]
	public sealed class AxisEventDataSetMoveVector : BaseAction
	{
		
		[Tooltip("The AxisEventData")]
		[SerializeField]
		private AxisEventDataRef _axisEventData;
		
		[Tooltip("Set AxisEventData Move Vector")]
		[SerializeField]
		private Vector2Var _setMoveVector;
		
		public override bool CanExecute()
		{
			return CheckParameters(_axisEventData, _setMoveVector);
		}
		
		public override void Execute()
		{
			_axisEventData.Value.moveVector = _setMoveVector.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_axisEventData} move vector to {_setMoveVector}";
		}
	}
}
