
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.RaycastHit)]
	[ActionDescription("The index of the triangle that was hit.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/RaycastHit-triangleIndex.html")]
	public sealed class RaycastHitGetTriangleIndex : BaseAction
	{
		
		[Tooltip("The RaycastHit")]
		[SerializeField]
		private RaycastHitRef _raycastHit;
		
		[Tooltip("Get RaycastHit Triangle Index")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getTriangleIndex;
		
		public override bool CanExecute()
		{
			return CheckParameters(_raycastHit, _getTriangleIndex);
		}
		
		public override void Execute()
		{
			_getTriangleIndex.Value = _raycastHit.Value.triangleIndex;
		}
		
		public override string GetSummary()
		{
			return "Get {_raycastHit} Triangle Index -> {_getTriangleIndex}";
		}
	}
}
