
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ControllerColliderHit)]
	[ActionDescription("The controller that hit the collider.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ControllerColliderHit-controller.html")]
	public sealed class ControllerColliderHitGetController : BaseAction
	{
		
		[Tooltip("The ControllerColliderHit")]
		[SerializeField]
		private ControllerColliderHitRef _controllerColliderHit;
		
		[Tooltip("Get ControllerColliderHit Controller")]
		[SerializeField]
		[WriteOnly]
		private CharacterControllerRef _getController;
		
		public override bool CanExecute()
		{
			return CheckParameters(_controllerColliderHit, _getController);
		}
		
		public override void Execute()
		{
			_getController.Value = _controllerColliderHit.Value.controller;
		}
		
		public override string GetSummary()
		{
			return "Get {_controllerColliderHit} controller -> {_getController}";
		}
	}
}
