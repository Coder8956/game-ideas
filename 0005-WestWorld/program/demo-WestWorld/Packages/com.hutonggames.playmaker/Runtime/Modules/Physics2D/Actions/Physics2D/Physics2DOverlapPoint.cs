
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Physics2DQueries)]
	[ActionDescription("Checks if a Collider overlaps a point in space.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Physics2D.OverlapPoint.html")]
	public sealed class Physics2DOverlapPoint : BaseAction
	{
		
		[Tooltip("A point in world space.")]
		[SerializeField]
		private Vector2Var _point;
		
		[ActionHeader("Filters")]
		
		[Tooltip("Filter to check objects only on specific layers.")]
		[SerializeField]
		[DefaultValue(Physics.DefaultRaycastLayers)]
		private LayerMaskVar _layerMask;

		[Tooltip("Only include objects with a Z coordinate (depth) greater than or equal to this value.")]
		[SerializeField]
		[DefaultValue("~FloatNegativeInfinity")]
		private FloatVar _minDepth;
		
		[Tooltip("Only include objects with a Z coordinate (depth) less than or equal to this value.")]
		[SerializeField]
		[DefaultValue("~FloatPositiveInfinity")]
		private FloatVar _maxDepth;
		
		[ActionHeader("Result")]
		
		[Tooltip("Store the result in Collider2D variable.")]
		[SerializeField]
		[WriteOnly]
		private Collider2DRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_point, _layerMask, _result, _layerMask, _minDepth, _maxDepth);
		}
		
		public override void Execute()
		{
			//UnityEngine.Physics2D.OverlapPoint(UnityEngine.Vector2, System.Int32);
			_result.Value = Physics2D.OverlapPoint(_point.Value, _layerMask.Value, _minDepth.Value, _maxDepth.Value);
		}
		
		public override string GetSummary()
		{
			return "Physics2D Overlap Point: {_point} {_layerMask} -> {_result}";
		}
	}
}
