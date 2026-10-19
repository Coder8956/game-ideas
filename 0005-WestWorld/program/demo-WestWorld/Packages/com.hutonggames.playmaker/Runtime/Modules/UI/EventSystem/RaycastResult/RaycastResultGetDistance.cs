using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.EventSystems
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.RaycastResult)]
	[ActionDescription("Distance to the hit.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/EventSystems.RaycastResult.html")]
	public sealed class RaycastResultGetDistance : BaseAction
	{
		
		[Tooltip("The RaycastResult")]
		[SerializeField]
		private RaycastResultRef _raycastResult;
		
		[Tooltip("Get RaycastResult Distance")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getDistance;
		
		public override bool CanExecute()
		{
			return CheckParameters(_raycastResult, _getDistance);
		}
		
		public override void Execute()
		{
			_getDistance.Value = _raycastResult.Value.distance;
		}
		
		public override string GetSummary()
		{
			return "Get {_raycastResult} distance -> {_getDistance}";
		}
	}
}
