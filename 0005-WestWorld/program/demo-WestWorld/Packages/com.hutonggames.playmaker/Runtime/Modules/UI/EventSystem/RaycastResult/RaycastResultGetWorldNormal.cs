using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.EventSystems
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.RaycastResult)]
	[ActionDescription("World normal where the raycast hit.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/EventSystems.RaycastResult.html")]
	public sealed class RaycastResultGetWorldNormal : BaseAction
	{
		
		[Tooltip("The RaycastResult")]
		[SerializeField]
		private RaycastResultRef _raycastResult;
		
		[Tooltip("Get RaycastResult World Normal")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _getWorldNormal;
		
		public override bool CanExecute()
		{
			return CheckParameters(_raycastResult, _getWorldNormal);
		}
		
		public override void Execute()
		{
			_getWorldNormal.Value = _raycastResult.Value.worldNormal;
		}
		
		public override string GetSummary()
		{
			return "Get {_raycastResult} world normal -> {_getWorldNormal}";
		}
	}
}
