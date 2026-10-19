
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.RaycastHit2D)]
	[ActionDescription("The GameObject that was hit.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/RaycastHit2D-transform.html")]
	public sealed class RaycastHit2DGetGameObject : BaseAction
	{
		
		[Tooltip("The RaycastHit2D")]
		[SerializeField]
		private RaycastHit2DRef _raycastHit2D;
		
		[Tooltip("Get the GameObject that was hit.")]
		[SerializeField]
		[WriteOnly]
		private GameObjectRef _getGameObject;
		
		public override bool CanExecute()
		{
			return CheckParameters(_raycastHit2D, _getGameObject);
		}
		
		public override void Execute()
		{
			var transform = _raycastHit2D.Value.transform;
			_getGameObject.Value = transform ? transform.gameObject : null;
		}
		
		public override string GetSummary()
		{
			return "Get {_raycastHit2D} GameObject -> {_getGameObject}";
		}
	}
}
