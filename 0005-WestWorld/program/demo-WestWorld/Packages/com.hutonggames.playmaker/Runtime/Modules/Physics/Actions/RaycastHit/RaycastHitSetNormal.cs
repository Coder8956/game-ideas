/*
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI]
	[ActionCategory(Category.RaycastHit)]
	[ActionDescription("The normal of the surface the ray hit.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/RaycastHit-normal.html")]
	public sealed class RaycastHitSetNormal : BaseAction
	{
		
		[Tooltip("The RaycastHit")]
		[SerializeField]
		private RaycastHitRef _raycastHit;
		
		[Tooltip("Set RaycastHit Normal")]
		[SerializeField]
		private Vector3Var _setNormal;
		
		public override bool CanExecute()
		{
			return CheckParameters(_raycastHit, _setNormal);
		}
		
		public override void Execute()
		{
			var value = _raycastHit.Value;
			value.normal = _setNormal.Value;
			_raycastHit.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_raycastHit} Normal to {_setNormal}";
		}
	}
}
*/
