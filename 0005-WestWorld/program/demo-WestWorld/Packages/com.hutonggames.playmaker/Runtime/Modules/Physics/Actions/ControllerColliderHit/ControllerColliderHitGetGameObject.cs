
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ControllerColliderHit)]
	[ActionDescription("The game object that was hit by the controller.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ControllerColliderHit-gameObject.html")]
	public sealed class ControllerColliderHitGetGameObject : BaseAction
	{
		
		[Tooltip("The ControllerColliderHit")]
		[SerializeField]
		private ControllerColliderHitRef _controllerColliderHit;
		
		[Tooltip("Get ControllerColliderHit GameObject")]
		[SerializeField]
		[WriteOnly]
		private GameObjectRef _getGameObject;
		
		public override bool CanExecute()
		{
			return CheckParameters(_controllerColliderHit, _getGameObject);
		}
		
		public override void Execute()
		{
			_getGameObject.Value = _controllerColliderHit.Value.gameObject;
		}
		
		public override string GetSummary()
		{
			return "Get {_controllerColliderHit} gameObject -> {_getGameObject}";
		}
	}
}
