
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.RaycastHit)]
	[ActionDescription("The GameObject that was hit.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/RaycastHit-transform.html")]
	public sealed class RaycastHitGetGameObject : BaseAction
	{
		
		[Tooltip("The RaycastHit")]
		[SerializeField]
		private RaycastHitRef _raycastHit;
		
		[Tooltip("Get the GameObject that was hit.")]
		[SerializeField]
		[WriteOnly]
		private GameObjectRef _getGameObject;
		
		public override bool CanExecute()
		{
			return CheckParameters(_raycastHit, _getGameObject);
		}
		
		public override void Execute()
		{
			var transform = _raycastHit.Value.transform;
			_getGameObject.Value = transform ? transform.gameObject : null;
		}
		
		public override string GetSummary()
		{
			return "Get {_raycastHit} GameObject -> {_getGameObject}";
		}
	}
}
