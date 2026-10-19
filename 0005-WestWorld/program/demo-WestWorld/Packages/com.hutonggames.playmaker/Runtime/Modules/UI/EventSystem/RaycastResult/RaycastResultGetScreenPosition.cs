using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.EventSystems
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.RaycastResult)]
	[ActionDescription("Screen position of the event.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/EventSystems.RaycastResult.html")]
	public sealed class RaycastResultGetScreenPosition : BaseAction
	{
		
		[Tooltip("The RaycastResult")]
		[SerializeField]
		private RaycastResultRef _raycastResult;
		
		[Tooltip("Get RaycastResult Screen Position")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _getScreenPosition;
		
		public override bool CanExecute()
		{
			return CheckParameters(_raycastResult, _getScreenPosition);
		}
		
		public override void Execute()
		{
			_getScreenPosition.Value = _raycastResult.Value.screenPosition;
		}
		
		public override string GetSummary()
		{
			return "Get {_raycastResult} screen position -> {_getScreenPosition}";
		}
	}
}
