
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;


namespace HutongGames.PlayMaker.Actions.EventSystems
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.AxisEventData)]
	[ActionDescription("MoveDirection for this event.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/api/UnityEngine.EventSystems" +
		".PointerEventData.html")]
	public sealed class AxisEventDataSetMoveDir : BaseAction
	{
		
		[Tooltip("The AxisEventData")]
		[SerializeField]
		private AxisEventDataRef _axisEventData;
		
		[Tooltip("Set AxisEventData Move Dir")]
		[SerializeField]
		private MoveDirectionVar _setMoveDir;
		
		public override bool CanExecute()
		{
			return CheckParameters(_axisEventData, _setMoveDir);
		}
		
		public override void Execute()
		{
			_axisEventData.Value.moveDir = _setMoveDir.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_axisEventData} move dir to {_setMoveDir}";
		}
	}
}
