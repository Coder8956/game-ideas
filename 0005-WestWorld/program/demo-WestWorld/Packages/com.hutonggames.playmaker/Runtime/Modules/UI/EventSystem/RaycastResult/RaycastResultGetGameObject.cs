using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.EventSystems
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.RaycastResult)]
	[ActionDescription("The GameObject that was hit by the raycast.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/EventSystems.RaycastResult.html")]
	public sealed class RaycastResultGetGameObject : BaseAction
	{
		
		[Tooltip("The RaycastResult")]
		[SerializeField]
		private RaycastResultRef _raycastResult;
		
		[Tooltip("Get RaycastResult GameObject")]
		[SerializeField]
		[WriteOnly]
		private GameObjectRef _getGameObject;
		
		public override bool CanExecute()
		{
			return CheckParameters(_raycastResult, _getGameObject);
		}
		
		public override void Execute()
		{
			_getGameObject.Value = _raycastResult.Value.gameObject;
		}
		
		public override string GetSummary()
		{
			return "Get {_raycastResult} GameObject -> {_getGameObject}";
		}
	}
}
