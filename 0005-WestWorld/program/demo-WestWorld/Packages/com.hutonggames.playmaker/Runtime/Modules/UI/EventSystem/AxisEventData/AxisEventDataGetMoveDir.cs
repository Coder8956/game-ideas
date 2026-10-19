
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;


namespace HutongGames.PlayMaker.Actions.EventSystems
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.AxisEventData)]
	[ActionDescription("MoveDirection for this event.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/api/UnityEngine.EventSystems.AxisEventData.html")]
	public sealed class AxisEventDataGetMoveDir : BaseAction
	{
		
		[Tooltip("The AxisEventData")]
		[SerializeField]
		private AxisEventDataRef _axisEventData;
		
		[Tooltip("Get AxisEventData Move Dir")]
		[SerializeField]
		[WriteOnly]
		private MoveDirectionRef _getMoveDir;
		
		public override bool CanExecute()
		{
			return CheckParameters(_axisEventData, _getMoveDir);
		}
		
		public override void Execute()
		{
			_getMoveDir.Value = _axisEventData.Value.moveDir;
		}
		
		public override string GetSummary()
		{
			return "Get {_axisEventData} move dir -> {_getMoveDir}";
		}
	}
}
