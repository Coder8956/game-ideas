using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.EventSystems
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.RaycastResult)]
	[ActionDescription("World position where the raycast hit.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/EventSystems.RaycastResult.html")]
	public sealed class RaycastResultGetWorldPosition : BaseAction
	{
		
		[Tooltip("The RaycastResult")]
		[SerializeField]
		private RaycastResultRef _raycastResult;
		
		[Tooltip("Get RaycastResult World Position")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _getWorldPosition;
		
		public override bool CanExecute()
		{
			return CheckParameters(_raycastResult, _getWorldPosition);
		}
		
		public override void Execute()
		{
			_getWorldPosition.Value = _raycastResult.Value.worldPosition;
		}
		
		public override string GetSummary()
		{
			return "Get {_raycastResult} world position -> {_getWorldPosition}";
		}
	}
}
