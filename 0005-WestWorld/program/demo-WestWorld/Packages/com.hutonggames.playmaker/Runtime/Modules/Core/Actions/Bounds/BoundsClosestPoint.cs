
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Bounds)]
	[ActionDescription("The closest point on the bounding box.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Bounds.ClosestPoint.html")]
	public sealed class BoundsClosestPoint : BaseAction
	{
		
		[Tooltip("The Bounds.")]
		[SerializeField]
		private BoundsRef _bounds;
		
		[Tooltip("Arbitrary point.")]
		[SerializeField]
		private Vector3Var _point;
		
		[Tooltip("Store the result in Vector3 variable.")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_bounds, _point, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Bounds.ClosestPoint(UnityEngine.Vector3);
			_result.Value = _bounds.Value.ClosestPoint(_point.Value);
		}
		
		public override string GetSummary()
		{
			return "Get closest point on {_bounds} to {_point} -> {_result}";
		}
	}
}
