
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.RaycastHit2D)]
	[ActionDescription("The normal vector of the surface hit by the ray.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/RaycastHit2D-normal.html")]
	public sealed class RaycastHit2DGetNormal : BaseAction
	{
		
		[Tooltip("The RaycastHit2D")]
		[SerializeField]
		private RaycastHit2DRef _raycastHit2D;
		
		[Tooltip("Get RaycastHit2D Normal")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _getNormal;
		
		public override bool CanExecute()
		{
			return CheckParameters(_raycastHit2D, _getNormal);
		}
		
		public override void Execute()
		{
			_getNormal.Value = _raycastHit2D.Value.normal;
		}
		
		public override string GetSummary()
		{
			return "Get {_raycastHit2D} normal -> {_getNormal}";
		}
	}
}
