
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
	public sealed class AxisEventDataGetMoveVector : BaseAction
	{
		
		[Tooltip("The AxisEventData")]
		[SerializeField]
		private AxisEventDataRef _axisEventData;
		
		[Tooltip("Get AxisEventData Move Vector")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _getMoveVector;
		
		public override bool CanExecute()
		{
			return CheckParameters(_axisEventData, _getMoveVector);
		}
		
		public override void Execute()
		{
			_getMoveVector.Value = _axisEventData.Value.moveVector;
		}
		
		public override string GetSummary()
		{
			return "Get {_axisEventData} move vector -> {_getMoveVector}";
		}
	}
}
