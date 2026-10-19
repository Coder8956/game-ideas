
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ControllerColliderHit)]
	[ActionDescription("The normal of the surface we collided with in world space.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ControllerColliderHit-normal.html")]
	public sealed class ControllerColliderHitGetNormal : BaseAction
	{
		
		[Tooltip("The ControllerColliderHit")]
		[SerializeField]
		private ControllerColliderHitRef _controllerColliderHit;
		
		[Tooltip("Get ControllerColliderHit Normal")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _getNormal;
		
		public override bool CanExecute()
		{
			return CheckParameters(_controllerColliderHit, _getNormal);
		}
		
		public override void Execute()
		{
			_getNormal.Value = _controllerColliderHit.Value.normal;
		}
		
		public override string GetSummary()
		{
			return "Get {_controllerColliderHit} normal -> {_getNormal}";
		}
	}
}
