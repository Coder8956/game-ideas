
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Bounds)]
	[ActionDescription("The smallest squared distance between the point and this bounding box.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Bounds.SqrDistance.html")]
	public sealed class BoundsSqrDistance : BaseAction
	{
		
		[Tooltip("The Bounds.")]
		[SerializeField]
		private BoundsRef _bounds;
		
		[Tooltip("Point.")]
		[SerializeField]
		private Vector3Var _point;
		
		[Tooltip("Store the result in Float variable.")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_bounds, _point, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Bounds.SqrDistance(UnityEngine.Vector3);
			_result.Value = _bounds.Value.SqrDistance(_point.Value);
		}
		
		public override string GetSummary()
		{
			return "Get sqr distance from {_point} to {_bounds} -> {_result}";
		}
	}
}
